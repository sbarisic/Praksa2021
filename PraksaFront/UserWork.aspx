<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UserWork.aspx.cs" Inherits="PraksaFront.UserWork" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <body>
        <form id="form1" runat="server">
            <div>
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
                                <td><asp:Button ID="yesButton" CssClass="workButton" runat="server" Text="Dolazim"
                                        OnCommand="yes_Command" CommandArgument=<%# Item %> />
                                <asp:Button ID="noButton" CssClass="workButton" runat="server" Text="Ne dolazim"
                                        OnCommand="no_Command" CommandArgument=<%# Item %> />
                                <asp:Button ID="maybeButton" CssClass="workButton" runat="server" Text="Mozda dolazim"
                                        OnCommand="maybe_Command" CommandArgument=<%# Item %> /></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </form>
    </body>
    </html>

</asp:Content>
