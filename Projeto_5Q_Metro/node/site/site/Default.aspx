<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="site.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/login.css"/>
    <link rel="icon" href="img/logo-2.png"/><!--icone da pagina-->
</head>
<body>
    <form id="form1" runat="server">
		<img src="img/logo-2.png"/>
        <div id="main">            
			<asp:TextBox runat="server" id="txtLogin" placeholder="Digite seu login"/>
			<asp:TextBox runat="server" id="txtSenha" placeholder="Digite sua senha"/>
			<asp:Button Text="Entrar" runat="server" id="btnEntrar" OnClick="btnEntrar_Click"/>
        </div>
		<asp:Label Text="" runat="server" ID="lblInvalido" style="color:red;
		font-weight:bold;"/>
    </form>
</body>
</html>
