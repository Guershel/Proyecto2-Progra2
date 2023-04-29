<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="Proyecto_2.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Proyecto 2</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

	<link href="https://fonts.googleapis.com/css?family=Lato:300,400,700&display=swap" rel="stylesheet"/>

	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
	
	<link rel="stylesheet" href="css/style.css"/>
</head>
<body class="img js-fullheight" style="background-image: url(images/bg.jpg);" runat="server">
	<section class="ftco-section">
		<div class="container">
			<div class="row justify-content-center">
				<div class="col-md-6 text-center mb-5">
					<h2 class="heading-section">PROYECTO GRUPO 3</h2>
				</div>
			</div>
			<div class="row justify-content-center">
				<div class="col-md-6 col-lg-4">
					<div class="login-wrap p-0">
		      	<h3 class="mb-4 text-center">Ingrese su cuenta</h3>
		      	<form action="#" class="signin-form" runat="server">
		      		<div class="form-group">
						<asp:TextBox ID="TUsuario" type="text" class="form-control" placeholder="Usuario" required runat="server" ></asp:TextBox>
		      		</div>
	            <div class="form-group" runat="server">
					<asp:TextBox ID="TPassword" type="password" class="form-control" placeholder="Contraseña" required runat="server"></asp:TextBox>
	              <span toggle="#password-field" class="fa fa-fw fa-eye field-icon toggle-password"></span>
	            </div>
	            <div class="form-group">
					<asp:Button ID="BIngresar" type="submit" class="form-control btn btn-primary submit px-3" runat="server" Text="Ingresar" OnClick="BIngresar_Click1" />
	            </div>
					  <div>
						  <asp:Label ID="lmensaje" runat="server" Text=""></asp:Label>
					  </div>
	            <div class="form-group d-md-flex">
	            	<div class="w-50">
		            	<label class="checkbox-wrap checkbox-primary">Remember Me
									  <input type="checkbox" checked/>
									  <span class="checkmark"></span>
									</label>
								</div>
								<div class="w-50 text-md-right">
									<a href="#" style="color: #fff">Forgot Password</a>
								</div>
	            </div>
	          </form>
	          
		      </div>
				</div>
			</div>
		</div>
	</section>

	<script src="js/jquery.min.js"></script>
  <script src="js/popper.js"></script>
  <script src="js/bootstrap.min.js"></script>
  <script src="js/main.js"></script>

</body>
</html>
