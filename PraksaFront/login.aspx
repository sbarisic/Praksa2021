<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PraksaFront.WebForm1" %>

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
			<h1>Prijava</h1>
				<form method="post">
    				<input type="text" name="u" placeholder="Korisničko ime" required="required" />
					<input type="password" name="p" placeholder="Lozinka" required="required" />
					<button type="submit" class="btn btn-primary btn-block btn-large">Prijavi se</button>
				</form>
					</div>
			</form><!-- form -->
			
					
					</section><!-- content -->
		</div><!-- container -->
</body>
</html>
