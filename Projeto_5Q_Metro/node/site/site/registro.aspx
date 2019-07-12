 &nbsp; <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="site.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/5qRe.css"/>
    <link rel="icon" href="img/logo-2.png"/><!--icone da pagina-->
</head>
<!--============================================================================================-->
<body style="background-image:url(fundoregistro.jpg)">
    <form id="form1" runat="server">
        <div>

            <img src="img/logo-2.png"  style="margin-left: 2%; margin-top: 2%;height:23%; width:20%;"/>
            
            <div class="div" style=" display: flex; flex-direction:column">
                <!---- logo da tela-->
                <div class="div1">
                    <div id="aviso">

                        <asp:Label Text="preencha todos os espaços" ID="Label2" runat="server" 
                        Style="margin-left:20%" ForeColor="Red" Visible="false" ></asp:Label>
                   
                        <asp:Label Text="seu id nao contem apenas numeros." ID="btnidlabel" runat="server" 
                        Style="margin-left:20%" ForeColor="Red" Visible="false"></asp:Label>

                        <asp:Label Text="Suas senhas nao batem." ID="btnlabel" runat="server"
                        Style="margin-left:20%"   ForeColor="Red" Visible="false"></asp:Label> 
                    </div>

                        <!----- mensagens de erro ---->
                        <asp:TextBox placeholder="Digite o nome completo" ID="btnNome" runat="server"
                        Height="10%" Width="70%"></asp:TextBox>                
                    
                       <asp:TextBox placeholder="Digite a senha" runat="server"
                       ID="btnSenha" Height="10%" Width="70%" ></asp:TextBox>
               
                
                       <asp:TextBox placeholder="Confirme a senha" runat="server"
                       ID="btnSenha1" Height="10%" Width="70%"></asp:TextBox>

                       <asp:TextBox placeholder="ID" runat="server"
                       ID="btnId" Height="10%" Width="70%"></asp:TextBox> 
                 
                      <asp:DropDownList
                          ID="DropDownList1" runat="server" AutoPostBack="true" BackColor="Gray"
                          BorderStyle="Solid" BorderColor="#666666" Font-Names="Georgia" ForeColor="Black"
                          style="margin-top:10%; margin-left:15%">
                                            <asp:ListItem Text="cargos" Value="0"> </asp:ListItem>
                                            <asp:ListItem Text="n1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="n2" value="2"></asp:ListItem> 
                      </asp:DropDownList>
                      <!--- formulario ---->

                      <asp:Button Text="Confirmar" runat="server" ID="btnConfirmar"
                      Font-Size="16" BorderStyle="Outset" BackColor="gray"
                      ForeColor="#333333"  OnClick="btnConfirmar_Click" Height="15%" Width="70%"/>
                
                      <!----evento registro.aspx.cs----> 
                </div>
            </div>            
        </div>
    </form>
</body>
</html>
