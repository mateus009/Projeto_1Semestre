<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grafico.aspx.cs" Inherits="site.grafico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="grafico"></div>
             <script type="text/javascript">
// Load google charts
google.charts.load('current', {'packages':['corechart']});
google.charts.setOnLoadCallback(drawChart);

// Draw the chart and set the chart values
function drawChart() {
  var data = google.visualization.arrayToDataTable([
  ['Task', 'Hours per Day'],
  ['Work', 8],
  ['Friends', 2],
  ['Eat', 2],
  ['TV', 3],
  ['Gym', 2],
  ['Sleep', 7]
]);

  // Optional; add a title and set the width and height of the chart
  var options = {'title':'My Average Day', 'width':400, 'height':300};

  // Display the chart inside the <div> element with id="piechart"
  var chart = new google.visualization.PieChart(document.getElementById('grafico'));
  chart.draw(data, options);
}
</script> 
        </div>
    </form>
</body>
</html>
