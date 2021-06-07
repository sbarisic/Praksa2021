﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UserWork.aspx.cs" Inherits="PraksaFront.UserWork" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
<link rel="stylesheet" href="content/css/home.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
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

            <div class="card-header">
            <h1>Radne akcije</h1>
        </div>
        <div class="card-body">
            <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                <div class="dataTable-container">
                    <table class="dataTable-table">
                <tr>
                    <th width="200px"><asp:Label runat="server" Text="Radna Akcija"></asp:Label>
                    </th>
                    <th><asp:Label runat="server" Text="Opis"></asp:Label></th>
                    <th><asp:Label runat="server" Text="Datum"></asp:Label>
                    </th>
                    <th><asp:Label runat="server" Text="Vrijeme"></asp:Label>
                    </th>
                    <th><asp:Label runat="server" Text="Lokacija"></asp:Label>
                    </th>
                    <th><asp:Label runat="server" Text="Obveznost"></asp:Label></th>
                    <th><asp:Label runat="server" Text="Prisutnost"></asp:Label>
                    </th>
                </tr>
                <asp:Repeater ID="UserWorkList" runat="server" ItemType="System.String">
                    <ItemTemplate>
                        <tr>
                            <td><asp:Label runat="server" Text="<%# Item %>"></asp:Label></td>
                                    <td><asp:Label runat="server" Text="Košnja parka pomoću motorne kosilice"></asp:Label></td>
                                    <td><asp:Label runat="server" Text="25.06.2020"></asp:Label></td>
                                    <td><asp:Label runat="server" Text="16:45"></asp:Label></td>
                            <td>
                                <asp:Button CssClass="locationButton" ID="Button1" runat="server" Text="Ul. Ivana Gundulića 6" OnClick="locButton_Click" />
                            <td><asp:Label runat="server" Text="Obavezno"></asp:Label></td>
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
        </div>
        </div>
    </form>
</asp:Content>
