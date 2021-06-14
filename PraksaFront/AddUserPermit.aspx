<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserPermit.aspx.cs" Inherits="PraksaFront.AddUserPermit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="PermitRepeater" runat="server">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnField" Value="<%# Eval("PermitName") %>" runat="server" />
                    <asp:CheckBox ID="permitCheckbox" Checked='<%# Convert.ToBoolean(checkPermit(Convert.ToString(Eval("PermitName")))) %>' runat="server" Text='<%# Eval("PermitName") + ", " + Eval("ExpiryDate")%>' />
                    <br />
                </ItemTemplate>
            </asp:Repeater>
            <asp:Button CssClass="workButton" Style="display: inline-block; text-align: center; margin-right: 10px;" ID="BtnSubmit" runat="server" Text="Potvrdi" OnClick="BtnSubmit_Click" />
        </div>
    </form>
</body>
</html>
