<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:output method="html"/>
    <xsl:template match="/">
		<html lang="en">
			<head>
				<title>Quản lý nhà sách</title>
				<style>
					.container{
						width: 1200px;
						margin: 0 auto;
					}

					h2{
						text-align: center;
						font-size: 28px;
						color: red;
					}
					th,td{
						min-width: 100px;
					}
				</style>
			</head>
			<body>
				<div class="container">
					<h2>NHÀ SÁCH</h2>
					<table border ="1" align="center" style="font-size: 20px;">
						<tr style="background-color: aquamarine;">
							<th>STT</th>
							<th>Mã sách</th>
							<th>Tên sách</th>
							<th>Số trang</th>
							<th>Tác giả</th>
							<th>Giá tiền</th>
						</tr>
						<xsl:apply-templates select="nhasach/cuonsach">
							<xsl:sort select="sotrang" order="descending"/>
						</xsl:apply-templates>
					</table>
				</div>
			</body>
		</html>
    </xsl:template>
	<xsl:template match="nhasach/cuonsach">
		<tr>
			<td>
				<xsl:number/>
			</td>
			<td>
				<xsl:value-of select="masach"/>
			</td>
			<td>
				<xsl:value-of select="tensach"/>
			</td>
			<td>
				<xsl:value-of select="sotrang"/>
			</td>
			<td>
				<xsl:value-of select="tacgia/HoTen"/>
			</td>
			<td>
				<xsl:choose>
					<xsl:when test="sotrang &gt;= 200">
						<xsl:value-of select="sotrang*700"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="sotrang*1000"/>
					</xsl:otherwise>
				</xsl:choose>
			</td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
