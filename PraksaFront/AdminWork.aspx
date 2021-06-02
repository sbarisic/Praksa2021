<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AdminWork.aspx.cs" Inherits="PraksaFront.AdminWork" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <form id="form1" runat="server">
        <div style="width: 80%; float: left;">
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
</tr>
    <tr>
        <td> <!--temp hardkodirane vrijednosti-->
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
            <asp:Button ID="Button3" runat="server" Text="Uredi" />
            <asp:Button ID="Button4" runat="server" Text="Obriši" />
        </td>
    </tr>
</table>
        </div>
            <div style="width: 20%;margin-top: 20px;float: left;">
        <asp:Button ID="Button5" runat="server" Text="Dodaj akciju" />
    </div>
    </form>

</body>
</html>

</asp:Content>
