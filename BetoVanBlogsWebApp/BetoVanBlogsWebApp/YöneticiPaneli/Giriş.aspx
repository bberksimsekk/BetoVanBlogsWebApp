<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giriş.aspx.cs" Inherits="BetoVanBlogsWebApp.YöneticiPaneli.Giriş" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> BETO VAN Blogs Yönetici Paneline Giriş </title>
    <link href="CSS/GirişStil.css" rel="stylesheet" />
</head>
    <body>
    <form id="form1" runat="server">
        <div class="Taşıyıcı">
            <div class="Sol">
                <h3>Giriş Yapınız</h3>
                <div style="border-bottom:1px solid silver;padding-bottom:10px;margin:10px 0;"></div>
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="PanelBaşarısız" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server">Kullanıcı Bulunamadı</asp:Label>   
                </asp:Panel>
                <div class="Satır">
                    <label>Mail</label><br />
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="MetinKutu" placeholder="@gmail.com" Text="bberksmskk@gmail.com"></asp:TextBox>
                </div>
                <div class="Satır">
                    <label>Şifre</label><br />
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="MetinKutu" placeholder="123?***" TextMode="Password"></asp:TextBox>
                </div>
                <div class="Satır">
                    <asp:Button ID="btn_girisYap" runat="server" OnClick="btn_girisYap_Click" Text="Yönetici Giriş" CssClass="GirişButon" />
                </div>
                <div class="Satır">
                    <a href="../SifremiUnuttum.aspx">Şifremi Unuttum</a>
                </div>
            </div>
            <div class="Sağ">
                <h2 class="Başlık">Yönetici Giriş Paneline Hoşgeldiniz</h2>
                <br />
                <br />
                Bu Alandan Üye Girişi Yapılmamaktadır!
                <br />
                Üye Girişi Yapmak İçin
                <br />
                <br />
                <br />
                <a href="../UyeGiriş.aspx" class="ÜyeLink">Üye Giriş</a>
            </div>
            <div style="clear:both"></div>
        </div>
    </form>
</body>
</html>
