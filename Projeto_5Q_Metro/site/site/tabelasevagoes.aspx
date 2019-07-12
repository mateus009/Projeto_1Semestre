<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tabelasevagoes.aspx.cs" Inherits="site.tabelasevagoes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <link rel="stylesheet" href="css/registrovagao.css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           
               <div id="divao">
                   <asp:TextBox placeholder="coloque o Nome do trem aqui" ID="Trem" runat="server"> </asp:TextBox>
                    <asp:TextBox placeholder="Amarela" ID="linha" runat="server" TextMode="SingleLine" ViewStateMode="Inherit" ReadOnly="True"></asp:TextBox>
         <asp:Button Text="Registrar trem" ID="registrotrem" runat="server" OnClick="registrotrem_Click"/>

                   </div>
               <div  id="metro">
                 
                   <asp:TextBox placeholder="coloque o nome dos vagoes" ID="nomevagao" runat="server" MaxLength="5" ></asp:TextBox>
                   <asp:TextBox placeholder="coloque a quantidade de vagoes" ID="quantidade" runat="server"></asp:TextBox>
                  
                   <asp:Button Text="registrar vagoes" ID="registrovagao" OnClick="registrovagao_Click" runat="server" />


                  
                   <asp:DropDownList placeholder="trens"  ID="trens" runat="server">
                      <asp:ListItem text="trens" value="0"></asp:ListItem>
                   </asp:DropDownList>  
                   <!-----aqui é o dropdown, ele ira gerar automaticamente apartir dos dados registrados no banco de dados,
                       ele nao ira aparecer aqui --->
                       
               </div>
      
        </div>
    </form>
</body>
</html>
