<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="PraksaFront.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <head>
        <title>Korisnik</title>
        <link rel="stylesheet" href="content/css/home.css" />
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="card-header">
                <h1>Korisnik</h1>
            </div>
            <div class="card-body">
                <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                    <div class="dataTable-container">
                        <table class="dataTable-table">
                            <tr>
                                <th width="150px">
                                    <asp:Label ID="lblJmbc" runat="server" Text="Jedinstveni matični broj člana"></asp:Label>
                                </th>
                                <th>
                                    <asp:TextBox ID="txtJmbc" runat="server"></asp:TextBox>
                                </th>
                            </tr>
                            <tr>
                                <th width="150px">
                                    <asp:Label ID="lblFirstName" runat="server" Text="Ime"></asp:Label>
                                </th>
                                <th>
                                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                </th>
                            </tr>
                            <tr>
                                <th width="150px">
                                    <asp:Label ID="lblLastName" runat="server" Text="Prezime"></asp:Label>
                                </th>
                                <th>
                                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                </th>
                            </tr>
                            <tr>
                                <th width="150px">
                                    <asp:Label ID="lblAdress" runat="server" Text="Adresa"></asp:Label>
                                </th>
                                <th>
                                    <asp:TextBox ID="txtAdress" runat="server"></asp:TextBox>
                                </th>
                            </tr>
                            <tr>
                                <th width="150px">
                                    <asp:Label ID="lvlOib" runat="server" Text="OIB"></asp:Label>
                                </th>
                                <th>
                                    <asp:TextBox ID="txtOib" runat="server"></asp:TextBox>
                                </th>
                            </tr>
                            <tr>
                                <th width="150px">
                                    <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                                </th>
                                <th>
                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                </th>
                            </tr>
                            <tr>
                                <th width="150px">
                                    <asp:Label ID="lblContactNum" runat="server" Text="Kontakt broj"></asp:Label>
                                </th>
                                <th>
                                    <asp:TextBox ID="txtContactNum" runat="server"></asp:TextBox>
                                </th>
                            </tr>
                            <tr>
                                <th width="150px">
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
                        </table>
                    </div>
                </div>
            </div>
        </form>
    </body>
</asp:Content>





