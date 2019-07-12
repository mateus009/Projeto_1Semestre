&nbsp; <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="site.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/cadUsuario.css"/>
    <link rel="icon" href="img/logo-2.png"/><!--icone da pagina-->
</head>
<body>
    <form id="form1" runat="server">
            <div class="modalCadastro">
                <h1 align="center">Cadastro de usuários</h1>
                <div id="corpo">
                    <%-- Botoões, campos e dropDownList --%>
                    <asp:TextBox placeholder="Digite o nome completo" ID="txtNome" runat="server" /> 
                    
                    <asp:TextBox runat="server" ID="txtLogin" placeholder="Digite o login"/>

                    <asp:TextBox placeholder="Digite a senha" runat="server" ID="txtSenha" />
               
                    <asp:TextBox placeholder="Confirme a senha" runat="server" ID="txtConfirmarSenha" />
                 
                    <asp:DropDownList ID="dropDownList" runat="server" AppendDataBoundItems="true"
                        OnSelectedIndexChanged="dropDownList_SelectedIndexChanged"/>
                    <!-- Botão para cadastrar -->
                    <asp:Button Text="Confirmar" runat="server" ID="btnConfirmar" OnClick="btnConfirmar_Click" />
                    <!--Mensagem de erro -->
                    <asp:Label Text="" runat="server" ID="lblErro"/>
                </div>
            </div>            
    </form>
</body>
</html>
