<%@ Page Language="C#" MasterPageFile="~/Arayuz.Master" AutoEventWireup="true" CodeBehind="Iletisim.aspx.cs" Inherits="BetoVanBlogsWebApp.Iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="CSS/Arayüz.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="İletişimSatır">
    <div class="İletişimSatır">
        <label>İLETİŞİM</label>
    </div>
    <div class="İletişimİçerik">
       <img src="Resimler/Icon/email.png" style="width:150px;height:120px" />
        <h3>betovanblogs@gmail.com</h3><br />
        <hr />
        <img src="Resimler/Icon/instagram.png" style="width:150px;height:120px" />
        <a href="#">BETO VAN Blogs</a><br />
        <hr />
       <img src="Resimler/Icon/facebook.png" style="width:150px;height:120px" />
        <a href="#">BETO VAN Blogs</a><br />
        <hr />
        <br />
        <p class="İletişimİçerik">Adres: Odunpazarı/Eskişehir</p>
        <hr />
    </div>
</div>
</asp:Content>
