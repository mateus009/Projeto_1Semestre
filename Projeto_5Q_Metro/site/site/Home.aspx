<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="site.Home" %>

<DOCTYPE! HTML>
<html>
    <head runat="server">
        <title>Home</title>
        <meta charset="utf-8">
        <meta http-equiv="X-IU-Compatible" content="IE-edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="css/home.css">
        <link rel="icon" href="img/logo-2.png">
        <!-- chamando javascript e adicionando grafico no google charts -->
        <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
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
    <form runat="server">
        <!-- modal -->
        <div id="myModal" class="modal">
	        <div class="modal-content">
            <span class="close">&times;</span>
            <div id="grafico" style="height:80%; width:98.6%">
            <br />   
            </div>
            <div style="margin-left:13.5%"></div>
          </div>
        </div>

		<div id="modalteste" class="modal2">
            <div class="modal-cadastro">
                <span class="feichar">&times;</span>
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
                    <asp:Button Text="Confirmar" runat="server" ID="btnConfirmar" OnClick="btnConfirmar_Click" UseSubmitBehavior="false" />
                    <!--Mensagem de erro -->
                    <asp:Label Text="" runat="server" ID="lblErro"/>
                </div>
            </div>            
            </div>
		</div>    
        <!--header-->
        <header>
            <nav class="nav">
                <div id="logo">
                    <img class="logomenu" src="img/logo-2.png"/>
                </div>
		        <!--menu-->
			    <div class="dropdown">
                    <%--<asp:Button Text="usuario" runat="server" class="dropbtn"/>
				    <div class="dropdown-content">
					    <a href="#">cadastro</a>
					    <a href="#">sair</a>
				    </div>--%>
			    </div>
            </nav>
        </header>
    
        <!--cidade-->
        <section class="header-site">
        </section>
        <!--div p enfeitar-->
<%--        <div class="divex"> 
        </div>--%>
	
	    <!--div e botões -->
            <div class="corpo">
		    <img src="img/icone12.png" class="icone2" style="margin-left:28%">
		    <button type="button" class="icone" id="myBtn">Grafico</button>
		    <img src="img/icone12.png" class="icone2" style="margin-left:12%">
            <button type="button" class="icone" id="botao" >Cadastrar usuários</button>
        </div>
            
	    <!--footer-->
		    <footer>
		    <div class="divfoot">
			    <h3 class="footer">feito por:</h3>
			    <p class="footer">Alice Coelho</p>
			    <p class="footer">Jean Sales</p>
			    <p class="footer">Lucas Nascimento</p>
			    <p class="footer">Mateus Soares</p>
		    </div>
		    <div class="divfoot">
			    <h3 class="footer2">contato</h3><br>
			    <p class="footer2">5q@gmail.com.br </p>
			    <p class="footer2">(11)1111-1111</p>
			    <p class="footer2">(11)1111-1111</p>
		    </div>
		    </footer>
                <script>
                    // pega o modal
                    var modal = document.getElementById('myModal');

                    // pega o botão que abre o modal
                    var btn = document.getElementById('myBtn');

                    // botão de feichar o modalx
                    var span = document.getElementsByClassName('close')[0];

                    // quando clica no botão
                    btn.onclick = function () {
                        modal.style.display = "block";
                    };

                    // quando clica no X
                    span.onclick = function () {
                        modal.style.display = "none";
                    };

                    // quando clicar fora do modal feichar
                    modal.onclick = function (event) {
                        if (event.target == modal) {
                            modal.style.display = "none";
                        }
                    };
        </script>
        <script>
                    // pega o modal
                    var modal2 = document.getElementById('modalteste');

                    // pega o botão que abre o modal
                    var btn1 = document.getElementById('botao');
                    // botão de feichar o modal
                    var span2 = document.getElementsByClassName('feichar')[0];

                    // quando clica no botão
                    btn1.onclick = function () {
                        modal2.style.display = "block";
                    }
                    // quando clica no X
                    span2.onclick = function () {
                        modal2.style.display = "none";
                    }

                    // quando clicar fora do modal feichar
                    modal2.onclick = function (event) {
                        if (event.target == modal2) {
                            modal2.style.display = "none";
                        }
                    }
        </script>
        </form>
    </body>
</html>
