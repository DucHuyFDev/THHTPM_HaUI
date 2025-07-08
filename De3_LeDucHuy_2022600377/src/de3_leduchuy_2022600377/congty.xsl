<?xml version="1.0" encoding="UTF-8"?>

<!--
    Document   : congty.xsl
    Created on : July 9, 2025, 4:58 AM
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
        <html>
            <head>
                <title>Document</title>
                <style>
                    .container{
                        width: 1000px;
                        margin: 0 auto;
                    }
                    h2{
                        text-align: center;
                        font-size: 25px;
                        color:brown;
                    }
                    h3{
                        font-size: 22px;
                        padding-left: 15px;
                    }
                    th,td{
                        min-width: 150px;
                    }
                </style>
            </head>
            <body>
                <div class="container">
                    <h2>CÔNG TY SẢN XUẤT</h2>
					<xsl:apply-templates select="CongTy/Phong"></xsl:apply-templates>
                </div>
            </body>
       </html>
    </xsl:template>
	<xsl:template match ="CongTy/Phong">
		<h3>
			Mã phòng: <xsl:value-of select="@MaPhong" />
		</h3>
		<h3>
			Điện thoại: <xsl:value-of select="DienThoai"/>
		</h3>
		<table border = "1" align="center" style="font-size: 20px;">
			<tr style="background-color: aqua;">
				<th>STT</th>
				<th>Mã sản phẩm</th>
				<th>Tên sản phẩm</th>
				<th>Giá tiền</th>
			</tr>
			<xsl:apply-templates select="SanPham">
				<xsl:sort select="GiaTien" order="ascending"/>
			</xsl:apply-templates>
		</table>
	</xsl:template>
	
	<xsl:template match="SanPham">
		<xsl:choose>
			<xsl:when test="GiaTien &lt;= 500">
				<tr style="color:blue">
					<td>
						<xsl:number value="position()" />
					</td>
					<td>
						<xsl:value-of select="MaSP"/>
					</td>
					<td>
						<xsl:value-of select="TenSP"/>
					</td>
					<td>
						<xsl:value-of select="GiaTien"/>
					</td>
				</tr>
			</xsl:when>
			<xsl:when test="GiaTien >= 700">
				<tr style="color:red">
					<td>
						<xsl:number value="position()" />
					</td>
					<td>
						<xsl:value-of select="MaSP"/>
					</td>
					<td>
						<xsl:value-of select="TenSP"/>
					</td>
					<td>
						<xsl:value-of select="GiaTien"/>
					</td>
				</tr>
			</xsl:when>
			<xsl:otherwise>
				<tr>
					<td>
						<xsl:number value="position()" />
					</td>
					<td>
						<xsl:value-of select="MaSP"/>
					</td>
					<td>
						<xsl:value-of select="TenSP"/>
					</td>
					<td>
						<xsl:value-of select="GiaTien"/>
					</td>
				</tr>
			</xsl:otherwise>
		</xsl:choose>
		
	</xsl:template>
</xsl:stylesheet>
