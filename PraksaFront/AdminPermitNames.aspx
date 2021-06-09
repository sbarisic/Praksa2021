<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AdminPermitNames.aspx.cs" Inherits="PraksaFront.AdminPermits" %>

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
    <form id="form1" runat="server">
        <script>
    function hideEditModalPopup() {
        $find("ModalPopupExtender1").hide();
        document.getElementById("btnSample").click();
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
        <asp:Button runat="server" ID="btnSample" ClientIDMode="Static" Text="" style="display:none;" OnClick="btnSample_Click" />
        <table style="margin: 0 auto;">
            <tr>
                <td>
                    <div class="card-header" style="border:1px solid rgba(0,0,0,0.1)">
                    <h1>Dozvole</h1>
                    </div>
        <div class="card-body">
            <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                <div class="dataTable-container">
                    <table class="dataTable-table table-striped" >
                        <tr style="background-color:lightgreen;">
                            <th colspan="2">Naziv dozvole
                            </th>
                        </tr>
                        <asp:Repeater ID="PermitRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("name")%></td>
                                    <td>
                                        <asp:Button CssClass="workButton" ID="DeleteWorkBtn" runat="server" Text="Obriši" OnCommand="deletePermitNameBtn_Command" CommandArgument='<%# Eval("id") %>'/></td>
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
                        <asp:Button CssClass="workButton" ID="addPermitBtn" OnClick="addPermitBtn_Click" runat="server" Text="Dodaj dozvolu"/>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
