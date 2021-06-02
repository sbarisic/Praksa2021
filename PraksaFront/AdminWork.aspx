<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AdminWork.aspx.cs" Inherits="PraksaFront.AdminWork" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>
        <form id="form1" runat="server">
            <div style="width: 80%; float: left;">
                <table class="styled-table">
                    <tr>
                        <th width="500px">Radna Akcija
                        </th>
                        <th>Datum
                        </th>
                        <th>Vrijeme
                        </th>
                        <th>Prisutnost
                        </th>
                    </tr>

                    <asp:Repeater ID="UserWorkList" runat="server" ItemType="System.String">
                        <ItemTemplate>
                            <tr>
                                <td><%# Item %></td>
                                <td>25.06.2020</td>
                                <td>16:45</td>
                                <td><asp:Button ID="editButton" CssClass="workButton" runat="server" Text="Uredi"
                                        OnCommand="edit_Command" CommandArgument=<%# Item %> />
                                <asp:Button ID="deleteButton" CssClass="workButton" runat="server" Text="Obriši"
                                        OnCommand="delete_Command" CommandArgument=<%# Item %> />
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div style="width: 20%; margin-top: 20px; float: left;">
                <asp:Button ID="Button5" runat="server" Text="Dodaj akciju" />
            </div>
        </form>

    </body>
    </html>

</asp:Content>
