<%@ Page Language="C#" MasterPageFile="~/YöneticiPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="Yorumlar.aspx.cs" Inherits="BetoVanBlogsWebApp.YöneticiPaneli.Yorumlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FormSayfası.css" rel="stylesheet" />
    <link href="CSS/ListeSayfası.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormTaşıyıcı">
        <div class="FormBaşlık">
            <h3>Yorumlar</h3>
        </div>
        <asp:ListView ID="lv_yorumlar" runat="server" OnItemCommand="lv_yorumlar_ItemCommand">
            <LayoutTemplate>
                <table cellpading="0" cellpacing="0" class="Tablo">
                    <tr>
                        <th style="text-align: center">ID</th>
                        <th>Makale ID</th>
                        <th>Üye ID</th>
                        <th>İçerik</th>
                        <th>Tarih</th>
                        <th>Durum</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center"><%# Eval("ID") %></td>
                    <td><%# Eval("MakaleID") %></td>
                    <td><%# Eval("UyeID") %></td>
                    <td><%# Eval("Icerik") %></td>
                    <td><%# Eval("EklemeTarihi") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="TabloButon Sil" CommandArgument='<%# Eval("ID") %>' CommandName="Sil"><img src="AdminResimler/delete.png"  class="İcon"/></asp:LinkButton>
                        <asp:LinkButton ID="lbtn_durum" runat="server" CssClass="TabloButon Düzenle" CommandArgument='<%# Eval("ID") %>' CommandName="Durum"><img src="AdminResimler/edit.png" class="İcon" /></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
