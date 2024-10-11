<%@ Page Language="C#" MasterPageFile="~/YöneticiPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="MakaleListele.aspx.cs" Inherits="BetoVanBlogsWebApp.YöneticiPaneli.MakaleListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/ListeSayfası.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="SayfaBaşlık">
        <h3>Makaleler</h3>
    </div>
    <div class="TabloTaşıyıcı">
        <asp:ListView ID="lv_Makaleler" runat="server" OnItemCommand="lv_Makaleler_ItemCommand">
            <LayoutTemplate>
                <table cellspacing="0" cellpadding="0" class="Tablo">
                    <tr>
                        <th>Görsel</th>
                        <th>ID</th>
                        <th>Başlık</th>
                        <th>Kategori</th>
                        <th>Yazar</th>
                        <th>Ekleme Tarih</th>
                        <th>Görüntüleme Sayısı</th>
                        <th>Durum</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <img src='../Resimler/MakaleResimleri/<%# Eval("KapakResim") %>' width="100" />
                    </td>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Baslik") %></td>
                    <td><%# Eval("Kategori") %></td>
                    <td><%# Eval("Yazar") %></td>
                    <td><%# Eval("EklemeTarihi") %></td>
                    <td><%# Eval("GoruntulemeSayisi") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td>
                        <a href='MakaleDuzenle.aspx?makaleId=<%# Eval("ID") %>' class="TabloButon Düzenle">
                            <img src="adminResimler/edit.png" class="edit" /></a>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Sil" class="TabloButon Sil">
                          <img src="adminResimler/delete.png" class="delete"/>
                    </asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
