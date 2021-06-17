<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserPermit.aspx.cs" Inherits="PraksaFront.AddUserPermit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="content/css/home.css" />
    <style>
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <script>
            function callParentWindowHideMethod() {
                if (window.parent.hideEditModalPopup) {
                    window.parent.hideEditModalPopup();
                }
            }
            function checkDate(sender, args) {
                if (sender._selectedDate < new Date()) {
                    alert("Ne možete odabrati dan u prošlosti.");
                    sender._selectedDate = new Date();
                    // set the date back to the current date
                    sender._textbox.set_Value(sender._selectedDate.format(sender._format))
                }
            }
        </script>
        <div class="card-body">
            <table class="dataTable-table table-striped">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:Repeater ID="PermitRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:HiddenField ID="hdnField" Value='<%# Eval("Name") %>' runat="server" />
                                <asp:HiddenField ID="hdnId" Value='<%# Eval("Id") %>' runat="server" />
                                <asp:CheckBox ID="permitCheckbox" runat="server" Text='<%# Eval("Name")%>' AutoPostBack="true" OnCheckedChanged="permitCheckbox_CheckedChanged" /></td>

                            <td>
                                    <asp:TextBox autocomplete="off" CssClass="padded" Width="300px" Placeholder="Datum isteka dozvole..." ID="txtDate" runat="server" Enabled="false"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                        OnClientDateSelectionChanged="checkDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>

                                <asp:TextBox CssClass="padded" ID="txtNumber" runat="server" Placeholder="Broj dozvole..." Enabled="false"></asp:TextBox></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button CssClass="workButton" Style="display: inline-block; text-align: center; margin-right: 10px;" ID="BtnSubmit" runat="server" Text="Potvrdi" OnClick="BtnSubmit_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
