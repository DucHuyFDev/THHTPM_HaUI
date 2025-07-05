<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html>
			<head>
				<title>Document</title>
				<style>
					.container{
						width: 1000px;
						margin: 0 auto;
						text-align: center;
					}
					h2{
						color: #FF0000;
						font-size: 26px;
					}
					table{
						margin: 0 auto;
					}
					th,td{
						min-width: 200px;
						border: 1px solid black;
					}
					th {
						background-color: #FFb266;
					}
				</style>
			</head>
			<body>
				<div class="container">
					<h2>DANH SÁCH LỚP HỌC</h2>
					<table border="1">
						<tr>
							<th>Mã lớp</th>
							<th>Tên lớp</th>
						</tr>
						<xsl:apply-templates select="DS/Lop"></xsl:apply-templates>
					</table>
				</div>
			</body>
		</html>
    </xsl:template>
	<xsl:template match="DS/Lop">
		<tr>
			<td>
				<xsl:value-of select="MaLop"/>
			</td>
			<td>
				<xsl:value-of select="TenLop"/>
			</td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
