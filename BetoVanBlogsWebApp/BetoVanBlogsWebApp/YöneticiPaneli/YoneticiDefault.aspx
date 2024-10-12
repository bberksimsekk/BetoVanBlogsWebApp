<%@ Page Language="C#" MasterPageFile="~/YöneticiPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="YoneticiDefault.aspx.cs" Inherits="BetoVanBlogsWebApp.YöneticiPaneli.YoneticiDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormSayfası.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="YönetimPaneli">
        <div class="Panel YöneticiSayısı">
            <a href="YoneticiIslemleri.aspx"><img src="AdminResimler/admin.png" class="Icon" /></a>
            <p>Admin</p>
            <asp:Label ID="lblYoneticiSayisi" runat="server"></asp:Label>
        </div>
        <div class="Panel MakaleSayısı">
            <a href="MakaleListele.aspx"><img src="AdminResimler/list.png" class="Icon"/></a>
            <p>Makale</p>
            <asp:Label ID="lblMakaleSayisi" runat="server"></asp:Label>
        </div>
        <div class="Panel YorumSayısı">
            <a href="Yorumlar.aspx"><img src="AdminResimler/comment.png" class="Icon" /></a>
            <p>Yorum</p>
            <asp:Label ID="lblYorumSayisi" runat="server"></asp:Label>
        </div>
        <div class="Panel ÜyeSayısı">
            <a href="Uyeler.aspx"> <img src="AdminResimler/team.png" class="Icon" /></a>
            <p>Üye</p>
            <asp:Label ID="lblUyeSayisi" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>