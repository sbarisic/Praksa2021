<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserPermit.aspx.cs" Inherits="PraksaFront.AddUserPermit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="content/css/home.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="card-body">
            <table class="dataTable-table table-striped">
                <asp:Repeater ID="PermitRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <asp:HiddenField ID="hdnField" Value='<%# Eval("Name") %>' runat="server" />
                            <asp:HiddenField ID="hdnId" Value='<%# Eval("Id") %>' runat="server" />
                            <asp:CheckBox ID="permitCheckbox" runat="server" Text='<%# Eval("Name")%>' />
                            <br />
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr><td>
                    <asp:Button CssClass="workButton" Style="display: inline-block; text-align: center; margin-right: 10px;" ID="BtnSubmit" runat="server" Text="Potvrdi" OnClick="BtnSubmit_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
