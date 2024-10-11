<%@ Page Language="C#" MasterPageFile="~/YöneticiPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="MakaleEkle.aspx.cs" Inherits="BetoVanBlogsWebApp.YöneticiPaneli.MakaleEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormSayfası.css" rel="stylesheet" />
    <script src="ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormTaşıyıcı">
        <div class="FormBaşlık">
            <h3>Makale Ekle</h3>
        </div>
        <div class="Formİçerik">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="BaşarılıPanel" Visible="false">
                <strong>Başarılı!</strong> Makale Başarıyla Eklenmiştir
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="BaşarısızPanel" Visible="false">
                <strong>Başarısız!</strong>
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div style="float: left; width: 690px">
                <div class="Satır">
                    <label>Makale Başlığı</label><br />
                    <asp:TextBox ID="tb_baslik" runat="server" CssClass="BölünmüşMetinKutu"></asp:TextBox>
                </div>
                <div class="Satır">
                    <label>Makale Kategorisi</label><br />
                    <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="BölünmüşMetinKutu" Style="width: 660px" DataTextField="Isim" DataValueField="ID">
                    </asp:DropDownList>
                </div>
                <div class="Satır">
                    <label>Kapak Resim</label><br />
                    <asp:FileUpload ID="fu_resim" runat="server" CssClass="BölünmüşMetinKutu" />
                </div>
                <div class="Satır">
                    <asp:CheckBox ID="cb_yayinla" runat="server" Text="  Makaleyi Yayınla" />
                </div>
                <div class="Satır">
                    <asp:LinkButton ID="lbtn_makaleEkle" runat="server" CssClass="İşlemButon" OnClick="lbtn_makaleEkle_Click">Makale Ekle</asp:LinkButton>
                </div>
            </div>
            <div style="float: left; width: 400px">
                <div class="Satır">
                    <label>Makale Özet</label><br />
                    <asp:TextBox ID="tb_ozet" runat="server" TextMode="MultiLine" CssClass="MetinKutu"></asp:TextBox>
                </div>
                <div class="Satır">
                    <label>Makale İçerik</label><br />
                    <asp:TextBox ID="tb_icerik" runat="server" TextMode="MultiLine" CssClass="MetinKutu"></asp:TextBox>
                    <script>
                        CKEDITOR.replace('ContentPlaceHolder1_tb_icerik');
                 </script>
                </div>
            </div>
            <div style="clear: both"></div>
        </div>
    </div>
</asp:Content>

