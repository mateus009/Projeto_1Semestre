﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home2.aspx.cs" Inherits="site.Home2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/bootstrap.min.css" type="text/css" rel="stylesheet"/>
    <link href="css/home3.css" type="text/css" rel="stylesheet"/>
    <link href="css/home.css" type="text/css" rel="stylesheet" />
    <link href="css/registrovagao2.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" href="css/fontawesome-all.min.css"/>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">

        google.charts.load('current', { packages: ['corechart', 'line'] });
        google.charts.setOnLoadCallback(desenharGrafico);

        var total = 0, grafico = null, data = null;
        var options = {
                'backgroundColor': 'transparent'
        };

        function desenharGrafico() {
            if (data == null) {
                data = new google.visualization.DataTable();
                data.addColumn('number', 'Tempo');
                data.addColumn('number', 'ºC');

                grafico = new google.visualization.LineChart(document.getElementById('grafico'));
            }

            grafico.draw(data,options, { title: "Temperaturas em Tempo Real" });

            setTimeout(function () {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json',
                    url: 'home.aspx/TemperaturaAtual',
                    data: '{}',
                    success: function (response) {
                        data.addRow([total, response.d]);
                        total++;
                        desenharGrafico();
                    },
                    error: function () {
                    }
                });
            }, 1000);
        }
      

       
    </script>
