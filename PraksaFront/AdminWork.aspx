<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AdminWork.aspx.cs" Inherits="PraksaFront.AdminWork" %> 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
    <link href="content/css/home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <script>
            function hideEditModalPopup() {
                $find("ModalPopupExtender2").hide();
                document.getElementById("hdnBtn").click();
                return false;
            }
        </script>
        <table style="margin: 0 auto;">
            <tr>
                <td>
                    <!-- LOKACIJA POPUP-->
                    <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>
                    <asp:Button runat="server" ID="hdnBtn" ClientIDMode="Static" Text="" style="display:none;" OnClick="hdnBtn_Click" />
                    <asp:HiddenField ID="hdnField" runat="server" />
                    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panl1" TargetControlID="hdnField" CancelControlID="Button2" BackgroundCssClass="Background"> </cc1:ModalPopupExtender>
                    <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
                        <iframe src="<%= url%>" width="100%" height="490px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
                        <br />
                        <asp:Button ID="Button2" runat="server" Text="Zatvori" />
                    </asp:Panel>
                    
                    <!-- ADDWORK POPUP-->
                    <cc1:ModalPopupExtender BehaviorID="ModalPopupExtender2" ID="ModalPopupExtender2" runat="server" PopupControlID="Panl2" TargetControlID="addWorkButton" CancelControlID="ButtonClose" BackgroundCssClass="Background"> </cc1:ModalPopupExtender>
                    <asp:Panel ID="Panl2" runat="server" CssClass="Popup" align="center" Style="display: none">
                        <iframe src="AddWork.aspx" width="100%" height="490px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
                        <br />
                        <asp:Button ID="ButtonClose" runat="server" Text="Zatvori" />
                    </asp:Panel>

                    <!-- EDITWORK POPUP-->
                    <cc1:ModalPopupExtender BehaviorID="EditModalPopupExtender" ID="EditModalPopupExtender" runat="server" PopupControlID="EditPanl" TargetControlID="hdnField" CancelControlID="ButtonCloseEdit" BackgroundCssClass="Background"> </cc1:ModalPopupExtender>
                    <asp:Panel ID="EditPanl" runat="server" CssClass="Popup" align="center" Style="display: none">
                        <iframe src="<%= EditFrameUrl %>" width="100%" height="490px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
                        <br />
                        <asp:Button ID="ButtonCloseEdit" runat="server" Text="Zatvori" />
                    </asp:Panel>

                    <!-- DOLAZNOST POPUP-->
                    <asp:HiddenField ID="hdnField2" runat="server" />
                    <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="Panl3" TargetControlID="hdnField2" CancelControlID="ButtonClose2" BackgroundCssClass="Background"> </cc1:ModalPopupExtender>
                    <asp:Panel ID="Panl3" runat="server" CssClass="Popup" align="center" Style="display: none">
                        <table class="dataTable-table table-striped">
                            <tr style="background-color:lightgreen;">
                                <th><asp:Label runat="server" Text="Ime"></asp:Label></th>
                                <th><asp:Label runat="server" Text="Prezime"></asp:Label></th>
                                <th><asp:Label runat="server" Text="Interes"></asp:Label></th>
                                <th><asp:Label runat="server" Text="Vrijeme Odabira"></asp:Label></th>
                                <th><asp:Label runat="server" Text="Dolaznost"></asp:Label></th>
                            </tr>
                        </table>
                        <asp:Repeater ID="attendanceRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><asp:Label runat="server" Text='<%# Eval ("UserFirstName")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval ("UserLastName")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval ("Interes")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval ("SelectionTime")%>'></asp:Label></td>
                                    <td><asp:Label runat="server" Text='<%# Eval ("Attendance")%>'></asp:Label></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Button ID="ButtonClose2" runat="server" Text="Zatvori" />
                    </asp:Panel>
                
                    <!-- WORK TABLE-->
                    <div class="card-header">
                        <h1>Radne akcije</h1>
                    </div>
                    <div class="card-body">
                        <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                            <div class="dataTable-container">
                                <table class="dataTable-table table-striped">
                                    <tr style="background-color:#93cff5;">
                                        <th width="200px"><asp:Label runat="server" Text="Radna Akcija"></asp:Label></th>
                                        <th><asp:Label runat="server" Text="Opis"></asp:Label></th>
                                        <th><asp:Label runat="server" Text="Datum"></asp:Label></th>
                                        <th><asp:Label runat="server" Text="Vrijeme"></asp:Label></th>
                                        <th><asp:Label runat="server" Text="Lokacija"></asp:Label></th>
                                        <th><asp:Label runat="server" Text="Obveznost"></asp:Label></th>
                                        <th></th><th></th>
                                    </tr>
                                    <asp:Repeater ID="UserWorkList" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><asp:Label runat="server" Text='<%# Eval ("Name")%>'></asp:Label></td>
                                                <td><asp:Label runat="server" Text='<%# Eval ("Description")%>'></asp:Label></td>
                                                <td><asp:Label runat="server" Text='<%# Eval ("Date")%>'></asp:Label></td>
                                                <td><asp:Label runat="server" Text='<%# Eval ("Time")%>'></asp:Label></td>
                                                <td>
                                                    <asp:Button CssClass="locationButton" ID="Button1" runat="server" Text='<%# Eval ("Location")%>' OnClick="locButton_Click" />
                                                </td>
                                                <td><asp:Label runat="server" Text='<%# Eval ("Obligation")%>'></asp:Label></td>
                                                <td>
                                                    <asp:Button ID="editButton" CssClass="workButton" runat="server" Text="Uredi" OnCommand="edit_Command" CommandArgument='<%# Eval ("ID")%>' />
                                                    <asp:Button ID="deleteButton" CssClass="workButton" OnClientClick="return confirm('Jeste li sigurni da želite obrisati radnu akciju?')" runat="server" Text="Zatvori" OnCommand="delete_Command" CommandArgument='<%# Eval ("ID")%>' />
                                                </td>
                                                <td>
                                                    <asp:Button ID="attendanceButton" CssClass="workButton" runat="server" Text="Dolaznost" OnCommand="attendance_Command" CommandArgument='<%# Eval ("ID")%>' />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                        </div>
                    </div>
                </td>

                <td>
                    <div style="padding: 20px;">
                        <asp:Button CssClass="workButton" ID="addWorkButton" runat="server" Text="Dodaj akciju" />
                    </div>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
