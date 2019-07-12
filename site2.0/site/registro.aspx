 &nbsp; <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="site.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/5qRe.css"/>
     <script type="text/javascript" src="js/jquery-3.3.1.min.js"></script>
	    <script type="text/javascript" src="js/bootstrap.min.js"></script>
        <script type="text/javascript" src="js/modal.js"></script>










    <link rel="icon" href="img/logo-2.png"/><!--icone da pagina-->
</head>
<body style="background-image:url(fundoregistro.jpg)">
    <form id="form1" runat="server">
        <div>
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
            <div id="grafico"></div>
        </div>
    </form>
</body>
</html>
