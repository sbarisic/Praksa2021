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
                        <th width="200px">Ime
                        </th>
                        <th width="200px">Prezime
                        </th>
                        <th>Uredi
                        </th>
                    </tr>
                    <tr>
                        <td>Pero</td>
                        <td>Perić</td>
                        <td>
                            <asp:Button ID="editButton" runat="server" Text="Uredi" />
                            <asp:Button ID="deleteButton" runat="server" Text="Obriši" />
                        </td>
                    </tr>
                    <tr>
                        <td>Marko</td>
                        <td>Marušić</td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Uredi" />
                            <asp:Button ID="Button2" runat="server" Text="Obriši" />
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </body>
</asp:Content>
