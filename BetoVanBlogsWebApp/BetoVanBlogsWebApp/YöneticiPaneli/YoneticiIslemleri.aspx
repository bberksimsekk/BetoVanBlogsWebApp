<%@ Page Language="C#" MasterPageFile="~/YöneticiPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="YoneticiIslemleri.aspx.cs" Inherits="BetoVanBlogsWebApp.YöneticiPaneli.YöneticiIslemleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormSayfası.css" rel="stylesheet" />
    <link href="Css/ListeSayfası.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormTaşıyıcı">
        <div class="FormBaşlık">
            <h3>Admin Ekle</h3>
        </div>
        <div class="Formİçerik">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="BaşarısızPanel" Visible="false">
                <asp:Label ID="lbl_hatamesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="BaşarılıPanel" Visible="false">
                <label>Ekleme Başarılı</label>
            </asp:Panel>
            <div class="Satır">
                <label class="Formetiket">Yönetici Türü</label>
                <asp:RadioButtonList ID="rb_YoneticiTur_ID" runat="server" CssClass="MetinKutu">
                    <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="Satır">
                <label class="FormEtiket">İsim</label>
                <asp:TextBox ID="tb_isim" runat="server" CssClass="MetinKutu"></asp:TextBox>
            </div>
            <div class="Satır">
                <label class="FormEtiket">Soyisim</label>
                <asp:TextBox ID="tb_soyisim" runat="server" CssClass="MetinKutu"></asp:TextBox>
            </div>
            <div class="Satır">
                <label class="FormEtiket">Kullanıcı Adı</label>
                <asp:TextBox ID="tb_kullaniciadi" runat="server" CssClass="MetinKutu"></asp:TextBox>
            </div>
            <div class="Satır">
                <label class="FormEtiket">E-mail</label>
                <asp:TextBox ID="tb_mail" runat="server" CssClass="MetinKutu"></asp:TextBox>
            </div>
            <div class="Satır">
                <label class="FormEtiket">Şifre</label>
                <asp:TextBox ID="tb_sifre" runat="server" CssClass="MetinKutu" TextMode="Password"></asp:TextBox>
            </div>
            <div class="Satır">
                <label class="FormEtiket"></label>
                <br />
                <asp:CheckBox ID="cb_durum" runat="server" Text=" Yayınla" />
                <small style="color: dimgray">(Eğer işaretlenirse admin aktif olur)</small>
            </div>
            <div class="Satır">
                <asp:Button ID="lbtn_ekle" runat="server" CssClass="İşlemButon" Text="Admin Ekle" OnClick="lbtn_ekle_Click" />
            </div>
        </div>
    </div>
    <br />
    <div class="FormTaşıyıcı">
        <div class="FormBaşlık">
            <h3>Kullanıcılar</h3>
        </div>
        <asp:ListView ID="lv_kullanicilar" runat="server" OnItemCommand="lv_kullanicilar_ItemCommand">
            <LayoutTemplate>
                <table cellpadding="0" cellspacing="0" class="Tablo">
                    <tr>
                        <th style="text-align: center">ID</th>
                        <th>Yönetici Tür ID</th>
                        <th>Isim</th>
                        <th>Soyisim</th>
                        <th>Kullanıcı Adı</th>
                        <th>Mail</th>
                        <th>Durum</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center"><%# Eval("ID") %></td>
                    <td><%# Eval("YoneticiTurID") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Soyisim") %></td>
                    <td><%# Eval("KullaniciAdi") %></td>
                    <td><%# Eval("Mail") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Sil"><img src="AdminResimler/delete.png" class="Sil"/></asp:LinkButton>
                        <asp:LinkButton ID="lbtn_durum" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Durum"><img src="AdminResimler/edit.png" class="Düzenle" /></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <br />
    <div class="FormTaşıyıcı">
        <div class="FormBaşlık">
            <h3>Profil Ayarları</h3>
        </div>
        <div class="Formİçerik">
            <asp:Panel ID="Panel1" runat="server" CssClass="BaşarısızPanel" Visible="false">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" CssClass="BaşarılıPanel" Visible="false">
                <label>Profil başarıyla güncellenmiştir</label>
            </asp:Panel>
            <div class="Satır">
                <label class="FormEtiket">Kullanıcı Adı</label>
                <asp:TextBox ID="td_kullaniciadi" runat="server" CssClass="MetinKutu"></asp:TextBox>
            </div>
            <div class="Satır">
                <label class="FormEtiket">İsim</label>
                <asp:TextBox ID="td_isim" runat="server" CssClass="MetinKutu"></asp:TextBox>
            </div>
            <div class="Satır">
                <label class="FormEtiket">Soyisim</label>
                <asp:TextBox ID="td_soyisim" runat="server" CssClass="MetinKutu"></asp:TextBox>
            </div>
            <div class="Satır">
                <label class="FormEtiket">Mail</label>
                <asp:TextBox ID="td_email" runat="server" CssClass="MetinKutu"></asp:TextBox>
            </div>
            <div class="Satır">
                <label class="FormEtiket">Şifre</label>
                <asp:TextBox ID="td_sifre" runat="server" CssClass="MetinKutu" TextMode="Password"></asp:TextBox>
            </div>
            <div class="Satır">
                <label class="FormEtiket">Durum</label><br />
                <asp:CheckBox ID="cd_durum" runat="server" />
                <small style="color: dimgray">(Eğer işaretli ise profil güncelleme aktif olur)</small>
            </div>
            <div class="Satır">
                <asp:Button ID="lbtn_profil" runat="server" CssClass="İşlemButon" Text="Profil Güncelle" OnClick="lbtn_profil_Click" />
            </div>
        </div>
    </div>

</asp:Content>