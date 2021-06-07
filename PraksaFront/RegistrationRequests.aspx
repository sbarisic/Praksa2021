<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RegistrationRequests.aspx.cs" Inherits="PraksaFront.RegistrationRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="content/css/radneAkcijeStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <div class="card-header">
            <h1>Zahtjevi registracije</h1>
        </div>

        <div>
                <table class="styled-table">
                    <tr>
                        <th><asp:Label runat="server" Text="Ime"></asp:Label>
                        </th>
                        <th><asp:Label runat="server" Text="Prezime"></asp:Label>
                        </th>
                        <th><asp:Label runat="server" Text="OIB"></asp:Label></th>
                        <th><asp:Label runat="server" Text="E-Mail"></asp:Label></th>
                        <th><asp:Label runat="server" Text="Broj telefona"></asp:Label></th>
                        <th><asp:Label runat="server" Text="Adresa"></asp:Label></th>
                        <th><asp:Label runat="server" Text="JMBC"></asp:Label></th>
                        <th><asp:Label runat="server" Text="Status"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <td>Pero</td>
                        <td>Perić</td>
                        <td>18910347220</td>
                        <td>peroperic@mail.com</td>
                        <td>099123123</td>
                        <td>Ul. Ante Trubića 5</td>
                        <td>1205999310626</td>
                        <td>
                            <asp:Button CssClass="workButton" ID="editButton" runat="server" Text="Prihvati"  OnClientClick="return confirm('Are you sure?')"/>
                            <asp:Button CssClass="workButton" ID="deleteButton" runat="server" Text="Odbij" OnClientClick="return confirm('Are you sure?')"/>
                        </td>
                    </tr>
                    <tr>
                        <td>Marko</td>
                        <td>Marušić</td>
                        <td>52086959347</td>
                        <td>marko.marusic@mail.com</td>
                        <td>098987987</td>
                        <td>Ul. Ivana Gundulića 5</td>
                        <td>1206219314223</td>
                        <td>
                            <asp:Button CssClass="workButton" ID="Button1" runat="server" Text="Prihvati" OnClientClick="return confirm('Are you sure?')"/>
                            <asp:Button CssClass="workButton" ID="Button2" runat="server" Text="Odbij" OnClientClick="return confirm('Are you sure?')"/>
                        </td>
                    </tr>
                </table>
            </div>
    </form>


</asp:Content>
