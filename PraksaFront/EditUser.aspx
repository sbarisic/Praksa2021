<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="PraksaFront.EditUser" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Uredi korisnika</title>
    <link rel="stylesheet" href="content/css/home.css" />
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button runat="server" ID="hdnBtn" ClientIDMode="Static" Text="" style="display:none;" OnClick="hdnBtn_Click" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hdnField" runat="server" /><asp:HiddenField ID="hdnField2" runat="server" /><asp:HiddenField ID="hdnField3" runat="server" />
        <asp:HiddenField ID="hdnField4" runat="server" />
        <!--EDIT/ADD PERMIT-->
        <cc1:ModalPopupExtender BehaviorID="ModalPopupExtender1" ID="ModalPopupExtender1" runat="server" PopupControlID="Panl2" TargetControlID="hdnField" CancelControlID="ButtonClose" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
        <asp:Panel ID="Panl2" runat="server" CssClass="Popup" align="center" Style="display: none">
                <iframe ID="permitFrame" src="" width="100%" height="500px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
            <asp:Button ID="ButtonClose" runat="server" Text="Zatvori" OnClientClick="hideEditModalPopup();"/>
        </asp:Panel>

        <!--EDIT/ADD EMAIL-->
        <cc1:ModalPopupExtender BehaviorID="emailPopupExtender" ID="emailPopupExtender" runat="server" PopupControlID="Panl3" 
        TargetControlID="hdnField2" CancelControlID="ButtonClose2" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
        <asp:Panel ID="Panl3" runat="server" CssClass="Popup" align="center" Style="display: none">
                <iframe ID="emailFrame" src="<%= emailUrl %>" width="100%" height="500px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
            <asp:Button ID="ButtonClose2" runat="server" Text="Zatvori" OnClientClick="hideEditModalPopup();"/>
        </asp:Panel>

        <!--EDIT/ADD NUMBER-->
        <cc1:ModalPopupExtender BehaviorID="numberPopupExtender" ID="numberPopupExtender" runat="server" PopupControlID="Panl4" 
        TargetControlID="hdnField3" CancelControlID="ButtonClose3" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
        <asp:Panel ID="Panl4" runat="server" CssClass="Popup" align="center" Style="display: none">
                <iframe ID="numberFrame" src="<%= numberUrl %>" width="100%" height="500px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
            <asp:Button ID="ButtonClose3" runat="server" Text="Zatvori" OnClientClick="hideEditModalPopup();"/>
        </asp:Panel>

        <!--EDIT/ADD ROLE-->
        <cc1:ModalPopupExtender BehaviorID="rolePopupExtender" ID="rolePopupExtender" runat="server" PopupControlID="Panl5" 
        TargetControlID="hdnField4" CancelControlID="ButtonClose4" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
        <asp:Panel ID="Panl5" runat="server" CssClass="Popup" align="center" Style="display: none">
                <iframe ID="numberFrame" src="<%= roleUrl %>" width="100%" height="500px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
            <asp:Button ID="ButtonClose4" runat="server" Text="Zatvori" OnClientClick="hideEditModalPopup();"/>
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
                                <asp:TextBox ID="txtJmbc" runat="server" required="required"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="JmbcFilter" runat="server" FilterType="Numbers"
                                    TargetControlID="txtJmbc" />
                            </th>
                        </tr>
                        <tr>
                            <th width="150px">
                                <asp:Label ID="lblFirstName" runat="server" Text="Ime"></asp:Label>
                            </th>
                            <th>
                                <asp:TextBox ID="txtFirstName" runat="server" required="required"></asp:TextBox>
                            </th>
                        </tr>
                        <tr>
                            <th width="150px">
                                <asp:Label ID="lblLastName" runat="server" Text="Prezime"></asp:Label>
                            </th>
                            <th>
                                <asp:TextBox ID="txtLastName" runat="server" required="required"></asp:TextBox>
                            </th>
                        </tr>
                        <tr>
                            <th width="150px">
                                <asp:Label ID="lblAdress" runat="server" Text="Adresa"></asp:Label>
                            </th>
                            <th>
                                <asp:TextBox ID="txtAdress" runat="server" required="required"></asp:TextBox>
                            </th>
                        </tr>
                        <tr>
                            <th width="150px">
                                <asp:Label ID="lblOib"  runat="server" Text="OIB"></asp:Label>
                            </th>
                            <th>
                                <asp:TextBox ID="txtOib" pattern=".{11}"  runat="server" placeholder="Unesite Oib :" required="required" title="Polje mora imati 11 znamenki"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="OibFilter" runat="server" FilterType="Numbers"
                                    TargetControlID="txtOib" />
                            </th>
                        </tr>
                        <tr>
                            <th width="150px">
                                <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                                <asp:LinkButton ID="btnEditEmail" style="color:white; font-weight:normal;" CssClass="editButton" runat="server" Text="Uredi" OnClick="btnEditEmail_click"></asp:LinkButton>
                            </th>
                            <th>
                                <asp:Repeater ID="EmailRepeater" runat="server">
                                        <ItemTemplate>
                                                <asp:TextBox Text='<%# Eval("Email") %>' ID="txtEmail" runat="server"></asp:TextBox>
                                                <asp:LinkButton style="color:white; font-weight:normal;" CssClass="deleteButton" ID="BtnDeleteEmail" runat="server" Text="Obriši" 
                                                OnClientClick="return confirm('Jeste li sigurni da želite obrisati email?')" OnCommand="BtnDeleteEmail_command" CommandArgument='<%# Eval("Id") %>' /><br>
                                        </ItemTemplate>
                                    </asp:Repeater>
                            </th>
                        </tr>
                        <tr>
                            <th width="150px">
                                <asp:Label ID="lblPhoneNumber" runat="server" Text="Kontakt broj"></asp:Label>
                                <asp:LinkButton ID="btnEditNumber" style="color:white; font-weight:normal;" CssClass="editButton" runat="server" Text="Uredi" OnClick="btnEditNumber_click"></asp:LinkButton>
                            </th>
                            <th>
                                <asp:Repeater ID="NumberRepeater" runat="server">
                                    <ItemTemplate>
                                            <asp:TextBox Text='<%# Eval("Number") %>' ID="txtPhoneNumber" runat="server" required="required"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="PhoneFilter" runat="server" FilterType="Numbers, Custom"
                                                ValidChars="+/-()[]{}" TargetControlID="txtPhoneNumber" />
                                            <asp:LinkButton style="color:white; font-weight:normal;" CssClass="deleteButton" ID="BtnDeletePhoneNumber" runat="server" Text="Obriši" 
                                            OnClientClick="return confirm('Jeste li sigurni da želite obrisati broj telefona?')" OnCommand="BtnDeletePhoneNumber_command" CommandArgument='<%# Eval("Id") %>' /><br>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </th>
                        </tr>
                        <tr> 
                            <th width="150px">
                               <asp:Label ID="lblRole" runat="server" Text="Uloge"></asp:Label>
                                <asp:LinkButton CssClass="editButton" Style="color:white; font-weight:normal;" ID="BtnAddRole" runat="server" Text="Uredi"
                                 OnClick="btnAddRole_click" />
                            </th>
                            <td>
                            <asp:Repeater ID="RoleRepeater" runat="server">
                                    <ItemTemplate>
                                            <%# Eval("Name")%>
                                            <asp:LinkButton CssClass="deleteButton" ID="BtnEditRole" runat="server" Text="Obriši" 
                                            OnClientClick="return confirm('Jeste li sigurni da želite obrisati ulogu?')" OnCommand="BtnDeleteRole_command" CommandArgument='<%# Eval("Id") %>' />
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div Visible="false" id="errorRole" runat="server" class="alert alert-danger" style="width:330px; display:block; padding:8px;">
                                    <strong>Greška!</strong> Korisnik mora imati barem jednu ulogu!
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th width="150px">
                                <asp:Label ID="lblPermits" runat="server" Text="Dozvole"></asp:Label>
                                <asp:LinkButton CssClass="editButton" Style="color:white; font-weight:normal;" 
                                onclientclick="return setPermitFrame()" ID="BtnAddPermit" runat="server" Text="Uredi" />
                            </th>
                            <td>
                                <asp:Repeater ID="PermitRepeater" runat="server">
                                    <ItemTemplate>
                                            <%# Eval("PermitName")%> <%# Eval("ExpiryDate")%> <%# Eval("PermitNumber")%>
                                            <asp:LinkButton CssClass="deleteButton" ID="BtnEditPermit" runat="server" Text="Obriši" 
                                            OnClientClick="return confirm('Jeste li sigurni da želite obrisati dozvolu?')" OnCommand="BtnDeletePermit_command" CommandArgument='' /><br>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2">
                                <asp:LinkButton CssClass="workButton" Style="color:white;display: inline-block; text-align: center; margin-right: 10px;" ID="BtnSubmit" runat="server" Text="Potvrdi" OnClick="BtnSubmit_Click" />
                                <asp:LinkButton CssClass="closeButton" Style="color:white;display:inline-block" ID="deleteButton" runat="server" Text="Zatvori" OnClientClick="return confirm('Jeste li sigurni da želite obrisati korisnika?')" OnCommand="deleteButton_Command" CommandArgument='' />
                                <asp:LinkButton CssClass="workButton" Style="color:white;display: inline-block; text-align: center; margin-left: 10px;" ID="BtnCancel" runat="server" Text="Odustani" OnClick="BtnCancel_Click" />
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
        $find('ModalPopupExtender1').show();
        return false;
    }
    function hideEditModalPopup() {
        $find("ModalPopupExtender1").hide();
        $find("emailPopupExtender").hide();
        $find("numberPopupExtender").hide();
        $find("rolePopupExtender").hide();
        document.getElementById("hdnBtn").click();
        return false;
    }

        </script>
    </div>
</asp:Content>


