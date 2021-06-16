<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PraksaFront.WebForm1" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="content/css/Login.css" />
    <title>Prijava</title>
    <style>
        body {
            background-color: white;
            position: center;
        }

        div {
            width: 100px;
            height: 100px;
            margin-left: auto;
            margin-right: auto;
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            margin: auto;
        }
    </style>

</head>
<body>
    <form runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Lozinka:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" Width="125px" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="Prijava" OnClick="btnLogin_Click" BackColor="Black" /></td>
                    <td></td>
                    <td>
                        <asp:Label ID="lblErrorMessage" runat="server" Text="Pogrešan unos korisničkih podataka" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <a href="Registration.aspx">
                            <p style="text-align: center">Kreiraj novi korisnički račun</p>
                        </a>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Odustani" OnClick="btnCancel_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td><a href="Registration.aspx">
                        <p style="text-align: center">Kreiraj novi korisnički račun</p>
                    </a>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
