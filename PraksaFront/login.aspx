<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PraksaFront.WebForm1" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="content/css/loginStyle.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <title>Prijava</title>
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
    </style>
</head>
<body style="background: url(content/Img/paviljon.jpg); background-size: 100%;">
    <form runat="server">
        <section class="ftco-section">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-6 col-lg-5">
                        <div class="login-wrap p-4 p-md-5">
                            <div class="icon d-flex align-items-center justify-content-center">
                                <span class="fa fa-user-o"></span>
                            </div>
                            <h3 class="text-center mb-4">Prijavite se</h3>
                            <div action="#" class="login-form">
                                <div class="form-group">
                                    <asp:TextBox ID="txtEmail" CssClass="form-control rounded-left" runat="server" Placeholder="Email..."></asp:TextBox>
                                </div>
                                <div class="form-group d-flex">
                                    <asp:TextBox ID="txtPassword" CssClass="form-control rounded-left" runat="server" TextMode="Password" Placeholder="Lozinka..."></asp:TextBox>
                                    <asp:Label ID="lblErrorMessage" runat="server" Text="Pogrešan unos korisničkih podataka" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="form-group d-flex">
                                    <asp:Button ID="btnLogin" CssClass="form-control btn btn-primary submit px-3" runat="server" Text="Prijava" OnClick="btnLogin_Click" />
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <br />
                                    <asp:Button ID="btnRegister" CssClass="form-control btn btn-primary submit px-3" runat="server" Text="Registracija" OnClick="btnRegister_Click" />
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
