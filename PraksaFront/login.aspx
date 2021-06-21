<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PraksaFront.WebForm1" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="content/css/loginStyle.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <title>Prijava</title>
    <style>
        .login-wrap2 {
  position: relative;
background: rgb(69,144,91);
background: linear-gradient(0deg, rgba(69,144,91,.95) 0%, rgba(91,198,122,.95) 100%);
  border-radius: 20px;
  padding: 50px;
  -webkit-box-shadow: 0px 10px 34px -15px rgba(0, 0, 0, 0.24);
  -moz-box-shadow: 0px 10px 34px -15px rgba(0, 0, 0, 0.24);
  box-shadow: 0px 10px 34px -15px rgba(0, 0, 0, 0.24); }
        body:after{
            opacity: 0.1;
        }
        body{
            font-family: "Trebuchet MS", "Lucida Grande", "Lucida Sans Unicode", "Lucida Sans", Tahoma, sans-serif; font-size: 24px; font-style: normal; font-variant: small-caps; font-weight: 700; line-height: 26.4px;
        }
    </style>
</head>
<body style="background:url(content/Img/paviljon.jpg); background-size:100%;">
    <form runat="server">
    <section class="ftco-section">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6 text-center mb-5">
                    <h1 style="font-size: 35px;" class="heading-section">Bjelovarska Udruga</h1>
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-md-6 col-lg-4">
                    <div class="login-wrap2 py-5">
                        <h3 class="mb-4 text-center" style="color:white;">prijavi se</h3>
                        <div class="signin-form">
                            <div class="form-group">
                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" Placeholder="Email..."></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" Placeholder="Password..."></asp:TextBox>
                                <span toggle="#password-field" class="fa fa-fw fa-eye field-icon toggle-password"></span>
                                <asp:Label ID="lblErrorMessage" runat="server" Text="Pogrešan unos korisničkih podataka" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnLogin" CssClass="form-control btn btn-primary submit px-3" runat="server" Text="Prijava" OnClick="btnLogin_Click" /> <br /><br />
                                <asp:Button ID="btnRegister" CssClass="form-control btn btn-primary submit px-3" runat="server" Text="Registracija" OnClick="btnRegister_Click" />
                            </div>
                            <div class="form-group d-md-flex">
                                <div class="w-50 text-md-right">
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    </form>
</body>
</html>
