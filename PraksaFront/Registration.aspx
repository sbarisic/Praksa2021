<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="PraksaFront.Registration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="content/css/Login.css" />
    <link rel="stylesheet" href="content/css/home.css" />
    <title>Registracija</title>
    <style>
        body {
            background-color: white;
            position: center;
        }
    </style>

</head>
<body>
    <form id="form2" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card-header" style="border: 1px solid rgba(0,0,0,0.1); width:600px; margin:0 auto;">
            <h3>
                <asp:Label ID="lblHeader" runat="server" Text="Registriraj se" e ></asp:Label></h3>
        </div>
        <div class="card-body" style="width:670px; margin:0 auto;">
            <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                <div class="dataTable-container">
                    <table class="dataTable-table">
                        <tr>
                            <th>
                                <asp:Label ID="Label1" runat="server" Text="Ime"></asp:Label></th>
                            <td>
                                <asp:TextBox ID="txtFirstName" runat="server" placeholder="Ime..." required="required"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label2" runat="server" Text="Prezime"></asp:Label></th>
                            <td><asp:TextBox ID="txtLastName" runat="server" placeholder="Prezime..." required="required"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label3" runat="server" Text="Adresa"></asp:Label></th>
                            <td><asp:TextBox ID="txtAdress" runat="server" placeholder="Adresa..." required="required"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label></th>
                            <td><asp:TextBox ID="txtEmail" runat="server" placeholder="Email..." required="required" TextMode="Email"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label5" runat="server" Text="Kontakt broj"></asp:Label></th>
                            <td><asp:TextBox ID="txtPhoneNumber" runat="server" placeholder="Kontakt broj..." required="required"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="PhoneFilter" runat="server" FilterType="Numbers, Custom"
                                                ValidChars="+/-()[]{}" TargetControlID="txtPhoneNumber" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label6" runat="server" Text="OIB"></asp:Label></th>
                            <td><asp:TextBox pattern=".{11}" ID="txtOib" runat="server" placeholder="Unesite Oib :" required="required" title="Polje mora imati 11 znamenki" onkeydown = "return (!((event.keyCode>=65 && event.keyCode <= 95) || event.keyCode >= 106 || (event.keyCode >= 48 && event.keyCode <= 57  && isNaN(event.key))) && event.keyCode!=32);"> </asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label pattern=".{11}" ID="Label7" runat="server" Text="Lozinka" title="Lozinka mora imati barem 8 znakova"></asp:Label></th>
                            <td><asp:TextBox ID="txtLozinka" runat="server" placeholder="Unesite lozinku :" TextMode="Password"></asp:TextBox>
                            <div visible="false" id="errorPassword" runat="server" class="alert alert-danger alert-dismissible" style="width: 300px; position:absolute; padding: 8px;">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close" onclick='this.parentNode.parentNode.removeChild(this.parentNode); return false;'>&times;</a>
                                <strong>Greška!</strong> Lozinka mora imati barem 8 znakova.
                            </div>
                            <cc1:PasswordStrength ID="txtLozinka_PwStrength" runat="server"
                                Enabled="True" TargetControlID="txtLozinka" DisplayPosition="RightSide"
                                StrengthIndicatorType="Text" PreferredPasswordLength="8" PrefixText="Jačina lozinke: "
                                TextStrengthDescriptions="Jako slaba; Slaba; Prosječna; Jaka; Vrlo jaka"
                                TextCssClass="textIndicator" /></td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label8" runat="server" Text="Ponovi lozinku"></asp:Label></th>
                            <td><asp:TextBox ID="txtLozinka2" runat="server" placeholder="Unesite lozinku :" TextMode="Password"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align:center;">
                                <asp:Button  ID="btnReg" runat="server" Text="Potvrdi" OnClick="btnReg_Click" />
                                <asp:Button  ID="btnCancel" UseSubmitBehavior="false" runat="server" Text="Odustani" OnClick="btnCancel_Click" /></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>