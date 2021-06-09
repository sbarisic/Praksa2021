<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="PraksaFront.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="content/css/home.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    function updateId(param) {
       document.getElementById("<%=hiddenId.ClientID%>").value = param;
    }
    </script>
    
    <form id="form1" runat="server">
        <div class="card-header">
            <h1>Korisnici</h1>
        </div>
        <div class="card-body">
            <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                <div class="dataTable-container">
                    <table class="dataTable-table table-striped">
                        <tr style="background-color:lightgreen;">
                            <th>
                                <asp:Label runat="server" Text="Ime"></asp:Label>
                            </th>
                            <th>
                                <asp:Label runat="server" Text="Prezime"></asp:Label>
                            </th>
                            <th>
                                <asp:Label runat="server" Text="E-Mail"></asp:Label></th>
                            <th>
                                <asp:Label runat="server" Text="Broj telefona"></asp:Label></th>
                            <th>
                                <asp:Label runat="server" Text="Adresa"></asp:Label></th>
                            <th>
                                <asp:Label runat="server" Text="JMBC"></asp:Label></th>
                            <th>
                                <asp:Label runat="server" Text="Status"></asp:Label>
                            </th>
                        </tr>
                        <asp:HiddenField id="hiddenId" value="" runat="server"></asp:HiddenField>
                        <asp:Repeater ID="UserRepeater" runat="server">
                            <ItemTemplate>
                                <tr onclick="updateId(<%# Eval("id") %>);<%# _jsPostBackCall %>;" style="cursor:pointer">
                                    <td><asp:Label runat="server" Text='<%# Eval("firstname")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("lastname")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("email")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("phonenumber")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("address")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("uniqueid")%>'></asp:Label></td>
                                    <td>
                                        <asp:Button CssClass="workButton" ID="editButton" runat="server" Text="Uredi" OnCommand="editButton_Command" CommandArgument='<%# Eval("id") %>' />
                                        <asp:Button CssClass="workButton" ID="deleteButton" runat="server" Text="Obriši" OnCommand="deleteButton_Command" CommandArgument='<%# Eval("id") %>'/>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
