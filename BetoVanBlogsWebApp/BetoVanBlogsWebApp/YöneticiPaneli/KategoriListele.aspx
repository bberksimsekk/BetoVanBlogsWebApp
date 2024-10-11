<%@ Page Language="C#" MasterPageFile="~/YöneticiPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="BetoVanBlogsWebApp.YöneticiPaneli.KategoriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/ListeSayfası.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="SayfaBaşlık">
        <h3>Kategoriler</h3>
    </div>
    <div class="tabloTasiyici">
        <%-- <asp:GridView ID="gv_kategoriler" runat="server"></asp:GridView>--%>
        <asp:ListView ID="lv_Kategoriler" runat="server" OnItemCommand="lv_Kategoriler_ItemCommand">
            <LayoutTemplate>
                <table cellspacing="0" cellpadding="0" class="tablo">
                    <tr>
                        <th>ID</th>
                        <th>İsim</th>
                        <th>Açıklama</th>
                        <th>Durum</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Aciklama") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td>
                        <a href='KategoriDuzenle.aspx?kategoriId=<%# Eval("ID") %>' class="TabloButon Düzenle">
                            <img src="resimler/edit.png" /></a>
                        <asp:LinkButton ID="lbtn_durum" runat="server" class="TabloButon Durum" CommandArgument='<%# Eval("ID") %>' CommandName="Durum">
                            <img src="AdminResimler/recycle.png" />
                        </asp:LinkButton>
                        <asp:LinkButton ID="lbtn_sil" runat="server" class="TabloButon Sil" CommandArgument='<%# Eval("ID") %>' CommandName="Sil"> 
                            <img src="resimler/delete.png" />
                        </asp:LinkButton>
                       
                    </td>
                </tr>
            </ItemTemplate>
           <%-- <AlternatingItemTemplate>
                <tr class="alternate">
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Aciklama") %></td>
                    <td>Durum</td>
                    <td></td>
                </tr>
            </AlternatingItemTemplate>--%>
        </asp:ListView>
    </div>
</asp:Content>