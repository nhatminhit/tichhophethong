<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
			xmlns:a="http://tempuri.org/Chamcong.xsd"	
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html>
			<head>
				<title>Bang cham cong</title>
			</head>
			<body>
				<h2>BANG CHAM CONG	</h2>
				<xsl:for-each select="a:Chamcong/a:Ngaylamviec">
				<p>Ngay lam viec: <xsl:value-of select="@Ngay"/>
			</p>
				<table border="1" cellspacing="0">
					<tr>
						<td>STT</td>
						<td>MaNV</td>
						<td>Ca lam viec</td>
						<td>Gio vao</td>
						<td>Gio ra</td>
						<td>Lam muon</td>
					</tr>
					<xsl:for-each select="a:Nhanvien">
					<tr>
						<td>
							<xsl:value-of select="position()"/>
						</td>
						<td>
							<xsl:value-of select="@Manv"/>
						</td>
						<td>
							<xsl:value-of select="a:Calamviec"/>
						</td>
						<td>
							<xsl:value-of select="a:Giovao"/>
						</td>
						<td>
							<xsl:value-of select="a:Giora"/>
						</td>
						<td>
							<xsl:if test="a:Calamviec = 'C3'">X</xsl:if>
						</td>
					</tr>
						
					</xsl:for-each>
				</table>
				</xsl:for-each>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
