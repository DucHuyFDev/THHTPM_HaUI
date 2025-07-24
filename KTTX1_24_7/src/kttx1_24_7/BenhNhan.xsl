<?xml version="1.0" encoding="UTF-8"?>

<!--
    Document   : BenhNhan.xsl
    Created on : July 24, 2025, 8:57 AM
    Author     : admin
    Description:
        Purpose of transformation follows.
-->

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:output method="html"/>

    <!-- TODO customize transformation rules 
         syntax recommendation http://www.w3.org/TR/xslt 
    -->
    <xsl:template match="/">
		<html lang="en">
			<head>
				<title>Document</title>
				<style>
					.container{
					width: 1200px;
					margin: 0 auto;
					}
					h1{
					text-align: center;
					color: red;
					}
					p{
					font-size: 20px;
					}
					table{
					border-collapse: collapse;
					font-size: 20px;
					background-color: aquamarine;
					}
					tr,td{
					min-width: 200px;
					text-align: center;
					}
					#name{
					color: red;
					font-weight: bold;
					font-style: italic;
					}
					th{
					font-weight: bold;
					}
				</style>
			</head>
			<body>
				<div class="container">
					<h1>BẢNG CHI TRẢ VIỆN PHÍ</h1>
					<p>
						<b>Tên bệnh viện: </b>
						<xsl:value-of select="DS/@tenbv"/>
					</p>
					<xsl:apply-templates select="DS/khoa"></xsl:apply-templates>
				</div>
			</body>
		</html>
    </xsl:template>
	<xsl:template match="DS/khoa">	
		<p>
			<b>Tên khoa khám: </b>
			<xsl:value-of select="tenkhoa"/>
		</p>
		<table border="1" align="center">
			<tr>
				<th>STT</th>
				<th>Họ tên</th>
				<th>Số ngày nằm viện</th>
				<th>Viện phí</th>
			</tr>
			<xsl:apply-templates select="benhnhan"></xsl:apply-templates>
		</table>
	</xsl:template>
	<xsl:template match="benhnhan">
		<tr>
			<td>
				<xsl:number/>
			</td>
			<td id="name">
				<xsl:value-of select="hoten"/>
			</td>
			<td>
				<xsl:value-of select="@songay"/>
			</td>
			<td>
				<xsl:choose>
					<xsl:when test="@songay &lt;= 10">
						<xsl:value-of select="@songay * 100000"/>
					</xsl:when>
					<xsl:when test="@songay &lt;= 20">
						<xsl:value-of select="10 * 100000 + (@songay - 10) * 120000"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select ="10 * 100000 + 10 * 120000 + (@songay - 20) * 200000"/>
					</xsl:otherwise>
				</xsl:choose>
			</td>
		</tr>
	</xsl:template>

</xsl:stylesheet>
