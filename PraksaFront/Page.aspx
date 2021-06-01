<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="PraksaFront.Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>

	<link rel="stylesheet" href="content/css/bootstrap.css" />
	<link rel="stylesheet" href="content/page.css" />
</head>
<body>
	<form class="form-inline center-form" runat="server">
		<div class="form-group mb-2">
			<label for="staticEmail2" class="sr-only">Email</label>
			<input type="text" readonly="readonly" class="form-control-plaintext" id="staticEmail2" value="email@example.com" />
		</div>

		<div class="form-group mx-sm-3 mb-2" runat="server">
			<label for="inputPassword2" class="sr-only">Password</label>
			<input type="password" class="form-control" id="inputPassword2" placeholder="Password" runat="server" />
		</div>


		<asp:Button CssClass="btn btn-primary mb-2" runat="server" OnClick="OnConfirm" Text="Confirm identity" />
		<span id="status_label" runat="server">Success</span>
	</form>

	<script src="content/js/bootstrap.bundle.js"></script>
</body>
</html>
