<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserEmail.aspx.cs" Inherits="PraksaFront.AddUserEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="content/css/home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="card-header">
                <h1>
                    <asp:Label ID="lblTitle" Text="Dodaj novi email" runat="server"></asp:Label></h1>
            </div>
            <table class="dataTable-table table-striped">
                <tr>
                    <th>
                        <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                    </th>
                    <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <asp:Button ID="btnSubmit" runat="server" Text="Potvrdi" OnClick="btnSubmit_Click" OnClientClick="callParentWindowHideMethod();"/>
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
