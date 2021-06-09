<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AddPermit.aspx.cs" Inherits="PraksaFront.AddPermit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="f1" runat="server">
        <div>
            <table class="styled-table">
                <tr>
                    <th width="200px">
                        <asp:Label ID="Label1" runat="server" Text="Naziv dozvole"></asp:Label>
                    </th>

                    <td>
                        <asp:TextBox Placeholder="Dozvola..." ID="permitText" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="text-center">
                            <asp:Button Style="display: inline-block; text-align: center; margin-right: 10px;" ID="AddButton" runat="server" Text="Potvrdi" OnClientClick="return confirm('Are you sure?')" OnClick="AddButton_Click" />
                            <asp:Button Style="display: inline-block; text-align: center; margin-left: 10px;" ID="CancelButton" runat="server" Text="Odustani" OnClientClick="return confirm('Are you sure?')" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
