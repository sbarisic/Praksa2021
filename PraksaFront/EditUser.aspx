<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="PraksaFront.EditUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Korisnik</title>
    <link rel="stylesheet" href="content/css/home.css" />
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hdnField" runat="server" />
        <cc1:ModalPopupExtender BehaviorID="ModalPopupExtender1" ID="ModalPopupExtender1" runat="server" PopupControlID="Panl2" TargetControlID="hdnField" CancelControlID="ButtonClose" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
        <asp:Panel ID="Panl2" runat="server" CssClass="Popup" align="center" Style="display: none">
                <iframe ID="permitFrame" src='' width="100%" height="200px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
            <asp:Button ID="ButtonClose" runat="server" Text="Zatvori" />
        </asp:Panel>

        <div class="card-header">
            <h1><asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
        </div>
            <asp:HiddenField ID="userIdField" runat="server"></asp:HiddenField>
        <div class="card-body">
            <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                <div class="dataTable-container">
                    <table class="dataTable-table table-striped">
                        <tr>
                            <th width="250px">
                                <asp:Label ID="lblJmbc" runat="server" Text="Jedinstveni matični broj člana"></asp:Label>
                            </th>
                            <th>
                                <asp:TextBox ID="txtJmbc" runat="server"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="JmbcFilter" runat="server" FilterType="Numbers"
                                    TargetControlID="txtJmbc" />
                            </th>
                        </tr>
                        <tr>
                            <th width="150px">
                                <asp:Label ID="lblFirstName" runat="server" Text="Ime"></asp:Label>
                            </th>
                            <th>
                                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                            </th>
                        </tr>
                        <tr>
                            <th width="150px">
                                <asp:Label ID="lblLastName" runat="server" Text="Prezime"></asp:Label>
                            </th>
                            <th>
                                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                            </th>
                        </tr>
                        <tr>
                            <th width="150px">
                                <asp:Label ID="lblAdress" runat="server" Text="Adresa"></asp:Label>
                            </th>
                            <th>
                                <asp:TextBox ID="txtAdress" runat="server"></asp:TextBox>
                            </th>
                        </tr>
                        <tr>
                            <th width="150px">
                                <asp:Label ID="lblOib" runat="server" Text="OIB"></asp:Label>
                            </th>
                            <th>
                                <asp:TextBox ID="txtOib" runat="server" MaxLength="11"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="OibFilter" runat="server" FilterType="Numbers"
                                    TargetControlID="txtOib" />
                            </th>
                        </tr>
                        <tr>
                            <th width="150px">
                                <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                            </th>
                            <th>
                                <asp:Repeater ID="EmailRepeater" runat="server">
                                        <ItemTemplate>
                                                <asp:TextBox Text='<%# Eval("Email") %>' ID="txtEmail" runat="server"></asp:TextBox>
                                                <asp:Button CssClass="workButton" ID="BtnDeleteEmail" runat="server" Text="x" 
                                                OnClientClick="return confirm('Jeste li sigurni da želite obrisati email?')" OnCommand="BtnDeletePermit_command" CommandArgument='' /><br>
                                        </ItemTemplate>
                                    </asp:Repeater>
                            </th>
                        </tr>
                        <tr>
                            <th width="150px">
                                <asp:Label ID="lblPhoneNumber" runat="server" Text="Kontakt broj"></asp:Label>
                            </th>
                            <th>
                                <asp:Repeater ID="NumberRepeater" runat="server">
                                    <ItemTemplate>
                                            <asp:TextBox Text='<%# Eval("Number") %>' ID="txtPhoneNumber" runat="server"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="PhoneFilter" runat="server" FilterType="Numbers, Custom"
                                                ValidChars="+ " TargetControlID="txtPhoneNumber" />
                                            <asp:Button CssClass="workButton" ID="BtnDeletePhoneNumber" runat="server" Text="x" 
                                            OnClientClick="return confirm('Jeste li sigurni da želite obrisati broj telefona?')" OnCommand="BtnDeletePermit_command" CommandArgument='' /><br>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </th>
                        </tr>
                        <tr> 
                            <th width="150px">
                                <asp:Label ID="lblRole" runat="server" Text="Uloga"></asp:Label>
                            </th>
                            <td>
                                <asp:RadioButtonList ID="roleButton" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical">
                                     <asp:ListItem Value="1">Ravnatelj/tajnik</asp:ListItem>
                                     <asp:ListItem Value="2">Korisnik</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <th width="150px">
                                <asp:Label ID="lblPermits" runat="server" Text="Dozvole"></asp:Label><br>
                                <asp:Button CssClass="workButton" Style="display: inline-block; text-align: center; margin-right: 10px;" 
                                onclientclick="setPermitFrame()" ID="BtnAddPermit" runat="server" Text="Dodaj" OnClick="BtnAddPermit_Click" />
                            </th>
                            <td>
                                <asp:Repeater ID="PermitRepeater" runat="server">
                                    <ItemTemplate>
                                            <%# Eval("PermitName")%> <%# Eval("ExpiryDate")%>
                                            <asp:Button CssClass="workButton" ID="BtnEditPermit" runat="server" Text="x" 
                                            OnClientClick="return confirm('Jeste li sigurni da želite obrisati dozvolu?')" OnCommand="BtnDeletePermit_command" CommandArgument='' /><br>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2">
                                <asp:Button CssClass="workButton" Style="display: inline-block; text-align: center; margin-right: 10px;" ID="BtnSubmit" runat="server" Text="Potvrdi" OnClick="BtnSubmit_Click" />
                                <asp:Button CssClass="workButton" ID="deleteButton" runat="server" Text="Zatvori" OnClientClick="return confirm('Jeste li sigurni da želite obrisati korisnika?')" OnCommand="deleteButton_Command" CommandArgument='' />
                                <asp:Button CssClass="workButton" Style="display: inline-block; text-align: center; margin-left: 10px;" ID="BtnCancel" runat="server" Text="Odustani" OnClick="BtnCancel_Click" />
                            </th>

                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <script>
            function setPermitFrame() {
                var id = document.getElementById('<%= userIdField.ClientID %>').value;
                document.getElementById('permitFrame').src = "AddUserPermit.aspx?userId=" + id;
            }
        </script>
    </form>
</asp:Content>





