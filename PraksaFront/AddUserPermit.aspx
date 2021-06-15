<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserPermit.aspx.cs" Inherits="PraksaFront.AddUserPermit" %>

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
        <div class="card-body">
            <table class="dataTable-table table-striped">
                <asp:Repeater ID="PermitRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><asp:HiddenField ID="hdnField" Value='<%# Eval("Name") %>' runat="server" />
                            <asp:HiddenField ID="hdnId" Value='<%# Eval("Id") %>' runat="server" />
                            <asp:CheckBox ID="permitCheckbox" runat="server" Text='<%# Eval("Name")%>' AutoPostback="true" OnCheckedChanged="permitCheckbox_CheckedChanged"/></td>
                            
                            <td>
                            <asp:TextBox CssClass="padded" ID="txtDate" runat="server" Placeholder="Datum isteka dozvole..." Enabled="false"></asp:TextBox>
                            <asp:TextBox CssClass="padded" ID="txtNumber" runat="server" Placeholder="Broj dozvole..." Enabled="false" ></asp:TextBox></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr><td colspan="2" style="text-align:center;">
                    <asp:Button CssClass="workButton" Style="display: inline-block; text-align: center; margin-right: 10px;" ID="BtnSubmit" runat="server" Text="Potvrdi" OnClick="BtnSubmit_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
