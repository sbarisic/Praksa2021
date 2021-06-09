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
        <div class="card-header">
            <h1><asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
        </div>
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
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            </th>
                        </tr>
                        <tr>
                            <th width="150px">
                                <asp:Label ID="lblPhoneNumber" runat="server" Text="Kontakt broj"></asp:Label>
                            </th>
                            <th>
                                <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="PhoneFilter" runat="server" FilterType="Numbers, Custom"
                                    ValidChars="+ " TargetControlID="txtPhoneNumber" />
                            </th>
                        </tr>
                        <tr>
                            <th width="150px">
                                <asp:Label ID="lblPermits" runat="server" Text="Dozvole"></asp:Label>
                            </th>
                            <th>
                                <asp:CheckBoxList ID="cbPermits" runat="server">
                                    <asp:ListItem>Dozvola 1</asp:ListItem>
                                    <asp:ListItem>Dozvola 2</asp:ListItem>
                                    <asp:ListItem>Dozvola 3</asp:ListItem>
                                </asp:CheckBoxList>
                            </th>
                        </tr>
                        <tr>
                            <th colspan="2">
                                <asp:Button CssClass="workButton" Style="display: inline-block; text-align: center; margin-right: 10px;" ID="BtnSubmit" runat="server" Text="Potvrdi" OnClick="BtnSubmit_Click" />
                                <asp:Button CssClass="workButton" Style="display: inline-block; text-align: center; margin-left: 10px;" ID="BtnCancel" runat="server" Text="Odustani" OnClick="BtnCancel_Click" />
                            </th>

                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</asp:Content>





