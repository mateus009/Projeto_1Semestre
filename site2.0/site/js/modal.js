//Modal do gráfico-->
    // pega o modal
var modal1 = document.getElementById('myModal1');
    // pega o botão que abre o modal
    var btn1 = document.getElementById('btnGrafico');

    // botão de feichar o modalx
    var span1 = document.getElementsByClassName('close')[0];

    // quando clica no botão
    btn1.onclick = function () {
        modal1.style.display = "block";
    };

    // quando clica no X
    span1.onclick = function () {
        modal1.style.display = "none";
    };

    // quando clicar fora do modal feichar
    modal1.onclick = function (event) {
        if (event.target == modal1) {
            modal1.style.display = "none";
        }
    };

//Modal da tela com as tabelas de vagões e arduinos
    var modal2 = document.getElementById('myModal2');
    var btn2 = document.getElementById('btnTabelaVagoes');
    var span2 = document.getElementsByClassName('close2')[0];

    btn2.onclick = function () {
        modal2.style.display = "block";
    }
    span2.onclick = function () {
        modal2.style.display = "none";
    }
    modal2.onclick = function (event) {
        if (event.target == modal2) {
            modal2.style.display = "none";
        }
    }

//Modal da tela de cadastro-->
    var modal3 = document.getElementById('myModal3');
    var btn3 = document.getElementById('btnCadUsu');
    var span3 = document.getElementsByClassName('close3')[0];

    btn3.onclick = function () {
        modal3.style.display = "block";
    }
    span3.onclick = function () {
        modal3.style.display = "none";
    }
    modal3.onclick = function (event) {
        if (event.target == modal3) {
            modal3.style.display = "none";
        }
    }

//Modal da tela com as tabelas de vagões e arduinos
    var modal4 = document.getElementById('myModal4');
    var btn4 = document.getElementById('btnCadTrens');
    var span4 = document.getElementsByClassName('close4')[0];

    btn4.onclick = function () {
        modal4.style.display = "block";
    }
    span4.onclick = function () {
        modal4.style.display = "none";
    }
    modal4.onclick = function (event) {
        if (event.target == modal4) {
            modal4.style.display = "none";
        }
    }
var modal1 = document.getElementById('myModal1');
// pega o botão que abre o modal
var btn5 = document.getElementById('modalgraficovagao');

// botão de feichar o modalx
var span5 = document.getElementsByClassName('close')[0];

// quando clica no botão
btn5.onclick = function () {
    modal1.style.display = "block";
};
// quando clica no X
span5.onclick = function () {
    modal1.style.display = "none";
};

// quando clicar fora do modal feichar
 modal5.onclick = function (event) {
     if (event.target == modal1) {
         modal1.style.display = "none";
     }
 };

