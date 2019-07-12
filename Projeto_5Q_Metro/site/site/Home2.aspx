
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home2.aspx.cs" Inherits="site.Home2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/home2.css" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <img id="logomenu" src="img/logo-2.png"/>
            <div class="dropdown">
                <asp:Button Text="dropdown" runat="server" ID="dropbtn"/>
              <div class="dropdown-content">
                <a href="#">Link 1</a>
                <a href="#">Link 2</a>
                <a href="#">Link 3</a>
              </div>
            </div>
        </header>
        <section class="header-site">
        </section>
        <div id="corpo">
        
        </div>
        <footer>

        </footer>
    </form>
</body>
</html>
