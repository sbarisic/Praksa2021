<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AboutUser.aspx.cs" Inherits="PraksaFront.AboutUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="card-header">
            <h1><asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
        </div>
        <div class="card-body">
            <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                <div class="dataTable-container">
                    <table class="dataTable-table table-striped">
                        <tr>
                            <th width="250px">
                                <asp:Label ID="lblJmbc" runat="server" Text="Jedinstveni matični broj člana"></asp:Label>
                            </th>
                            <th>
                                <asp:Label ID="txtJmbc" runat="server" Font-Bold="false"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="lblFirstName" runat="server" Text="Ime"></asp:Label>
                            </th>
                            <th>
                                <asp:Label ID="txtFirstName" runat="server" Font-Bold="false"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="lblLastName" runat="server" Text="Prezime"></asp:Label>
                            </th>
                            <th>
                                <asp:Label ID="txtLastName" runat="server" Font-Bold="false"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="lblAdress" runat="server" Text="Adresa"></asp:Label>
                            </th>
                            <th>
                                <asp:Label ID="txtAdress" runat="server" Font-Bold="false"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="lblOib" runat="server" Text="OIB"></asp:Label>
                            </th>
                            <th>
                                <asp:Label ID="txtOib" runat="server" Font-Bold="false"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                            </th>
                            <th>
                                <asp:Label ID="txtEmail" runat="server" Font-Bold="false"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="lblPhoneNumber" runat="server" Text="Kontakt broj"></asp:Label>
                            </th>
                            <th>
                                <asp:Label ID="txtPhoneNumber" runat="server" Font-Bold="false"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="lblPermits" runat="server" Text="Dozvole"></asp:Label>
                            </th>
                            <th>
                                <asp:CheckBoxList ID="cbPermits" runat="server">
                                    <asp:ListItem>Dozvola 1</asp:ListItem>
                                    <asp:ListItem>Dozvola 2</asp:ListItem>
                                    <asp:ListItem>Dozvola 3</asp:ListItem>
                                </asp:CheckBoxList>
                            </th>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button CssClass="workButton" ID="editButton" runat="server" Text="Uredi" OnCommand="editButton_Command" CommandArgument='' />
                                <asp:Button CssClass="workButton" ID="deleteButton" runat="server" Text="Obriši" OnCommand="deleteButton_Command" CommandArgument='' />
                                <asp:Button CssClass="workButton" ID="backButton" runat="server" Text="Natrag" OnClick="backButton_Click"/>
                            </td>

                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
