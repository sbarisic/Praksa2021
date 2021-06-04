﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AdminWork.aspx.cs" Inherits="PraksaFront.AdminWork" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <table style="margin: 0 auto;">
            <tr>
                <td>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>

                    <asp:HiddenField ID="hdnField" runat="server" />
                    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panl1" TargetControlID="hdnField"
                        CancelControlID="Button2" BackgroundCssClass="Background">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
                        <iframe src="<%= url%>" width="100%" height="490px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
                        <br />
                        <asp:Button ID="Button2" runat="server" Text="Zatvori" />
                    </asp:Panel>

                    <table class="styled-table">
                        <tr>
                            <th width="200px">Radna Akcija
                            </th>
                            <th>Opis</th>
                            <th>Datum
                            </th>
                            <th>Vrijeme
                            </th>
                            <th>Lokacija
                            </th>
                            <th>Obveznost</th>
                            <th>Uredi
                            </th>
                        </tr>
                        <asp:Repeater ID="UserWorkList" runat="server" ItemType="System.String">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Item %></td>
                                    <td>Košnja parka pomoću motorne kosilice</td>
                                    <td>25.06.2020</td>
                                    <td>16:45</td>
                                    <td>
                                        <asp:Button CssClass="locationButton" ID="Button1" runat="server" Text="Ul. Ivana Gundulića 6" OnClick="locButton_Click" /></td>
                                    <td>Obavezno</td>
                                    <td>
                                        <asp:Button ID="yesButton" CssClass="workButton" runat="server" Text="Uredi"
                                            OnCommand="edit_Command" CommandArgument="<%# Item %>" />
                                        <asp:Button ID="noButton" CssClass="workButton" runat="server" Text="Obriši"
                                            OnCommand="delete_Command" CommandArgument="<%# Item %>" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                </td>
                <td>
                    <div style="padding: 20px;">
                        <asp:Button CssClass="workButton" ID="addWorkButton" runat="server" Text="Dodaj akciju" />
                    </div>
                </td>
            </tr>
        </table>
    </form>


</asp:Content>
