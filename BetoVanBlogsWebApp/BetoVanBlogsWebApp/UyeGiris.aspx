<%@ Page Language="C#" MasterPageFile="~/Arayuz.Master" AutoEventWireup="true" CodeBehind="UyeGiris.aspx.cs" Inherits="BetoVanBlogsWebApp.UyeGiris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Arayüz.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Taşıyıcı">
        <div class="GirişKutu">
            <div class="Başlık">
                <h2>BETO VAN Blogs Web'e Hoş Geldiniz</h2>
                <h3>Üye Girişi</h3>
            </div>
            <div class="GirişForm">
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="BaşarısızPanel" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                </asp:Panel>
                <div class="Satır">
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="FormMetinKutu" placeholder="Mail Adresiniz"></asp:TextBox>
                </div>
                <div class="Satır">
                    <asp:TextBox ID="tb_sifre" TextMode="Password" runat="server" CssClass="FormMetinKutu" placeholder="Şifreniz"></asp:TextBox>
                </div>
                <div class="Satır" style="margin-top:20px">
                    <asp:LinkButton ID="lbtn_giris" runat="server" OnClick="lbtn_giris_Click" CssClass="FormGirişButon">Üye Girişi Yap</asp:LinkButton>
                </div>
                <div class="Satır" style="margin-top:10px">
                    <a href="SifremiUnuttum.aspx" style="float: right;color:black">Şifremi Unuttum :/</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>