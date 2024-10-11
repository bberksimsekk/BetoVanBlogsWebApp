<%@ Page Language="C#" MasterPageFile="~/YöneticiPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="KategoriDuzenle.aspx.cs" Inherits="BetoVanBlogsWebApp.YöneticiPaneli.KategoriDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormSayfası.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormTaşıyıcı">
        <div class="FormBaşlık">
            <h4>Kategori Düzenle</h4>
        </div>
        <div class="Formİçerik">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="BaşarılıPanel" Visible="false">
                <strong>Başarılı!</strong> Kategori Başarıyla Düzenlenmiştir
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="BaşarısızPanel" Visible="false">
                <strong>Başarısız!</strong>
                <asp:Label ID="lbl_mesaj" runat="server">Bişi Bişi</asp:Label>
            </asp:Panel>
            <div class="Satır">
                <label>Kategori Adı</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="MetinKutu"></asp:TextBox>
            </div>
            <div class="Satır">
                <label>Kategori Açıklama</label><br />
                <asp:TextBox ID="tb_aciklama" runat="server" CssClass="MetinKutu" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="Satır">
                <asp:CheckBox ID="cb_aktif" runat="server" Text="  Kategori Aktif" />
            </div>
            <div class="Satır">
                <asp:LinkButton ID="lbtn_duzenle" runat="server" CssClass="İşlemButon" OnClick="lbtn_duzenle_Click">Kategori Düzenle</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>