<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="PraksaFront.WebForm4" %>



<!DOCTYPE html>  
  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title></title>  
</head>  
<body>  
    <form id="form1" runat="server">  
        <div>  
            <table class="auto-style1">  
                <tr>  
                    <td>Ime :</td>  
                    <td>  
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>  
                    </td>  
  
               </tr>  
                <tr>  
                    <td>Prezime :</td>  
                    <td>  
                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>  
                    </td>  
  
               </tr>  
                 <tr>  
                    <td>Lozinka :</td>  
                     <td> <asp:TextBox ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox></td>  
                </tr>  
                <tr> 
                <tr>  
                    <td>Email :</td>  
                     <td> <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>  
                </tr>  
                <tr>  
                    <td>Broj mobitela</td>  
                    <td>  
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>  
                    </td>  
                </tr> 
                <tr>  
                    <td>OIB :</td>  
                    <td>  
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>  
                    </td>  
                </tr>  
                <tr>  
                    <td>City</td>  
                    <td>  
                        <asp:DropDownList ID="DropDownList1" runat="server">  
                            <asp:ListItem Text="Select City" Value="select" Selected="True"></asp:ListItem>  
                            <asp:ListItem Text="Bangalore" Value="Bangalore"></asp:ListItem>  
                            <asp:ListItem Text="Mysore" Value="Mysore"></asp:ListItem>  
                            <asp:ListItem Text="Hubli" Value="hubli"></asp:ListItem>  
                        </asp:DropDownList>  
                    </td>  
                </tr>  
                <tr>  
                    <td>Gender</td>  
                    <td>  
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">  
                            <asp:ListItem>Male</asp:ListItem>  
                            <asp:ListItem>Female</asp:ListItem>  
                        </asp:RadioButtonList>  
                    </td>  
               </tr>  
                <tr>  
                    <td>Gmail</td>  
                    <td>  
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>  
                    </td>  
                </tr>  
                <tr>  
                    <td>  
                        <asp:Button ID="Button1" runat="server" Text="Button" />  
                    </td>  
                </tr>  
            </table>  
        </div>  
    </form>  
</body>  
</html>  