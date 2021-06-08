<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RegistrationRequests.aspx.cs" Inherits="PraksaFront.RegistrationRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="content/css/radneAkcijeStyle.css" />
    <link rel="stylesheet" href="content/css/home.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <div class="card-header">
            <h1>Zahtjevi registracije</h1>
        </div>

        <div>
            <div class="card-body">
                <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                    <div class="dataTable-container">
                        <table class="dataTable-table">
                            <tr>
                                <th>
                                    <asp:Label runat="server" Text="Ime"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" Text="Prezime"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" Text="OIB"></asp:Label></th>
                                <th>
                                    <asp:Label runat="server" Text="E-Mail"></asp:Label></th>
                                <th>
                                    <asp:Label runat="server" Text="Broj telefona"></asp:Label></th>
                                <th>
                                    <asp:Label runat="server" Text="Adresa"></asp:Label></th>
                                <th>
                                    <asp:Label runat="server" Text="JMBC"></asp:Label></th>
                                <th>
                                    <asp:Label runat="server" Text="Status"></asp:Label>
                                </th>
                            </tr>
                            
                            <asp:Repeater ID="UserRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><asp:Label runat="server" Text='<%# Eval("firstname")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("lastname")%>'></asp:Label></td>
                                    <td>...</td>
                                    <td><asp:Label runat="server" Text='<%# Eval("email")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("phonenumber")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("address")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("uniqueid")%>'></asp:Label></td>
                                    <td>
                                        <asp:Button CssClass="workButton" ID="editButton" runat="server" Text="Prihvati" OnClientClick="return confirm('Are you sure?')" />
                                        <asp:Button CssClass="workButton" ID="deleteButton" runat="server" Text="Odbij" OnClientClick="return confirm('Are you sure?')" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </form>


</asp:Content>
