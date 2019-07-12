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

            setTimeout(function ()
            {
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