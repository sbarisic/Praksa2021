<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminWork.aspx.cs" Inherits="PraksaFront.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 90%; float: left;">
            <table class="styled-table">
<tr>
    <th width="250px">
        Radna Akcija
    </th>
    <th>
        Datum
    </th>
     <th>
        Vrijeme
    </th>
</tr>
    <tr>
        <td style="text-align:center"> <!--temp hardkodirane vrijednosti-->
            Branje Jabuka
        </td>
        <td>
            25.06.2021
        </td>
        <td>
            15:30h
        </td>
        <td>
            <asp:Button ID="Button1" runat="server" Text="Uredi" />
            <asp:Button ID="Button2" runat="server" Text="Obriši" />
        </td>

    </tr>
    <tr>
        <td style="text-align:center">
            Košnja Trave
        </td>
        <td>
            02.06.2021
        </td>
        <td>
            23:45h
        </td>
        <td>
            <asp:Button ID="Button3" runat="server" Text="Uredi" />
            <asp:Button ID="Button4" runat="server" Text="Obriši" />
        </td>
    </tr>
</table>
        </div>
            <div style="width: 10%; margin-top: 50px; float: left;">
        <asp:Button ID="Button5" runat="server" Text="Nova akcija" />
    </div>
    </form>
</body>
</html>
