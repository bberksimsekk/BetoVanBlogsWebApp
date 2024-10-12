﻿<%@ Page Language="C#" MasterPageFile ="~/ÜyePaneli/UyePanel.Master" AutoEventWireup="true" CodeBehind="Yorumlar.aspx.cs" Inherits="BetoVanBlogsWebApp.ÜyePaneli.Yorumlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/ÜyeGiriş.css" rel="stylesheet" />
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
                    <td><%# Eval("Icerik") %></td>
                    <td><%# Eval("EklemeTarihi") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="sil"><img src="../YoneticiPanel/AdminResimler/delete.png" class="Delete" /></asp:LinkButton>
                        <asp:LinkButton ID="lbtn_durum" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="durum"><img src="../YoneticiPanel/AdminResimler/edit.png" class="Edit" /></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>