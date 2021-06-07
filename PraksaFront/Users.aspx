<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="PraksaFront.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <form id="form1" runat="server">
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
                        <th><asp:Label runat="server" Text="Uredi"></asp:Label>
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
                            <asp:Button CssClass="workButton" ID="editButton" runat="server" Text="Uredi"  />
                            <asp:Button CssClass="workButton" ID="deleteButton" runat="server" Text="Obriši" OnClientClick="return confirm('Are you sure?')"/>
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
                            <asp:Button CssClass="workButton" ID="Button1" runat="server" Text="Uredi" />
                            <asp:Button CssClass="workButton" ID="Button2" runat="server" Text="Obriši" />
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </body>
</asp:Content>
