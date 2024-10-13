<%@ Page Language="C#" MasterPageFile="~/Arayuz.Master" AutoEventWireup="true" CodeBehind="UyeOl.aspx.cs" Inherits="BetoVanBlogsWebApp.ÜyeOl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Arayüz.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Taşıyıcı">
        <div class="GirişKutu">
            <div class="Başlık">
                <h2>BETO VAN Blogs Web'e Hoş Geldiniz</h2>
                <h3>Kayıt Ol</h3>
            </div>
            <div class="ÜyeFormİçerik">
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="BaşarısızPanel" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnl_basarili" runat="server" CssClass="BaşarılıPanel" Visible="false">
                    <label>Üyelik başarıyla oluşturulmuştur</label>
                </asp:Panel>
                <div class="Satır">
                    <label class="ÜyeFormEtiket">İsim</label>
                    <asp:TextBox ID="tb_isim" runat="server" CssClass="MetinKutu" placeholder="İsminiz"></asp:TextBox>
                </div>
                <div class="Satır">
                    <label class="ÜyeFormEtiket">Soyisim</label>
                    <asp:TextBox ID="tb_soyisim" runat="server" CssClass="MetinKutu" placeholder="Soyisminiz"></asp:TextBox>
                </div>
                <div class="Satır">
                    <label class="ÜyeFormEtiket">Kullanıcı Adı</label>
                    <asp:TextBox ID="tb_kullanici" runat="server" CssClass="MetinKutu" placeholder="Kullanıcı Adınız"></asp:TextBox>
                </div>
                <div class="Satır">
                    <label class="ÜyeFormEtiket">E-mail</label>
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="MetinKutu" placeholder="E-mail"></asp:TextBox>
                </div>
                <div class="Satır">
                    <label class="ÜyeFormEtiket">Şifre</label>
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="MetinKutu" placeholder="Şifreniz" TextMode="Password"></asp:TextBox>
                </div>
                <asp:CheckBox ID="cb_durum" runat="server" /><small style="color:white">(Eğer işaretli ise üyelik aktif olur)</small>
                <asp:Button ID="btn_tikla" runat="server" Text="Üyelik Oluştur" CssClass="TıklaButon" OnClick="btn_tikla_Click" />
            </div>
        </div>
    </div>
</asp:Content>