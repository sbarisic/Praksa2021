<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUserEmail.aspx.cs" Inherits="PraksaFront.EditUserEmail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="content/css/home.css" />
    <style>
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <script>
            function callParentWindowHideMethod() {
                if (window.parent.hideEditModalPopup) {
                    window.parent.hideEditModalPopup();
                }
            }
        </script>
        <div class="card-body">
            <table class="dataTable-table table-striped">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:Repeater ID="EmailRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtEmail" Text='<%# Eval("Email") %>' runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnDel" runat="server" Text="Ukloni" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td>
                        <asp:Button ID="PopupBtn" runat="server" Text="+" />
                        <cc1:ModalPopupExtender ID="AddPopup" runat="server" PopupControlID="Panl2" TargetControlID="PopupBtn"
                            CancelControlID="ButtonClose" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
                        <asp:Panel ID="Panl2" runat="server" CssClass="Popup" align="center" Style="display: none">
                            <iframe ID="addFrame" src="<%= addUrl %>" width="100%" height="500px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
                            <asp:Button ID="ButtonClose" runat="server" Text="Zatvori" />
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button CssClass="workButton" Style="display: inline-block; text-align: center; margin-right: 10px;" ID="BtnSubmit" runat="server" Text="Potvrdi" OnClick="BtnSubmit_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
