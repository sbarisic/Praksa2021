﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UserWork.aspx.cs" Inherits="PraksaFront.UserWork" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <body>
        <form id="form1" runat="server">
            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

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
                        <th>Prisutnost
                        </th>
                    </tr>

                    <asp:Repeater ID="UserWorkList" runat="server" ItemType="System.String">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Item %>
                                <td>Košnja parka pomoću motorne kosilice</td>
                                <td>25.06.2020</td>
                                <td>16:45</td>
                                 <td>
                                <asp:Button CssClass="locationButton" ID="Button1" runat="server" Text="Bjelovar" /></td>
                                <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Button1"
                                    CancelControlID="Button2" BackgroundCssClass="Background">
                                </cc1:ModalPopupExtender>
                                <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
                                    <iframe style="width: 850px; height: 550px;" id="irm1" src="LocationPopup.aspx" runat="server"></iframe>
                                    <br />
                                    <asp:Button ID="Button2" runat="server" Text="Zatvori" />
                                </asp:Panel>
                                <td>Obavezno</td>
                                <td>
                                    <asp:Button ID="yesButton" CssClass="workButton" runat="server" Text="Dolazim"
                                        OnCommand="yes_Command" CommandArgument="<%# Item %>" />
                                    <asp:Button ID="noButton" CssClass="workButton" runat="server" Text="Ne dolazim"
                                        OnCommand="no_Command" CommandArgument="<%# Item %>" />
                                    <asp:Button ID="maybeButton" CssClass="workButton" runat="server" Text="Mozda dolazim"
                                        OnCommand="maybe_Command" CommandArgument="<%# Item %>" /></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </form>
    </body>
    </html>

</asp:Content>