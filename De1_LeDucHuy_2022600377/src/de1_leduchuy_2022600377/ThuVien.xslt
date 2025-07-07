<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html lang="en">
			<head>
				<title>Document</title>
				<style>
					.container{
						width:900px;
						margin: 0 auto;
					}
					th,td{
						min-width: 200px;
					}
				</style>
			</head>
			<body>
				<div class="container">
					<h2 style="text-align: center; color:brown; text-transform: uppercase; font-size: 36px;">Danh mục sách</h2>
					<xsl:apply-templates select="TV/NhaXB"></xsl:apply-templates>
				</div>
			</body>
		</html>
    </xsl:template>
	<xsl:template match="TV/NhaXB">
		<h3 style="font-size: 30px;">
			<b>Nhà xuất bản: <xsl:value-of select="@TenNXB"/>
		</b>
		</h3>
		<table border ="1" align="center" style="font-size: 28px;">
			<tr style="background-color: blanchedalmond;">
				<th>STT</th>
				<th>Tên sách</th>
				<th>Số trang</th>
				<th>Giá</th>
			</tr>
			<xsl:apply-templates select="Sach"></xsl:apply-templates>
		</table>
	</xsl:template>

	<xsl:template match="Sach">
		<tr style="background-color: blanchedalmond;">
			<td>
				<xsl:number/>
			</td>
			<td>
				<xsl:value-of select="TenSach"/>
			</td>
			<td>
				<xsl:value-of select="SoTrang"/>
			</td>
			<td>
				<xsl:choose>
					<xsl:when test="SoTrang &lt;= 100">
						<xsl:value-of select="SoTrang * 4000"/>
					</xsl:when>
					<xsl:when test="SoTrang &gt; 100 and SoTrang &lt;= 150">
						<xsl:value-of select="100 * 4000 + (SoTrang - 100) * 3000"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="100 * 4000 + 50 * 3000 + (SoTrang - 150) * 2000"/>
					</xsl:otherwise>
				</xsl:choose>
			</td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
