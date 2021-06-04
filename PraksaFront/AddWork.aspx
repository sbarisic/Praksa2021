<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AddWork.aspx.cs" Inherits="PraksaFront.AddWork" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="f1" runat="server">
        <div>
            <table class="styled-table">
                <tr>
                    <th width="200px">
                        <asp:Label ID="Label1" runat="server" Text="Radna akcija"></asp:Label>
                    </th>

                    <td>
                        <asp:TextBox Placeholder="Radna akcija..." ID="workText" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="Label2" runat="server" Text="Opis"></asp:Label>
                    </th>
                    <td>
                        <asp:TextBox Placeholder="Opis..." ID="descriptionText" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="Label3" runat="server" Text="Datum"></asp:Label>
                    </th>
                    <td>
                        <asp:TextBox TextMode="Date" Placeholder="Datum..." ID="dateText" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="Label4" runat="server" Text="Vrijeme"></asp:Label>
                    </th>
                    <td>
                        <asp:TextBox TextMode="Time" Placeholder="Vrijeme..." ID="timeText" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="Label5" runat="server" Text="Lokacija"></asp:Label>
                    </th>
                    <td>
                        <asp:TextBox Placeholder="Lokacija..." ID="locationText" runat="server"></asp:TextBox>
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
                            <asp:Button OnCommand="Submit_Command" Style="display: inline-block; text-align: center; margin-right: 10px;" ID="Button1" runat="server" Text="Potvrdi" OnClientClick="return confirm('Are you sure?')" />
                            <asp:Button OnCommand="Cancel_Command" Style="display: inline-block; text-align: center; margin-left: 10px;" ID="Button2" runat="server" Text="Odustani" OnClientClick="return confirm('Are you sure?')" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>

</asp:Content>