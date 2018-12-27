window.onload = inicializaEventos;

function inicializaEventos() {

    cargar();
    var imported = document.createElement('script');
    imported.src = '../Scripts/clsPersona.js';
    document.head.appendChild(imported);

}

function cargar() {

    //Eliminamos la tabla para poder volver a cargarla
    var divTabla = document.getElementById("divTabla");
    divTabla.removeChild(divTabla.childNodes[0]);

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
        textoEditar.setAttribute("name", "botonEditar");

        botonEditar.appendChild(formButtons1);
        formButtons1.appendChild(textoEditar);
        textoEditar.appendChild(i1);

        botonEditar.setAttribute("id", arrayPersonas[i].idPersona);
        botonEditar.addEventListener("click", getPersona, false);
        

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
        botonBorrar.addEventListener("click", preguntaBorrar, false);


        row.appendChild(botonBorrar);
        row.appendChild(botonEditar);

        tblBody.appendChild(row);
    }

    tabla.appendChild(tblhead);
    tabla.appendChild(tblBody);
    divTabla.appendChild(tabla);

}

function borrar(idPersona) {

    var llamada = new XMLHttpRequest();
    llamada.open("DELETE", "https://10-apirestpersonas-sam.azurewebsites.net/api/personas/" + idPersona);

    llamada.onreadystatechange = function () {
        if (llamada.readyState < 4) { }
        else {
            if (llamada.readyState == 4 && miLlamada.status == 204) {
                inicializaEventos();
            }
        }
    };

    llamada.send();

}

function preguntaBorrar() {
    var idPersona = this.id;
    var conf = confirm("¿Borrar la persona seleccionada?");
    if (conf == true) {
        borrar(idPersona);
    } 
}

function getPersona() {
    var idPersona = this.id;
    var persona = new clsPersona();

    var llamada = new XMLHttpRequest();
    llamada.open("GET", "https://10-apirestpersonas-sam.azurewebsites.net/api/personas/" + idPersona);

    llamada.onreadystatechange = function () {

        var arrayPersonas;

        if (llamada.readyState < 4) { }
        else {
            if (llamada.readyState == 4 && llamada.status == 200) {
                arrayPersonas = JSON.parse(llamada.responseText);

                persona.nombre = arrayPersonas.nombre;
                persona.apellidos = arrayPersonas.apellidos;
                persona.fechNacimiento = arrayPersonas.fechNacimiento;
                persona.direccion = arrayPersonas.direccion;
                persona.telefono = arrayPersonas.telefono;
                persona.idDepartamento = arrayPersonas.idDepartamento;

                preparaEditar(persona);
            }
        }
    };

    llamada.send();
}

function preparaEditar(persona) {
    document.getElementById('nombre').value = persona.nombre;
    document.getElementById('apellidos').value = persona.apellidos;
    document.getElementById('fechNac').value = persona.fechNacimiento;
    document.getElementById('telefono').value = persona.telefono;
    document.getElementById('direccion').value = persona.direccion;
    document.getElementById('idDepartamento').value = persona.idDepartamento;

    var div = document.getElementById('divEditar');
    var span = document.getElementsByTagName('span');

    div.style.display = "block";

    window.onclick = function (event) {
        if (event.target == div) {
            div.style.display = "none";
        }
    }

    editar(persona);

}

function editar(persona) {
    var llamada = new XMLHttpRequest();
    llamada.open("PUT", "https://10-apirestpersonas-sam.azurewebsites.net/api/personas/" + persona.idPersona);

    llamada.onreadystatechange = function () {

        if (llamada.readyState < 4) { }
        else {
            if (llamada.readyState == 4 && llamada.status == 200) {
                inicializaEventos();
            }
        }
    };

    llamada.send();
}

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