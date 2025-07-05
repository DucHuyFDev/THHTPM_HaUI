<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:bv="http://tempuri.org/MonHoc.xsd" exclude-result-prefixes="bv"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html>
			<head>
				<title>Document</title>
				<style>
					.container{
						width: 1200px;
						margin: 0 auto;
					}
					td{
						min-width: 250px;
					}
				</style>
			</head>
			<body>
				<div class="container">
					<h2 style="text-align: center;">DANH SÁCH MÔN HỌC</h2>
					<table border = "1" align="center">
						<tr style="background-color: aqua; font-weight: bold;">
							<th>Mã môn học</th>
							<th>Tên môn học</th>
							<th>Số giờ</th>
						</tr>
						<xsl:apply-templates select="bv:DS/bv:MonHoc">
						</xsl:apply-templates>
					</table>
				</div>
			</body>
		</html>
    </xsl:template>
	<xsl:template match="bv:DS/bv:MonHoc">
		<xsl:if test="bv:SoGio >= 40">
			<tr>
				<td>
					<xsl:value-of select="bv:MaMH"/>
				</td>
				<td>
					<xsl:value-of select="bv:TenMH"/>
				</td>
				<td>
					<xsl:value-of select="bv:SoGio"/>
				</td>
			</tr>
		</xsl:if>
		</xsl:template>
</xsl:stylesheet>
