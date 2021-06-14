<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="AboutWork.aspx.cs" Inherits="PraksaFront.AboutWork" %>

<head>
    <link href="content/css/home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="card-header">
            <h1>
                <asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
        </div>
        <div class="card-body">
            <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                <div class="dataTable-container">
                    <table class="dataTable-table table-striped">
                        <tr>
                            <th>
                                <asp:Label ID="Label1" runat="server" Text="Radna akcija"></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="workText" runat="server" Text="Testna akcija"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label2" runat="server" Text="Opis"></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="descriptionText" runat="server" Text="ovo ovdje je opis testne akcije lol"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label4" runat="server" Text="Datum"></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="dateText" runat="server" Text="69.420.1991."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label6" runat="server" Text="Vrijeme"></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="timeText" runat="server" Text="06:09"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label8" runat="server" Text="Lokacija"></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="locationText" runat="server" Text="Testna lokacija"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label10" runat="server" Text="Obveznost"></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="obligationText" runat="server" Text="Obavezno"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label12" runat="server" Text="Prisutnost"></asp:Label>
                            </th>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="Dolazim" />
                                <asp:Button ID="Button2" runat="server" Text="Ne dolazim" />
                                <asp:Button ID="Button3" runat="server" Text="Mozda dolazim" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>