</head>
<body>
    
    <form id="form1" runat="server">
        <!------------------------------Modais-------------------------->
        <!-- modal do gráfico -->
           <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <div id="myModal1">
	        <div class="modal-content" id="modal-grafico">
                <span class="close">&times;</span>
                <asp:UpdatePanel ID="updatepainel1" runat="server">
                  <ContentTemplate>
                      <!-- esse updatepanel significa que ele vai ficar dando update, ou atualizando de acordo com o tempo
                          que eu der para o <asp:timer> -->
                    <center>
                       <table>
                           <tr>
                               <th> Temperatura Minima</th>
                               <th> Temperatura Maxima</th>
                               <th> Mediana</th>
                               <th> Média</th>
                           </tr>
                           <tr>
                               <td><asp:Label ID="label4" runat="server" ></asp:Label></td>
                               <td><asp:label ID="label3" runat="server"></asp:label></td>
                               <td><asp:label ID="label2" runat="server"></asp:label></td>
                               <td><asp:label ID="label1" runat="server"></asp:label></td>
                               
                           </tr>
                           <!-- tabela das temperaturas -->
                           
                          </table>
                        </center>
                         <asp:Timer ID="timer1" runat="server" Interval="6000" OnTick="timer1_Tick" ></asp:Timer>
                       <asp:Timer ID="timer2" runat="server" Interval="60000" OnTick="timer2_Tick" ClientIDMode="Predictable"></asp:Timer>
                      <asp:Timer ID="timer3" runat="server" Interval="60000" OnTick="timer3_Tick" ></asp:Timer>
                      <asp:Timer ID="timer4" runat="server" Interval="60000" OnTick="timer4_Tick" ></asp:Timer>

        <!-- aqui é o timer, de 60 em 60 segundos ele ira atualizar a tabela -->
        </ContentTemplate>
                    </asp:UpdatePanel>
              <label style="position:fixed; top:50%; left:18%;" >  Temperatura </label>
                 <div id="grafico" style="height:80%; width:98.6%"> 
                     
                    <br />
                 </div> 
                <center>  <label> Tempo</label> </center>
                <div style="margin-left:13.5%"></div>
            </div>
        </div>
        <asp:Label ID="hiddenmodal" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="hiddentemp" runat="server" Visible="false"></asp:Label>
        <!-- modal da tabela de vagões e trens -->
        <div id="myModal2">

	        <div class="modal-content" id="modal-tabela">
                <span class="close2 ">&times;</span>
                 <div id="corpo-trem">
              <label style="margin-left:-10px;"> Selecione o trem:</label>
                 <div id="menu-trem">  
                        <asp:DropDownList ID="dropvagao" runat="server" OnSelectedIndexChanged="dropvagao_SelectedIndexChanged" AutoPostBack="true">       
                    </asp:DropDownList>
                   </div>
               
                 <div id="tabela-vagao">
                    <%if (dropvagao.SelectedValue == "1")
                        { %>
                      <button style="background-color:transparent; border-color:transparent; z-index:2;width:3%; height:4%;
                                   position:fixed; right:73.3%; margin-top:3%;" id="modalgraficovagao" type="button" class="btn btn-default"></button>
                                  <%} %>
                  
                          <asp:UpdatePanel ID="UpdatePanel3" runat="server" >
                                 <ContentTemplate>
                                   
                      <table style="width:80%;" class="table table-hover">
                         <tr id="pega"> 
                               
                                <th> Vagao</th>
                                <th> media</th>
                                <th> mediana</th>
                                <th> status</th>
                           </tr>
                        
                           <tr id="tabela-hov">
                                
                              <% int contavagao = 0;
                                 if (dropvagao.SelectedValue == "1")
                                  { contavagao++; %>
                                 <td><asp:Label ID="label10" runat="server"></asp:Label> </td> 
                               <td> <asp:Label ID="label0" runat="server" ></asp:Label></td>
                               <td> <asp:Label ID="label5" runat="server" ></asp:Label></td>
                               <td id="diretorio1"> <asp:Label ID="label6" runat="server" style="font-weight:bold;" ></asp:Label></td>   
                           </tr>
                               <%}                                                                                                                                              
                              while (contavagao < 8)
                               { %>
                           <tr id="tabela-hov">
                                <% eita.Text = nome1(contavagao);%>
                               
                               
                               <td> <asp:label ID="eita" runat="server"></asp:label></td>
                               <td> <asp:Label ID="label8" runat="server" text="0.0"></asp:Label></td>
                               <td> <asp:Label ID="label9" runat="server" Text ="0.0"></asp:Label></td>
                               <td> <asp:Label ID="label18" runat="server"  Text ="sem operação"></asp:Label></td>
                           </tr>
                           <% contavagao++;
                              } %>
                          
                           <!-- tabela das temperaturas -->
                           
                              </table>  
                            </ContentTemplate>
                        </asp:UpdatePanel>     
                   </div>
                </div>
            </div>
        </div>
        <!-- modal da tela de cadastro -->

        <div id="myModal3">
            <div class="modal-content" id="modal-cadastro-usuario">
                <span class="close3">&times;</span><!-- "botão" de fechar a modal-->
                <div id="modalCadastro">
                    <h1 align="center">Cadastro de usuários</h1>
                    <div id="corpo-cadastro">
                        <%-- Botoões, campos e dropDownList --%>
                        <asp:TextBox placeholder="Digite o nome completo" ID="txtNome" runat="server" /> 
                    
                        <asp:TextBox runat="server" ID="txtLogin" placeholder="Digite o login"/>

                        <asp:TextBox placeholder="Digite a senha" runat="server" TextMode="Password" ID="txtSenha" />
               
                        <asp:TextBox placeholder="Confirme a senha" runat="server" TextMode="Password" ID="txtConfirmarSenha" />
                 
                        <asp:DropDownList ID="dropDownList" runat="server" AppendDataBoundItems="true"/>
                        <!-- Botão para cadastrar -->
                        <asp:Button Text="Confirmar" runat="server" CssClass="btn btn-default" ID="btnConfirmar" OnClick="btnConfirmar_Click" UseSubmitBehavior="false" />
                        <!--Mensagem de erro -->
                        <asp:Label Text="" runat="server" ID="lblErro"/>
                    </div>
                </div>           
            </div>
		</div>
        <!-- modal de cadastro de trens e vagões -->
        <div id="myModal4">
	        <div class="modal-content" id="modal-cadastro-trens">
                <span class="close4 ">&times;</span>
               <center><h1>Cadastro de Trens e Vagões</h1> </center>
                  <div id="divMae" >
               <div id="divao">
                   
                   <asp:TextBox placeholder="Nome do trem aqui" ID="Trem" runat="server"> </asp:TextBox>
                    <asp:TextBox placeholder="Amarela" ID="linha" runat="server" TextMode="SingleLine" ViewStateMode="Inherit" ReadOnly="True"></asp:TextBox>
                   <asp:Button Text="Registrar trem" ID="registrotrem" CssClass="btn btn-default btn1"  runat="server" OnClick="registrotrem_Click" />
                  <br />
                   <hr/>
                   </div>
           
            

               <div  id="metro">
                 
                   <asp:TextBox placeholder="nome dos vagoes" ID="nomevagao" runat="server" MaxLength="5" ></asp:TextBox>
                   <asp:TextBox placeholder="quantidade de vagoes" ID="quantidade" runat="server"></asp:TextBox>
                  
                      
                   <asp:DropDownList placeholder="trens"  ID="trens" runat="server">
                       
                      <asp:ListItem text="trens" value="0"></asp:ListItem>
                   </asp:DropDownList>  
                     
                   <!-----aqui é o dropdown, ele ira gerar automaticamente apartir dos dados registrados no banco de dados,
                       ele nao ira aparecer aqui --->

                    <asp:Button Text="registrar vagoes" ID="Button1" CssClass="btn btn-default btn1" runat="server" OnClick="registrovagao_Click" />
                    <asp:Label ID="lebel" runat="server"></asp:Label>
                       
               </div>
        </div>
                
            </div>
        </div>
      
        <!-----------------Cabeçalho com menu dropdown e a logo----------------------->
         <header>
            <nav class="navbar navbar-default" style="margin-bottom:0; background-color:white">
                <div class="container-fluid">
                    <!-- Logo e icone de menu que aparecem para resolução mobile-->
                    <div class="navbar-header">
                        <img class="navbar-brand" id="logoIcon" src="img/logo-2.png"/>
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#menu" aria-expanded="false">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        </button>
                    </div>
                    
                    <!-- Menu navbar -->
                    <div class="collapse navbar-collapse" id="menu">
                        <ul class="nav navbar-nav navbar-right">
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">  <asp:Label ID="lab1" runat="server" Text=""> </asp:Label> <span class="caret"></span></a>
                                <ul class="dropdown-menu">
                                    <button type="button" class="btn btn-default" id="btnCadUsu" ><i class="fas fa-cog"></i>  Cadastrar usuários</button>
                                    <button type="button" class="btn btn-default" id="btnCadTrens" ><i class="fas fa-cog"></i>  Cadastrar trens e vagões</button>
                                    <li role="separator" class="divider"></li>
                                   <div class="botao-sair">
                                       <li>
                                           <asp:Button runat="server" id="btnSair" Text="Sair" BackColor="Transparent" BorderColor="Transparent" 
                                               OnClick="btnSair_Click"  />
                                       </li>
                                   </div>   
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </header>

        <!--------------------Imagem que fica abaixo do cabeçalho---------------------->
        <section class="backImg"></section>
        

        <!--------------------Corpo do site, onde fica os únicos dois botões principais------------------------------->
        <main id="main">
            <div>
		        <button type="button" class="btn btn-default" id="btnGrafico"><i class="fas fa-chart-area"></i>   Temperatura em tempo real</button>
                <button type="button" class="btn btn-default" id="btnTabelaVagoes" ><i class="fas fa-table"></i>   Trens, vagões e arduinos</button>
            </div>
        </main>

        <!--------------------Rodapé------------------------------>
        <footer>
            <p>Site feito por: Alice Coelho | Henrique Guimarães | Jean Sales | Lucas Nascimento | Mateus Soares</p>
            <p>Contato: 5Q@gmail.com | (11)11111-1111 | (11)1111-1111</p>
            <a href="https://5q.freshdesk.com"> suporte</a>
        </footer>

        <!------------------- Scripts------------------------------------->
        <script type="text/javascript" src="js/jquery-3.3.1.min.js"></script>
	    <script type="text/javascript" src="js/bootstrap.min.js"></script>
        <script type="text/javascript" src="js/modal.js"></script>
        
        <script>  
             
          
            <%if (hiddenmodal.Text =="o"){%>
                modal4.style.display = "block"; 
         <% } %>
             <%if (hiddenmodal.Text =="z"){%>
                modal3.style.display = "block"; 
         <% } %>
              <%if (hiddenmodal.Text == "zta"){%>
                modal2.style.display = "block"; 
         <% } %>

           
        </script>
             
           
         
    </form>
</body>
</html>
