<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="PraksaFront.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="content/css/home.css" />
    <title>Korisnici</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    function updateId(param) {
       document.getElementById("<%=hiddenId.ClientID%>").value = param;
        }
        function hideEditModalPopup() {
            $find("ModalPopupExtender1").hide();
            document.getElementById("btnSample").click();
            return false;
        }
    </script>
    
    <div>
        <div class="card-header" style="border:1px solid rgba(0,0,0,0.1)">
            <h1>Korisnici</h1>
        </div>
        <div class="card-body">
            <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                <div class="dataTable-container">
                    <table class="dataTable-table table-striped">
                        <tr style="background-color: #6bc277;">
                            <th>
                                <asp:Label runat="server" Text="Ime"></asp:Label>
                            </th>
                            <th>
                                <asp:Label runat="server" Text="Prezime"></asp:Label>
                            </th>
                            <th>
                                <asp:Label runat="server" Text="E-Mail"></asp:Label>
                            </th>
                            <th>
                                <asp:Label runat="server" Text="Adresa"></asp:Label>
                            </th>
                            <th>
                                <asp:Label runat="server" Text="Broj telefona"></asp:Label>
                            </th>
                            <th>
                                <asp:Label runat="server" Text="JMBC"></asp:Label>
                            </th>
                            <th>
                                <asp:Label runat="server" Text="OIB"></asp:Label>
                            </th>
                             <th>
                                <asp:Label runat="server" Text="Status"></asp:Label>
                            </th>
                         </tr>
                        <asp:HiddenField id="hiddenId" value="" runat="server"></asp:HiddenField>
                        <asp:Repeater ID="UserRepeater" runat="server">
                            <ItemTemplate>
                                <tr onclick="updateId(<%# Eval("id") %>);<%# _jsPostBackCall %>;" style="cursor:pointer">
                                    <td><asp:Label runat="server" Text='<%# Eval("Firstname")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("Lastname")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("Email")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("address")%>'></asp:Label>
                                    <td><asp:Label runat="server" Text='<%# Eval("Number")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("Uniqueid")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval("OIB")%>'></asp:Label></td>
                                    <td style="padding:20px 10px; width:190px;">
                                        <asp:LinkButton CssClass="workButton" ID="editButton" runat="server" Text="Uredi" OnCommand="editButton_Command" CommandArgument='<%# Eval("id") %>' />
                                        <asp:LinkButton CssClass="closeButton" ID="deleteButton" runat="server" Text="Zatvori" OnCommand="deleteButton_Command" OnClientClick="return confirm('Jeste li sigurni da želite obrisati korisnika?')" CommandArgument='<%# Eval("id") %>'/>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
