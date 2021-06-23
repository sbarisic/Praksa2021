<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PastWork.aspx.cs" Inherits="PraksaFront.PastWork" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
    <link href="content/css/home.css" rel="stylesheet" />
    <title>Arhivirani poslovi</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <!-- LOKACIJA POPUP-->
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Button runat="server" ID="hdnBtn" ClientIDMode="Static" Text="" Style="display: none;" OnClick="hdnBtn_Click" />
        <asp:HiddenField ID="hdnField" runat="server" />
        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panl1" TargetControlID="hdnField" CancelControlID="Button2" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
        <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
            <iframe src="<%= url%>" width="100%" height="490px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Zatvori" OnClientClick="hideEditModalPopup();" />
        </asp:Panel>

        <!-- DOLAZNOST POPUP-->
        <asp:HiddenField ID="hdnField2" runat="server" />
        <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="Panl3" TargetControlID="hdnField2" CancelControlID="ButtonClose2" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
        <asp:Panel ID="Panl3" runat="server" CssClass="Popup" align="center" Style="display: none">
            <iframe src="<%= AttendanceFrameUrl %>" width="100%" height="490px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
            <br />
            <asp:Button ID="ButtonClose2" runat="server" Text="Zatvori" OnClientClick="hideEditModalPopup();" />
        </asp:Panel>

        <!-- WORK TABLE-->
        <div class="card-header">
            <h1>Radne akcije</h1>
        </div>
        <div class="card-body">
            <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                <div class="dataTable-container">
                    <table class="dataTable-table table-striped">
                        <tr style="background-color: #6bc277;">
                            <th width="200px">
                                <asp:Label runat="server" Text="Radna Akcija"></asp:Label></th>
                            <th>
                                <asp:Label runat="server" Text="Opis"></asp:Label></th>
                            <th>
                                <asp:Label runat="server" Text="Datum"></asp:Label></th>
                            <th>
                                <asp:Label runat="server" Text="Vrijeme"></asp:Label></th>
                            <th>
                                <asp:Label runat="server" Text="Lokacija"></asp:Label></th>
                            <th>
                                <asp:Label runat="server" Text="Obveznost"></asp:Label></th>
                            <th></th>
                        </tr>
                        <asp:Repeater ID="UserWorkList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" Text='<%# Eval ("Name")%>'></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" Text='<%# Eval ("Description")%>'></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" Text='<%# Eval ("Date")%>'></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" Text='<%# Eval ("Time")%>'></asp:Label></td>
                                    <td>
                                        <asp:Button CssClass="locationButton" ID="Button1" runat="server" Text='<%# Eval ("Location")%>' OnClick="locButton_Click" />
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text='<%# Eval ("Obligation")%>'></asp:Label></td>
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
    </div>
</asp:Content>
