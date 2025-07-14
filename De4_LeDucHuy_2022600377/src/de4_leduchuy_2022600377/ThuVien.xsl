<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:output method="html"/>
    <xsl:template match="/">
		<html lang="en">
			<head>
				<title>Document</title>
				<style>
					.container{
					width: 1000px;
					margin: 0 auto;
					}
					h2{
					color:blue;
					font-size: 28px;
					text-align: center;
					}
					p{
					font-size: 22px;

					}
					table{
					font-size: 20px;
					}
					.head{
					background-color: aqua;
					}
					td{
					min-width: 200px;
					background-color: bisque;
					}

				</style>
			</head>
			<body>
				<div class="container">
					<h2>DANH MỤC SÁCH</h2>
					<xsl:apply-templates select ="TV/NhaXB"></xsl:apply-templates>
				</div>
			</body>
		</html>
    </xsl:template>

	<xsl:template match="TV/NhaXB">
		<p>
			<b>Nhà xuất bản:</b>
			<xsl:value-of select="@TenNXB"/>
		</p>
		<table border="1" align="center">
			<tr class="head">
				<th>STT</th>
				<th>Tên sách</th>
				<th>Số trang</th>
				<th>Giá</th>
			</tr>
			<xsl:apply-templates select="Sach"></xsl:apply-templates>
		</table>
	</xsl:template>
	
	<xsl:template match="Sach">
		<tr>
			<td>
				<xsl:number/>
			</td>
			<td>
				<xsl:value-of select="TenSach"/>
			</td>
			<td>
				<xsl:value-of select="SoTrang"/>
			</td>
			<td style="color:red">
				<xsl:choose>
					<xsl:when test="SoTrang &lt;= 100">
						<xsl:value-of select="SoTrang * 4000"/>
					</xsl:when>
					<xsl:when test="SoTrang &gt;= 100 and SoTrang &lt;= 150">
						<xsl:value-of select="100 * 4000 + (SoTrang - 100)*3000"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="100 * 4000 + 50*3000 - (SoTrang - 150) * 2000"/>
					</xsl:otherwise>
				</xsl:choose>
			</td>
		</tr>
	</xsl:template>

</xsl:stylesheet>
