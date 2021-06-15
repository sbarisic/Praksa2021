<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="PraksaFront.Registration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">





    <link rel="stylesheet" href="content/css/Register.css" />
   
    <title>Prijava</title>


    <body>
    <form id="form2" runat="server">
        <div class="wrapper">
    <div class="title">
      Registracija
    </div>
    <div class="form">
       <div class="inputfield">
          <label>Ime</label>
          <asp:TextBox ID="txtFirstName" runat="server" placeholder="Unesite ime :" required="required"></asp:TextBox>
       </div>  
        <div class="inputfield">
          <label>Prezime</label>
          <asp:TextBox ID="txtLastName" runat="server" placeholder="Unesite prezime :" required="required"></asp:TextBox>
       </div>
        <div class="inputfield">
          <label>Adresa</label>
          <asp:TextBox ID="txtAdress" runat="server" placeholder="Unesite adresu :" required="required"></asp:TextBox>
       </div> 
        <div class="inputfield">
          <label>Email</label>
          <asp:TextBox ID="txtEmail" runat="server" placeholder="Unesite Email :" required="required" TextMode="Email"></asp:TextBox>
       </div> 
        <div class="inputfield">
          <label>Kontakt broj</label>
          <asp:TextBox ID="txtPhoneNumber" runat="server" placeholder="Unesite kontakt broj :" required="required"></asp:TextBox>
       </div> 
        <div class="inputfield">
          <label>OIB</label>
          <asp:TextBox ID="txtOib" runat="server" placeholder="Unesite Oib :" required="required"></asp:TextBox>
       </div>
        <div class="inputfield">
          <label>Lozinka</label>
          <asp:TextBox ID="txtLozinka" runat="server" placeholder="Unesite lozinku :"  TextMode="Password"></asp:TextBox>
       </div> 
       <div align="center"  class="registration" >
        <asp:Button ID="btnReg" runat="server" Text="Kreiraj korisnički račun" OnClick="btnReg_Click"  />
      </div>
    </div>
</div>
    </form>
</body>
</asp:Content>
