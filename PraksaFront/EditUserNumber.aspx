<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUserNumber.aspx.cs" Inherits="PraksaFront.EditUserNumber" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="content/css/home.css" />
    <style>
.Background {
    background-color: Black;
    filter: opacity(90);
    opacity: 0.8;
}

.Popup {
    background-color: #FFFFFF;
    border-width: 3px;
    border-style: solid;
    border-color: black;
    padding-top: 10px;
    width: 350px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Button runat="server" ID="hdnBtn" ClientIDMode="Static" Text="" style="display:none;" OnClick="hdnBtn_Click" />
        <script>
    function callParentWindowHideMethod() {
        if (window.parent.hideEditModalPopup) {
            window.parent.hideEditModalPopup();
        }
    }
    function hideEditModalPopup() {
        $find("AddPopup").hide();
        document.getElementById("hdnBtn").click();
        return false;
    }
        </script>
        <div class="card-body">
TEST
            <table class="dataTable-table table-striped">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:Repeater ID="NumberRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtNumber" Text='<%# Eval("Number") %>' runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnDel" runat="server" Text="Ukloni" OnCommand="deleteButton_Command" OnClientClick="return confirm('Jeste li sigurni da želite obrisati korisnika?')" CommandArgument='<%# Eval("Id") %>'/>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="PopupBtn" runat="server" Text="+" />
                        <cc1:ModalPopupExtender BehaviorID="AddPopup" ID="AddPopup" runat="server" PopupControlID="Panl2" TargetControlID="PopupBtn"
                            CancelControlID="ButtonClose" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
                        <asp:Panel ID="Panl2" runat="server" CssClass="Popup" align="center" Style="display: none" >
                            <iframe ID="addFrame" src="<%= addUrl %>" width="100%" height="200px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
                            <asp:Button ID="ButtonClose" runat="server" Text="Zatvori" OnClientClick="hideEditModalPopup();"/>
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
