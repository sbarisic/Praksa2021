﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AdminPermitNames.aspx.cs" Inherits="PraksaFront.AdminPermits" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
    <style>
    .Popup {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: black;
        padding-top: 10px;
        width: 410px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <script>
        function hideEditModalPopup() {
            $find("ModalPopupExtender1").hide();
            return false;
        }
</script>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hdnField" runat="server" />
        <cc1:ModalPopupExtender BehaviorID="ModalPopupExtender1" ID="ModalPopupExtender1" runat="server" PopupControlID="Panl2" TargetControlID="hdnField" CancelControlID="ButtonClose" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
        <asp:Panel ID="Panl2" runat="server" CssClass="Popup" align="center" Style="display: none">
                <iframe src="AddPermitName.aspx" width="100%" height="200px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
            <asp:Button ID="ButtonClose" runat="server" Text="Zatvori" />
        </asp:Panel>

        <table style="margin: 0 auto;">
            <tr>
                <td>
                    <div class="card-header">
                    <h1>Dozvole</h1>
                    </div>
        <div class="card-body">
            <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                <div class="dataTable-container">
                    <table class="dataTable-table">
                        <tr>
                            <th>Naziv dozvole
                            </th>
                        </tr>
                        <asp:Repeater ID="PermitRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("name")%></td>
                                    <td>
                                        <asp:Button CssClass="workButton" ID="DeleteWork" runat="server" Text="Obriši" /></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
                </td>
                <td>
                    <div style="padding: 20px;">
                        <asp:Button CssClass="workButton" ID="addPermitBtn" OnClick="addPermitBtn_Click" runat="server" Text="Dodaj dozvolu" />
                    </div>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
