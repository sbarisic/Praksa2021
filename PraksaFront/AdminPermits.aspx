<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AdminPermits.aspx.cs" Inherits="PraksaFront.AdminPermits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <table style="margin: 0 auto;">
            <tr>
                <td>

                    <table class="styled-table">
                        <tr>
                            <th>Broj dozvole
                            </th>
                            <th>Naziv dozvole
                            </th>
                            <th>Uredi</th>
                        </tr>
                        <asp:Repeater ID="PermitRepeater" runat="server" ItemType="System.String">
                            <ItemTemplate>
                                <tr>
                                    <td>1</td>
                                    <td><%# Item %></td>
                                    <td>
                                        <asp:Button CssClass="workButton" ID="Button4" runat="server" Text="Obriši" /></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>

                </td>
                <td>
                    <div style="padding: 20px;">
                        <asp:Button CssClass="workButton" ID="addPermitBtn" runat="server" Text="Dodaj dozvolu" />
                    </div>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
