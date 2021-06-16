<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RegistrationRequests.aspx.cs" Inherits="PraksaFront.RegistrationRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="content/css/radneAkcijeStyle.css" />
    <link rel="stylesheet" href="content/css/home.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <div class="card-header" style="border:1px solid rgba(0,0,0,0.1)">
            <h1>Zahtjevi registracije</h1>
        </div>

        <div>
            <div class="card-body">
                <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                    <div class="dataTable-container">
                        <table class="dataTable-table table-striped">
                            <tr style="background-color:#93cff5;">
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
                                    <asp:Label runat="server" Text="Status"></asp:Label>
                                </th>
                            </tr>
                            
                            <asp:Repeater ID="UserRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><asp:Label runat="server" Text='<%# Eval("firstname")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("lastname")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("oib")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("email")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("number")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("address")%>'></asp:Label></td>
                                    <td>
                                        <asp:Button CssClass="workButton" OnCommand="AcceptBtn_Command" CommandArgument='<%# Eval("id")%>' ID="AcceptBtn" runat="server" Text="Prihvati" OnClientClick="return confirm('Jeste li sigurni da želite prihvatiti registraciju?')" />
                                        <asp:Button CssClass="workButton" OnCommand="DeleteBtn_Command" CommandArgument='<%# Eval("id")%>' ID="DeleteBtn" runat="server" Text="Odbij" OnClientClick="return confirm('Jeste li sigurni da želite odbiti registraciju?')" />
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
