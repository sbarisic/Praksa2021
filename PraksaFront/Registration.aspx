<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="PraksaFront.Registration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <link rel="stylesheet" href="content/css/loginStyle.css" />
      <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
      <title>Registracija</title>
      <style>
         body {
         font-family: "Trebuchet MS", "Lucida Grande", "Lucida Sans Unicode", "Lucida Sans", Tahoma, sans-serif;
         font-size: 24px;
         font-style: normal;
         font-variant: small-caps;
         font-weight: 700;
         line-height: 26.4px;
         }
         .btn.btn-primary {
         background: #448d4e!important;
         border: 1px solid #448d4e!important;
         color: #fff!important;
         }
         .login-wrap .icon{
         background:#448d4e!important;
         }
         .login-wrap h3{
         color:#448d4e!important;
         }
         .fontGreen{
            color:#448d4e!important;
        }
      </style>
   </head>
   <body style="background: url(content/Img/paviljon.jpg); background-size: cover; background-repeat: no-repeat; background-position: center;">
      <form runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <section class="ftco-section">
            <div class="container">
               <div class="row justify-content-center">
                  <div class="col-md-6 col-lg-5">
                     <div class="login-wrap p-4 p-md-5">
                        <div class="icon d-flex align-items-center justify-content-center">
                           <span class="fa fa-user-o"></span>
                        </div>
                        <h3 class="text-center mb-4">Registracija</h3>
                        <div action="#" class="login-form">
                           <div class="form-group">
                            <asp:Label CssClass="fontGreen" runat="server" Text="Ime"></asp:Label>
                              <asp:TextBox ID="txtFirstName" CssClass="form-control rounded-left" runat="server" placeholder="Ime..." required="required"></asp:TextBox>
                           </div>
                           <div class="form-group">
<asp:Label CssClass="fontGreen" runat="server" Text="Prezime"></asp:Label>
                              <asp:TextBox ID="txtLastName" CssClass="form-control rounded-left" runat="server" placeholder="Prezime..." required="required"></asp:TextBox>
                           </div>
                           <div class="form-group">
<asp:Label CssClass="fontGreen" runat="server" Text="Adresa"></asp:Label>
                              <asp:TextBox ID="txtAdress" CssClass="form-control rounded-left" runat="server" placeholder="Adresa..." required="required"></asp:TextBox>
                           </div>
                           <div class="form-group">
<asp:Label CssClass="fontGreen" runat="server" Text="Email"></asp:Label>
                              <asp:TextBox ID="txtEmail" CssClass="form-control rounded-left" runat="server" placeholder="Email..." required="required" TextMode="Email"></asp:TextBox>
                           </div>
                           <div class="form-group">
<asp:Label CssClass="fontGreen" runat="server" Text="Kontakt broj"></asp:Label>
                              <asp:TextBox ID="txtPhoneNumber" CssClass="form-control rounded-left" runat="server" placeholder="Kontakt broj..." required="required"></asp:TextBox>
                              <cc1:FilteredTextBoxExtender ID="PhoneFilter" runat="server" FilterType="Numbers, Custom"
                                 ValidChars="+/-()[]{}" TargetControlID="txtPhoneNumber" />
                           </div>
                           <div class="form-group">
<asp:Label CssClass="fontGreen" runat="server" Text="OIB"></asp:Label>
                              <asp:TextBox pattern=".{11}" CssClass="form-control rounded-left" ID="txtOib" runat="server" placeholder="OIB..." required="required" title="Polje mora imati 11 znamenki" 
                                 onkeydown = "return (!((event.keyCode>=65 && event.keyCode <= 95) || event.keyCode >= 106 || (event.keyCode >= 48 && event.keyCode <= 57  && isNaN(event.key))) && event.keyCode!=32);"> </asp:TextBox>
                           </div>
                           <div class="form-group">
<asp:Label CssClass="fontGreen" runat="server" Text="Lozinka"></asp:Label>
                              <asp:TextBox ID="txtLozinka" CssClass="form-control rounded-left" runat="server" placeholder="Lozinka..." TextMode="Password"></asp:TextBox>
                              <div visible="false" id="errorPassword" runat="server" class="alert alert-danger alert-dismissible" style="width: 300px; position:absolute; padding: 8px;">
                                 <a href="#" class="close" data-dismiss="alert" aria-label="close" onclick='this.parentNode.parentNode.removeChild(this.parentNode); return false;'>&times;</a>
                                 <strong>Greška!</strong> Lozinka mora imati barem 8 znakova.
                              </div>
                           </div>
                           <div class="form-group d-flex">
                              <asp:TextBox ID="txtLozinka2" CssClass="form-control rounded-left" runat="server" placeholder="Ponovite lozinku..." TextMode="Password"></asp:TextBox>
                           </div>
                           <div class="form-group d-flex">
                              <asp:Button  ID="btnReg" CssClass="form-control btn btn-primary submit px-3" runat="server" Text="Potvrdi" OnClick="btnReg_Click" />
                              <br /><br />
                           </div>
                           <div class="form-group">
                              <br />
                              <asp:Button  ID="btnCancel" CssClass="form-control btn btn-primary submit px-3" UseSubmitBehavior="false" runat="server" Text="Odustani" OnClick="btnCancel_Click" />
                              </td>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </section>
      </form>
   </body>