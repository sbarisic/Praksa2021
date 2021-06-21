<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserNumber.aspx.cs" Inherits="PraksaFront.AddUserNumber" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="content/css/home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <div class="card-header">
                <h1>
                    <asp:Label ID="lblTitle" Text="Dodaj novi broj" runat="server"></asp:Label></h1>
            </div>
            <table class="dataTable-table table-striped">
                <tr>
                    <th>
                        <asp:Label ID="lblNumber" runat="server" Text="Broj:"></asp:Label>
                    </th>
                    <td>
                        <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="PhoneFilter" runat="server" FilterType="Numbers, Custom"
                            ValidChars="+/-()[]{}" TargetControlID="txtNumber" />
                    </td>

                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnSubmit" runat="server" Text="Potvrdi" OnClick="btnSubmit_Click" OnClientClick="callParentWindowHideMethod();" />
                    </td>
                </tr>
            </table>
        </div>

        <script>
            function callParentWindowHideMethod() {
                if (window.parent.hideEditModalPopup) {
                    window.parent.hideEditModalPopup();
                }
            }
        </script>
    </form>
</body>
</html>
