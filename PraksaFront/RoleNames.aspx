<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RoleNames.aspx.cs" Inherits="PraksaFront.RoleNames" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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

        .auto-style1 {
            width: 71px;
            height: 41px;
        }

        .auto-style2 {
            height: 41px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <script>
            function hideEditModalPopup() {
                $find("ModalPopupExtender1").hide();
                document.getElementById("BtnSample").click();
                return false;
            }
        </script>
        <!-- EDITROLENAMES POPUP-->
        <cc1:ModalPopupExtender BehaviorID="EditModalPopupExtender" ID="EditModalPopupExtender" runat="server" PopupControlID="EditPanl" TargetControlID="hdnField" CancelControlID="ButtonCloseEdit" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
        <asp:Panel ID="EditPanl" runat="server" CssClass="Popup" align="center" Style="display: none">
            <iframe src="<%= EditFrameUrl %>" width="100%" height="490px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
            <br />
            <asp:Button ID="ButtonCloseEdit" runat="server" Text="Odustani" />
        </asp:Panel>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hdnField" runat="server" />

        <!-- CLOSEPERMITNAME-->
        <cc1:ModalPopupExtender BehaviorID="ModalPopupExtender1" ID="ModalPopupExtender1" runat="server" PopupControlID="Panl2" TargetControlID="hdnField" CancelControlID="ButtonClose" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
        <asp:Panel ID="Panl2" runat="server" CssClass="Popup" align="center" Style="display: none">
            <iframe src="AddRoleName.aspx" width="100%" height="200px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
            <asp:Button ID="ButtonClose" runat="server" Text="Zatvori" />
        </asp:Panel>
        <asp:Button runat="server" ID="BtnSample" ClientIDMode="Static" Text="" Style="display: none;" OnClick="BtnSample_Click" />
        <table style="margin: 0 auto;">
            <tr>
                <td>
                    <div class="card-header" style="border: 1px solid rgba(0,0,0,0.1)">
                        <h1>Uloge</h1>
                    </div>
                    <div class="card-body">
                        <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                            <div class="dataTable-container">
                                <table class="dataTable-table table-striped">
                                    <tr style="background-color: #93cff5;">
                                        <th colspan="2">Naziv uloge
                                        </th>
                                    </tr>
                                    <asp:Repeater ID="RoleNameRepeater" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("name")%></td>
                                                <td>
                                                    <asp:Button ID="btnEdit" CssClass="workButton" runat="server" Text="Uredi" OnCommand="BtnEdit_Command" CommandArgument='<%# Eval ("Id")%>' />
                                                    <asp:Button CssClass="workButton" ID="BtnDelete" runat="server" Text="Zatvori" OnClientClick="return confirm('Jeste li sigurni da želite obrisati ulogu?')" OnCommand="BtnDelete_Command" CommandArgument='<%# Eval("Id") %>' />
                                                </td>
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
                        <asp:Button CssClass="workButton" ID="BtnAdd" OnClick="BtnAdd_Click" runat="server" Text="Dodaj ulogu" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
