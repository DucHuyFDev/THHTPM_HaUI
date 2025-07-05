<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:bv="http://tempuri.org/KetQua.xsd" exclude-result-prefixes="bv"
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
					<h2 style="text-align: center;">DANH SÁCH  ĐIỂM MÔN HỌC</h2>
					<table border = "1" align="center">
						<tr style="background-color: aqua; font-weight: bold;">
							<th>Mã sinh viên</th>
							<th>Mã môn học</th>
							<th>Điểm</th>
						</tr>
						<xsl:apply-templates select="bv:DS/bv:SV"></xsl:apply-templates>
					</table>

				</div>
			</body>
		</html>
    </xsl:template>
	<xsl:template match="bv:DS/bv:SV">
		<tr>
			<td>
				<xsl:value-of select="bv:MaSV"/>
			</td>
			<td>
				<xsl:value-of select="bv:MaMH"/>
			</td>
			<td>
				<xsl:value-of select="bv:Diem"/>
			</td>
			
		</tr>
	</xsl:template>
</xsl:stylesheet>
