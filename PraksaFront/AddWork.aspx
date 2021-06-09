<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="AddWork.aspx.cs" Inherits="PraksaFront.AddWork" %>

<head>
    <title></title>
    <link rel="stylesheet" href="content/css/home.css" />
</head>
<body style="background-color: white;">
    <form id="f1" runat="server">
        <div>
            <div class="card-body">
                <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                    <div class="dataTable-container">
                        <table class="dataTable-table">
                            <tr>
                                <th width="200px">
                                    <asp:Label ID="Label1" runat="server" Text="Radna akcija"></asp:Label>
                                </th>

                                <td>
                                    <asp:TextBox Width="300px" Placeholder="Radna akcija..." ID="workText" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="Label2" runat="server" Text="Opis"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox Width="300px" TextMode="MultiLine" Placeholder="Opis..." ID="descriptionText" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="Label3" runat="server" Text="Datum"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox Width="300px" TextMode="Date" Placeholder="Datum..." ID="dateText" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="Label4" runat="server" Text="Vrijeme"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox Width="300px" TextMode="Time" Placeholder="Vrijeme..." ID="timeText" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="Label5" runat="server" Text="Lokacija"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox Width="300px" Placeholder="Lokacija..." ID="locationText" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="Label6" runat="server" Text="Obveznost"></asp:Label>
                                </th>
                                <td>
                                    <asp:RadioButtonList ID="RadioButton" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical">
                                        <asp:ListItem>Obavezno</asp:ListItem>
                                        <asp:ListItem>Neobavezno</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div class="text-center">
                                        <asp:Button OnCommand="Submit_Command" Style="display: inline-block; text-align: center; margin-right: 10px;" ID="AddWorkButton" runat="server" Text="Potvrdi" OnClientClick="return confirm('Are you sure?')" />
                                        <asp:Button OnCommand="Cancel_Command" Style="display: inline-block; text-align: center; margin-left: 10px;" ID="CancelButton" runat="server" Text="Odustani" OnClientClick="return confirm('Are you sure?')" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
