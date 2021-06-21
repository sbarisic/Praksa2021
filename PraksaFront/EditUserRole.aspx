<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUserRole.aspx.cs" Inherits="PraksaFront.EditUserRole" %>
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
            <table class="dataTable-table table-striped">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:Repeater ID="RoleRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:HiddenField ID="hdnField" Value='<%# Eval("Name") %>' runat="server" />
                                <asp:HiddenField ID="hdnId" Value='<%# Eval("Id") %>' runat="server" />
                                <asp:CheckBox ID="roleChk" runat="server" Text='<%# Eval("Name")%>' AutoPostBack="true" /></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button CssClass="workButton" Style="display: inline-block; text-align: center; margin-right: 10px;" ID="BtnSubmit" runat="server" Text="Potvrdi" OnClick="BtnSubmit_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
