window.onload = inicializaEventos;

function inicializaEventos() {

    cargar();

}

function cargar() {

    var llamada = new XMLHttpRequest();
    llamada.open('GET', "https://10-apirestpersonas-sam.azurewebsites.net/api/personas");
    llamada.onreadystatechange = function () {
        if (llamada.readyState == 4 && llamada.status == 200) {
            var arrayPersonas = JSON.parse(llamada.responseText);
            rellenarTabla(arrayPersonas);
        }
    };
    llamada.send();
}

function rellenarTabla(arrayPersonas) {

    var body = document.getElementsByTagName("body")[0];
    var tabla = document.createElement("table");
    tabla.setAttribute("border", "1");

    var tblBody = document.createElement("tbody");

    for (var i = 0; i < arrayPersonas.length; i++) {

        var row = document.createElement("tr");

        for (var prop in arrayPersonas[0]) {

            var column = document.createElement("td");
            var textoCelda = document.createTextNode(arrayPersonas[i][prop]);
            column.appendChild(textoCelda);
            row.appendChild(column);
        }

        tblBody.appendChild(row);
    }

    tabla.appendChild(tblBody);
    body.appendChild(tabla); 
}