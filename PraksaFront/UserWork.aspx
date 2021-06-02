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
                    <% foreach (var action in actionList)
                        { %>
                    <tr>
                        <td><%= action %></td>
                        <td>25.06.2021</td>
                        <td>16:35</td>
                        <td>
                            <asp:Button ID="yesButton" runat="server" Text="Dolazim" />
                            <asp:Button ID="noButton" runat="server" Text="Ne dolazim" />
                            <asp:Button ID="maybeButton" runat="server" Text="Mozda dolazim" />
                        </td>
                    </tr>
                    <% } %>
                </table>
            </div>
        </form>
    </body>
    </html>

</asp:Content>
