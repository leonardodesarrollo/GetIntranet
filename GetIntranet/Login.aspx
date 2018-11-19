<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GetIntranet.Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8"/>
    <title>Login - Intranet</title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no"/>
    <meta name="apple-mobile-web-app-capable" content="yes"/>

    <link href="Assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Assets/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />

    <link href="Assets/css/font-awesome.css" rel="stylesheet"/>
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600" rel="stylesheet"/>

    <link href="Assets/css/style.css" rel="stylesheet" type="text/css"/>
    <link href="Assets/css/pages/signin.css" rel="stylesheet" type="text/css"/>
</head>
<body>

    
	<div class="navbar navbar-fixed-top">
	
	<div class="navbar-inner">
		
		<div class="container">
			
			<a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
				<span class="icon-bar"></span>
				<span class="icon-bar"></span>
				<span class="icon-bar"></span>
			</a>
			
			<a class="brand" href="index.html">
				 Tagor Intranet		
			</a>		
			
			<div class="nav-collapse">
				<ul class="nav pull-right">
					
					<%--<li class="">						
						<a href="signup.html" class="">
							Don't have an account?
						</a>
					</li>
					
					<li class="">						
						<a href="index.html" class="">
							<i class="icon-chevron-left"></i>
							Back to Homepage
						</a>
						
					</li>--%>
				</ul>
				
			</div><!--/.nav-collapse -->	
	
		</div> <!-- /container -->
		
	</div> <!-- /navbar-inner -->
	
</div> <!-- /navbar -->



    
<div class="account-container">
	
	<div class="content clearfix">
		
		<form id="form1" runat="server">
		<asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/Scripts/AjaxControlToolkit/Bundle" />

                <%--Framework Scripts--%>
            <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
            <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
            <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
            <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
            <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
            <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
            <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
            <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
            <asp:ScriptReference Name="WebFormsBundle" />
            <%--Site Scripts--%>

            </Scripts>
        </asp:ScriptManager>
			<h1>Ingreso de Usuarios</h1>		
			
			<div class="login-fields">
				
				<p>Por favor proporcione sus datos</p>
				
				<div class="field">
					<label for="username">Usuario:</label>
					<input runat="server"  type="text" id="TxtUsuario" name="username" value="" placeholder="Nombre de Usuario" class="login username-field" />
				</div> <!-- /field -->
				
				<div class="field">
					<label for="password">Password:</label>
					<input runat="server" type="password" id="TxtPassword" name="password" value="" placeholder="Password" class="login password-field"/>
				</div> <!-- /password -->
				
			</div> <!-- /login-fields -->
			
			<div class="login-actions">
				
<%--				<span class="login-checkbox">
					<input id="Field" name="Field" type="checkbox" class="field login-checkbox" value="First Choice" tabindex="4" />
					<label class="choice" for="Field">Keep me signed in</label>
				</span>--%>
									
                <asp:Button runat="server" ID="BtnIngresar" OnClick="BtnIngresar_Click" CssClass="button btn btn-success btn-large" Text="Ingresar" />
				
			</div> <!-- .actions -->
			 <asp:Button ID="btnActivarPopUp" runat="server" Style="display: none" />
            <asp:ModalPopupExtender ID="mdlInformacion" BackgroundCssClass="modalBackground" runat="server" PopupControlID="pnlInformacion" TargetControlID="btnActivarPopUp" BehaviorID="_mdlInformacion">
            </asp:ModalPopupExtender>
            <asp:Panel ID="pnlInformacion" runat="server" Style="display: none; background: white; width: 40%; height: auto">
                <%--MODALPOPUP CON BOOTSTRAP--%>
                <div class="modal">
                    <div class="modal-header">
                        <button class="close" data-dismiss="modal" aria-hidden="true">x</button>
                        <h3 id="myModalLabel">Informacion</h3>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblInformacion" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
                <%--MODALPOPUP CON BOOTSTRAP--%>
            </asp:Panel>
			
			
		</form>
		
	</div> <!-- /content -->
	
</div> <!-- /account-container -->


<div class="login-extra">
	<a href="#">Olvidó su contrasena?</a>
</div> <!-- /login-extra -->


<script src="Assets/js/jquery-1.7.2.min.js"></script>
<script src="Assets/js/bootstrap.js"></script>

<script src="Assets/js/signin.js"></script>
</body>
</html>
