<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AdminPermitNames.aspx.cs" Inherits="PraksaFront.AdminPermits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <table style="margin: 0 auto;">
            <tr>
                <td>
                    <div class="card-header">
                    <h1>Dozvole</h1>
                    </div>
        <div class="card-body">
            <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                <div class="dataTable-container">
                    <table class="dataTable-table">
                        <tr>
                            <th>Naziv dozvole
                            </th>
                        </tr>
                        <asp:Repeater ID="PermitRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("name")%></td>
                                    <td>
                                        <asp:Button CssClass="workButton" ID="DeleteWork" runat="server" Text="Obriši" /></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
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
