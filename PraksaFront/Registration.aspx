<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="PraksaFront.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="content/css/Login.css" />
    <title>Prijava</title>

</head>
<body>
    <form id="form2" runat="server">
        <h1>Registracija</h1>
        <div>
            <table align="center">
                <tr>
                    <td>Ime</td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server" placeholder="Unesite ime :" required="required"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Prezime</td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server" placeholder="Unesite prezime :" required="required"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Adresa</td>
                    <td>
                        <asp:TextBox ID="txtAdress" runat="server" placeholder="Unesite adresu :" required="required"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Unesite Email :" required="required" TextMode="Email"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Kontakt broj</td>
                    <td>
                        <asp:TextBox ID="txtPhoneNumber" runat="server" placeholder="Unesite kontakt broj :" required="required"></asp:TextBox></td>
                </tr>
                <tr>
                     <td>Oib</td>
                     <td>
                        <asp:TextBox ID="txtOib" runat="server" placeholder="Unesite Oib :" required="required"></asp:TextBox></td>
                </tr>               
                <tr>
                      <td>Lozinka</td>
                      <td>
                        <asp:TextBox ID="txtlozinka" runat="server" placeholder="Unesite lozinku :"  TextMode="Password"></asp:TextBox></td>
                 </tr>
                
                 <tr>
                      <td></td>
                      <td align="right">
                        <asp:Button ID="btnReg" runat="server" Text="Kreiraj korisnički račun" OnClick="btnReg_Click" /></td>
                 </tr>
            </table>
        </div>
    </form>
</body>
</html>
