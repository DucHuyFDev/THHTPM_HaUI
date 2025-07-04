<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html>
			<head>
				<title>PHIẾU MUA HÀNG</title>
			</head>
			<body>
				<table border="0">
					<tr>
						<td>
							<b>Hóa đơn: </b>
							<xsl:value-of select="DS/HoaDon/MaHD"/>
						</td>
						<td>
							<b>Ngày bán: </b>
							<xsl:value-of select="DS/HoaDon/NgayBan"/>
						</td>
					</tr>
					<tr>
						<td colspan ="2">
							<b>Loại hàng: </b>
							<xsl:value-of select="DS/HoaDon/LoaiHang/@TenLoai"/>
						</td>
					</tr>
				</table>
				<br></br>
				<table border ="1">
					<tr>
						<th>Mã hàng</th>
						<th>Tên hàng</th>
						<th>Số lượng</th>
						<th>Đơn vị tính</th>
						<th>Đơn giá</th>
					</tr>
					<xsl:apply-templates select="DS/HoaDon/LoaiHang/Hang"/>
				</table>
			</body>
		</html>
		
    </xsl:template>
	<xsl:template match="DS/HoaDon/LoaiHang/Hang">
		<xsl:if test="DonGia > 5000000">
			<tr>
				<td>
					<xsl:value-of select="@MaHang"/>
				</td>
				<td>
					<xsl:value-of select="TenHang"/>
				</td>
				<td>
					<xsl:value-of select="SoLuong"/>
				</td>
				<td>
					<xsl:value-of select="DonViTinh"/>
				</td>
				<td>
					<xsl:value-of select="DonGia"/>
				</td>
			</tr>
		</xsl:if>
	</xsl:template>
</xsl:stylesheet>
