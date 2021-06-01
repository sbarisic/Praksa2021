<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserWork.aspx.cs" Inherits="PraksaFront.RadneAkcije" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="styled-table">
<tr>
    <th width="500px">
        Radna Akcija
    </th>
    <th>
        Datum
    </th>
    <th>
        Vrijeme
    </th>
    <th>
        Prisutnost
    </th>
</tr>
    <tr>
        <td> <!--temp hardkodirane vrijednosti-->
            Branje Jabuka
        </td>
        <td>
            25.06.2021
        </td>
        <td>
            16:30h
        </td>
        <td>
            <asp:Button ID="Button1" runat="server" Text="Dolazim" />
            <asp:Button ID="Button2" runat="server" Text="Ne dolazim" />
            <asp:Button ID="Button3" runat="server" Text="Mozda dolazim" />
        </td>
    </tr>
    <tr>
        <td>
            Košnja Trave
        </td>
        <td>
            02.06.2021
        </td>
        <td>
            23:45h
        </td>
        <td>
            <asp:Button ID="Button4" runat="server" Text="Dolazim" />
            <asp:Button ID="Button5" runat="server" Text="Ne dolazim" />
            <asp:Button ID="Button6" runat="server" Text="Mozda dolazim" />
        </td>
    </tr>
</table>
        </div>
    </form>
</body>
</html>
