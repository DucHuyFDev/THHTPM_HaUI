<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:bv="http://tempuri.org/BenhNhan.xsd" exclude-result-prefixes="bv"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<head>
			<title>Document</title>
			<style>
				.container{
					width: 1200px;
					margin: 0 auto;
				}
				h2{
					color: red;
					text-align: center;
				}
				.khoa_in4, .benh_nhan_in4{
					font-size: 20px;
				}
				.benh_nhan_in4 th{
					min-width: 150px;
				}

			</style>
		</head>
		<body>
			<div class="container">
				<p style="font-size: 20px;">
					<b>BỆNH VIỆN ĐA KHOA</b></p>
				<h2 style="font-size: 40px;">DANH SÁCH BỆNH NHÂN</h2>
				<xsl:apply-templates select="bv:BVDK/bv:Khoa"></xsl:apply-templates>
			</div>
		</body>
    </xsl:template>
	
	
	<xsl:template match="bv:BVDK/bv:Khoa">
		<table class="khoa_in4">
			<tr>
				<td style="padding-right: 70px;">
					Khoa: <xsl:value-of select="bv:TenKhoa"/>
				</td>
				<td>
					Phòng:<xsl:value-of select="bv:Phong"/>
				</td>
			</tr>
		</table>
		<br></br>
		<br></br>
		<table align="center" border="1" class="benh_nhan_in4" >
			<tr style="background-color: aquamarine;">
				<th>Mã số BN</th>
				<th>Họ tên</th>
				<th>Ngày nhập viện</th>
				<th>Số ngày điều trị</th>
				<th>Số tiền phải trả</th>
			</tr>
			<xsl:apply-templates select="bv:BenhNhan">
				<xsl:sort select="@MasoBN"></xsl:sort>
			</xsl:apply-templates>
		</table>
	</xsl:template>

	<xsl:template match="bv:BenhNhan">
		<tr>
			<td>
				<xsl:value-of select="@MasoBN"/>
			</td>
			<td>
				<xsl:value-of select="bv:HoTen"/>
			</td>
			<td>
				<xsl:value-of select ="bv:NgayNhapVien"/>
			</td>
			<td>
				<xsl:value-of select ="bv:NgayDieuTri"/>
			</td>
			<td>
				<xsl:value-of select ="bv:NgayDieuTri * 15000"/>
			</td>
		</tr>
		
	</xsl:template>
</xsl:stylesheet>
