<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUserPermit.aspx.cs" Inherits="PraksaFront.EditUserPermit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="content/css/home.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="card">
            <div class="card-body">
                <table class="dataTable-table">
                    <tr>
                        <th>
                            <asp:Label ID="Label1" runat="server" Text="Naziv dozvole"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Text="Testna dozvola"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="Label2" runat="server" Text="Trajanje dozvole"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Text="25.04.2021"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center;">
                            <asp:Button ID="Button1" runat="server" Text="Potvrdi" />
                            <asp:Button ID="Button2" runat="server" Text="Obriši" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
