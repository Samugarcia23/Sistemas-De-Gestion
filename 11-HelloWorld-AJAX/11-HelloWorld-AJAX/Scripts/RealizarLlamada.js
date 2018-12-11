window.onload = inicializaEventos;

function inicializaEventos() {

    document.getElementById("btnLlamarApi").addEventListener("click", btnLlamar_OnClick, false);

}


function btnLlamar_OnClick() {
    
    //Paso 1
    var llamada = new XMLHttpRequest();
    //Paso 2
    llamada.open('GET', "https://10-apirestpersonas-sam.azurewebsites.net/api/personas");
    //Paso 4
    llamada.onreadystatechange = function () {
        alert(llamada.readyState);
        if (llamada.readyState < 4) {
            document.getElementById("textoMostrar").innerHTML = "Cargando. . .";
        } else if (llamada.readyState == 4 && llamada.status == 200) {
            //document.getElementById("textoMostrar").innerHTML = llamada.responseText;
            var oPersona = new Persona();
            var arrayPersonas = JSON.parse(llamada.responseText);
            oPersona = arrayPersonas[0];
            document.getElementById("textoMostrar").innerHTML = oPersona.nombre;
        }    
    };
    //Paso 5
    llamada.send();

}

class Persona {
    constructor(nombre, apellidos, fechnac) {
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.fechNacimiento = fechnac;
    }
}