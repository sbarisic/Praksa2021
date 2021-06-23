<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logout.aspx.cs" Inherits="logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Logout</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="div1">
        <asp:Label ID="Label1" runat="server" Text="Odjava uspješna!"></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/about.aspx">
            Preusmjeriti ćemo vas za 5 sekundi, ako ste govno nestrpljivo kliknite ovdje!.</asp:HyperLink>
    </div>
    </form>
</body>
</html> 