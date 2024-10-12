<%@ Page Language="C#" MasterPageFile ="~/ÜyePaneli/UyePanel.Master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="BetoVanBlogsWebApp.ÜyePaneli.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/ÜyeGiriş.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class="FormTaşıyıcı">
    <div class="FormBaşlık">
        <h3>Profil Ayarları</h3>
    </div>
    <div class="Formİçerik">
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="BaşarısızPanel" Visible="false">
            <asp:Label ID="lbl_hatamesaj" runat="server"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="pnl_basarili" runat="server" CssClass="BaşarılıPanel" Visible="false">
            <label>Profil başarıyla güncellenmiştir</label>
        </asp:Panel>
        <div class="Satır">
            <label class="FormEtiket">Kullanıcı Adı</label>
            <asp:TextBox ID="tb_kullaniciadi" runat="server" CssClass="MetinKutu"></asp:TextBox>
        </div>
        <div class="Satır">
            <label class="FormEtiket">İsim</label>
            <asp:TextBox ID="tb_isim" runat="server" CssClass="MetinKutu" ></asp:TextBox>
        </div>
        <div class="Satır">
            <label class="FormEtiket">Soyisim</label>
            <asp:TextBox ID="tb_soyisim" runat="server" CssClass="MetinKutu" ></asp:TextBox>
        </div>
        <div class="Satır">
            <label class="FormEtiket">E-mail</label>
            <asp:TextBox ID="tb_email" runat="server" CssClass="MetinKutu" ></asp:TextBox>
        </div>
        <div class="Satır">
            <label class="FormEtiket">Şifre</label>
            <asp:TextBox ID="tb_sifre" runat="server" CssClass="MetinKutu" TextMode="Password" ></asp:TextBox>
        </div>
        <div class="Satır">
            <label class="FormEtiket">Durum</label><br />
            <asp:CheckBox ID="cb_durum" runat="server"  />
            <small style="color: dimgray">(Eğer işaretli ise profil güncelleme aktif olur)</small>
        </div>
        <div class="Satır">
            <asp:Button ID="lbtn_ekle" runat="server" CssClass="FormButon" Text="Profil Güncelle" OnClick="lbtn_ekle_Click" />
        </div>
    </div>
</div>
</asp:Content>
