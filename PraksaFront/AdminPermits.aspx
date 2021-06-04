<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AdminPermits.aspx.cs" Inherits="PraksaFront.AdminPermits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="margin: 0 auto;">
        <tr>
            <form id="form1" runat="server">
                <td>

                    <table class="styled-table">
                        <tr>
                            <th>Broj dozvole
                            </th>
                            <th>Naziv dozvole
                            </th>
                            <th>Uredi</th>
                        </tr>
                        <tr>
                            <td>1</td>
                            <td>Dozvola za C kategoriju</td>
                            <td>
                                <asp:Button CssClass="workButton" ID="Button3" runat="server" Text="Uredi" />
                                <asp:Button CssClass="workButton" ID="Button4" runat="server" Text="Obriši" /></td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Dozvola za oružje</td>
                            <td>
                                <asp:Button CssClass="workButton" ID="Button1" runat="server" Text="Uredi" />
                                <asp:Button CssClass="workButton" ID="Button2" runat="server" Text="Obriši" /></td>
                        </tr>
                    </table>

                </td>
                <td>
                    <div style="padding:20px;">
                        <asp:Button CssClass="workButton" ID="addPermitBtn" runat="server" Text="Dodaj dozvolu" />
                    </div>
                </td>
            </form>
        </tr>
    </table>
</asp:Content>
