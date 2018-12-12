window.onload = inicializaEventos;

function inicializaEventos() {

    cargar();

}

function cargar() {

    //Eliminamos la tabla para poder volver a cargarla
    var divTabla = document.getElementById("divTabla");
    divTabla.removeChild(divTabla.childNodes[0]);

    var llamada = new XMLHttpRequest();
    llamada.open('GET', "https://10-apirestpersonas-sam.azurewebsites.net/api/personas");
    //llamada.open('GET', "https://10-apirestpersonas-sinnombredep.azurewebsites.net/api/personas");
    llamada.onreadystatechange = function () {
        if (llamada.readyState == 4 && llamada.status == 200) {
            var arrayPersonas = JSON.parse(llamada.responseText);
            rellenarTabla(arrayPersonas);
        }
    };
    llamada.send();
}

function rellenarTabla(arrayPersonas) {

    var divTabla = document.getElementById("divTabla");
    var cols = Object.keys(arrayPersonas[0]);
    var keys = Object.keys(arrayPersonas[0]);

    var editSave = "fa fa-pencil-square-o";
    divTabla.setAttribute("class", "large-12 columns");

    var tabla = document.createElement("table");
    var tblhead = document.createElement("thead");
    
    tabla.setAttribute("id", "test-table");
    var tblBody = document.createElement("tbody");

    //Crear los nombres de las propiedades
    for (var k = 0; k < keys.length; k++) {
        var th = document.createElement("th");
        var key = keys[k];
        var textoProp = document.createTextNode(key, arrayPersonas[key]);
        th.setAttribute("class", "propSize");
        var texto = textoProp.textContent;
        texto = cambiarNombres(texto);
        textoProp.textContent = texto;
        th.appendChild(textoProp);
        tblhead.appendChild(th);
    }

    //Creacion del resto de la tabla
    for (var i = 0; i < arrayPersonas.length; i++) {

        var row = document.createElement("tr");
        

        for (var j = 0; j < cols.length; j++) {
 
            var column = document.createElement("td");
            var textoCelda = document.createTextNode(arrayPersonas[i][cols[j]]);
            /*var input = document.createElement("input");
            input.setAttribute("type", "text");
            input.setAttribute("enable", false);
            input.setAttribute("value", textoCelda);*/
            //column.appendChild(input);
            column.appendChild(textoCelda);
            row.appendChild(column);

        }

        //Editar
        var botonEditar = document.createElement("td");
        var formButtons1 = document.createElement("form");
        var textoEditar = document.createElement("button");
        var i1 = document.createElement("i");
        var i2 = document.createElement("i");

        botonEditar.setAttribute("class", "center");
        textoEditar.setAttribute("class", "button_left");
        i1.setAttribute("class", editSave);
        formButtons1.setAttribute("class", "buttons");

        botonEditar.appendChild(formButtons1);
        formButtons1.appendChild(textoEditar);
        textoEditar.appendChild(i1);
        

        //Borrar
        var botonBorrar = document.createElement("td");
        var formButtons2 = document.createElement("form");
        var textoBorrar = document.createElement("button");

        textoBorrar.setAttribute("class", "button_right");
        textoBorrar.setAttribute("name", "botonBorrar");


        i2.setAttribute("class", "fa fa-trash-o");
        formButtons2.setAttribute("class", "buttons");
        botonBorrar.setAttribute("class", "center");

        botonBorrar.appendChild(formButtons2);
        formButtons2.appendChild(textoBorrar);
        textoBorrar.appendChild(i2);

        botonBorrar.setAttribute("id", arrayPersonas[i].idPersona);
        //botonBorrar.addEventListener("click", preguntarBorrar, false);


        row.appendChild(botonBorrar);
        row.appendChild(botonEditar);

        tblBody.appendChild(row);
    }

    tabla.appendChild(tblhead);
    tabla.appendChild(tblBody);
    divTabla.appendChild(tabla);

}

/*function preguntaBorrar() {

    var modal = document.getElementById('myModal');
    var boton = document.getElementsByName("botonBorrar");
    modal.style.display = "block";

    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }

}*/

function cambiarNombres(textoProp) {

    if (textoProp === "nombreDepartamento") {
        textoProp = "Nombre Departamento";
    } else {
        if (textoProp === "idPersona") {
            textoProp = "ID Persona";
        } else {
            if (textoProp === "nombre") {
                textoProp = "Nombre";
            } else {
                if (textoProp === "apellidos") {
                    textoProp = "Apellidos";
                } else {
                    if (textoProp === "fechNacimiento") {
                        textoProp = "Fecha Nacimiento";
                    } else {
                        if (textoProp === "direccion") {
                            textoProp = "Direccion";
                        } else {
                            if (textoProp === "telefono") {
                                textoProp = "Telefono";
                            } else {
                                if (textoProp === "idDepartamento") {
                                    textoProp = "ID Departamento";
                                } 
                            }
                        }
                    }
                }
            }
        }
    }

    return textoProp;
}