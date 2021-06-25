<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="DismissedUsers.aspx.cs" Inherits="PraksaFront.DismissedUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="content/css/home.css" />
        <title>Zatvoreni korisnici</title>
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
                                <asp:Label runat="server" Text="OIB"></asp:Label>
                            </th>
                            <th>
                                <asp:Label runat="server" Text="Zatvoren"></asp:Label>
                            </th>
                             <th>
                                <asp:Label runat="server" Text="Status"></asp:Label>
                            </th>
                         </tr>
                        <asp:HiddenField id="hiddenId" value="" runat="server"></asp:HiddenField>
                        <asp:Repeater ID="UserRepeater" runat="server">
                            <ItemTemplate>
                                <tr style="cursor:pointer">
                                    <td onclick="updateId(<%# Eval("id") %>);<%# _jsPostBackCall %>;"><asp:Label runat="server" Text='<%# Eval("FirstName")%>'></asp:Label></td>
                                    <td onclick="updateId(<%# Eval("id") %>);<%# _jsPostBackCall %>;"><asp:Label runat="server" Text='<%# Eval("LastName")%>'></asp:Label></td>
                                    <td onclick="updateId(<%# Eval("id") %>);<%# _jsPostBackCall %>;"><asp:Label runat="server" Text='<%# Eval("Email")%>'></asp:Label></td>
                                    <td onclick="updateId(<%# Eval("id") %>);<%# _jsPostBackCall %>;"><asp:Label runat="server" Text='<%# Eval("Address")%>'></asp:Label>
                                    <td onclick="updateId(<%# Eval("id") %>);<%# _jsPostBackCall %>;"><asp:Label runat="server" Text='<%# Eval("Number")%>'></asp:Label></td>
                                    <td onclick="updateId(<%# Eval("id") %>);<%# _jsPostBackCall %>;"><asp:Label runat="server" Text='<%# Eval("OIB")%>'></asp:Label></td>
                                    <td onclick="updateId(<%# Eval("id") %>);<%# _jsPostBackCall %>;"><asp:Label runat="server" Text='<%# Eval("Dismissed")%>'></asp:Label></td>

                                    <td style="padding:20px 10px; width:150px;">
                                        <asp:LinkButton CssClass="workButton" ID="ActivateBtn" runat="server" Text="Aktiviraj" OnCommand="ActivateBtn_Command" CommandArgument='<%# Eval("id") %>' />
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
