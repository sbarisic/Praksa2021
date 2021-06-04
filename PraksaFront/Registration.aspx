<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="PraksaFront.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="content/css/Login.css" />
    <title>Prijava</title>

</head>
<body>
    <div class="login">
        <section id="content">
            <form id="form1" runat="server">
                <h1>Registracija</h1>
                <form method="post">
                    <input type="text" name="ime" placeholder="Ime" required="required" />
                    <input type="text" name="prezime" placeholder="Prezime" required="required" />
                    <input type="text" name="email" placeholder="E-Mail" required="required" />
                    <input type="text" name="contact" placeholder="Kontakt broj" required="required" />
                    <input type="text" name="oib" placeholder="OIB" required="required" />
                    <input type="password" name="p" placeholder="Lozinka" required="required" />
                    <input type="password" name="p2" placeholder="Potvrdi lozinku" required="required" />
                    <button type="submit" class="btn btn-primary btn-block btn-large">Kreiraj korisnički račun</button>
                </form>
    </form><!-- form -->

    </section><!-- content -->
    </div><!-- container -->
</body>
</html>
