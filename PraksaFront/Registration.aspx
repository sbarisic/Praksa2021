<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="PraksaFront.Registration" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="content/css/Login.css" />
    <title>Registracija</title>
    <style>
        body {
            background-color: white;
            position: center;
        }

        div {
            width: 400px;
            margin-left: auto;
            margin-right: auto;
            position: center;
        }
    </style>

</head>
<body>
    <form id="form2" runat="server">

        <div class="wrapper">
            <br />
            <h2>Registriraj se</h2>
            <div class="form">
                <div class="inputfield">
                    <label>Ime</label>
                    <asp:TextBox ID="txtFirstName" runat="server" placeholder="Unesite ime :" required="required"></asp:TextBox>
                </div>
                <div class="inputfield">
                    <label>Prezime</label>
                    <asp:TextBox ID="txtLastName" runat="server" placeholder="Unesite prezime :" required="required"></asp:TextBox>
                </div>
                <div class="inputfield">
                    <label>Adresa</label>
                    <asp:TextBox ID="txtAdress" runat="server" placeholder="Unesite adresu :" required="required"></asp:TextBox>
                </div>
                <div class="inputfield">
                    <label>Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Unesite Email :" required="required" TextMode="Email"></asp:TextBox>
                </div>
                <div class="inputfield">
                    <label>Kontakt broj</label>
                    <asp:TextBox ID="txtPhoneNumber" runat="server" placeholder="Unesite kontakt broj :" required="required"></asp:TextBox>
                </div>
                <div class="inputfield">
                    <label>OIB</label>
                    <asp:TextBox ID="txtOib" runat="server" placeholder="Unesite Oib :" required="required"></asp:TextBox>
                </div>
                <div class="inputfield">
                    <label>Lozinka</label>
                    <asp:TextBox ID="txtLozinka" runat="server" placeholder="Unesite lozinku :" TextMode="Password"></asp:TextBox>
                </div>
                <div class="inputfield">
                    <label>Lozinka</label>
                    <asp:TextBox ID="txtLozinka2" runat="server" placeholder="Unesite lozinku :" TextMode="Password"></asp:TextBox>
                </div>
                <div align="center" class="registration">
                    <asp:Button ID="btnReg" runat="server" Text="Kreiraj korisnički račun" OnClick="btnReg_Click" />
                </div>
                <div align="center" class="registration">
                    <asp:Button ID="btnCancel" runat="server" Text="Odustani" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
