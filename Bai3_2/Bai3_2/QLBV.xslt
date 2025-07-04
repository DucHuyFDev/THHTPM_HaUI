<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:bv="http://tempuri.org/QLBV.xsd" exclude-result-prefixes="bv"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html>
			<head>
				<title>Quản lý bệnh nhân</title>
			</head>
			<body>
				<h1>
					<b>BỆNH VIỆN ĐA KHOA					DANH SÁCH BỆNH NHÂN</b>
				</h1>
				<h2>
					Khoa: <xsl:value-of select="bv:Khoa/bv:TenKhoa"/>
				</h2>
				<br></br>
				<table border ="1">
					<tr>
						<th>STT</th>
						<th>Họ tên</th>
						<th>Ngày nhập viện</th>
						<th>Số ngày điều trị</th>
						<th>Số tiền phải trả</th>
					</tr>
					<xsl:apply-templates select="bv:Khoa/bv:DSBN/bv:BenhNhan"/>
				</table>
			</body>
		</html>
	</xsl:template>
		
	<xsl:template match="bv:BenhNhan">
		<tr>
			<td>
				<xsl:number/>
			</td>
			<td>
				<xsl:value-of select="bv:HoTen"/>
			</td>
			<td>
				<xsl:value-of select="bv:NgayNV"/>
			</td>
			<td>
				<xsl:value-of select="bv:SoNgayNV"/>
			</td>
			<td>
				<xsl:value-of select="bv:SoNgayNV * 15000"/>
			</td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
