$(document).ready(function(){
    var color_RGB = randomRGB();
    $.get("http://ipinfo.io",function(response){weizhi=response.city+"/"+response.country+"/"+response.region},"jsonp").done(function(){console.clear();console.log("\r");});
    update(color_RGB);
});

let state = 0;
let letters = '';
let gender = 0;
let background = new Array();
let weizhi = '';
let riqi = new Date();
let last_form_from_riqi;

const dislike = document.getElementById('dk');
const like = document.getElementById('lk');

dislike.addEventListener('click', function(){
    state = 1;
    getCustomerDate();
    send_dataToWCF();
});
like.addEventListener('click', function(){
    state = 0;
    getCustomerDate();
    send_dataToWCF();
});

/*
function conectionStringToServiceWCF(){
    $.ajax({
        url:'Service.svc/RegistrarCategoria',
        method:'post',
        dataType:'json',
        contentType:'application/json'
    });
}
*/

function send_dataToWCF(){
    var customer = {
        nombre:background,
        color:letters,
        genero:gender,
        like:state,
        location:weizhi};
    $.ajax({
        type: "POST",
        data :JSON.stringify(customer),
        url: "https://proyectote-production.up.railway.app/api/persona/create",
        contentType: "application/json"
    }).done(function(){console.log("createDAte")});

    console.log(background+'\n'+letters+'\n'+state+'\n'+weizhi+'\n'+last_form_from_riqi);
}

function getCustomerDate(){
    riqi = new Date();
    riqi = new Date(riqi.getTime());
    last_form_from_riqi = riqi.toLocaleString().replaceAll(',','');
}

function randomRGB() {

  var color_indexed = new Array();

  color_indexed[0] = Math.floor(Math.random() * 255);
  color_indexed[1] = Math.floor(Math.random() * 255);
  color_indexed[2] = Math.floor(Math.random() * 255);

  return color_indexed;
}

function update(color) {

    //Cuando hice el video, existia color.rgb
    //Ahora existe color.channels y dentro tiene varios componentes.
    //Aqui hacemos el objeto "rgb" para que sea similar al video
    var rgb = color;
    background = color; 
    var div = document.getElementById("sitio");
    div.style.backgroundColor = 'rgb('+rgb[0]+','+rgb[1]+','+rgb[2]+')'; //Nueva forma para poner el color de fondo

    //Tomar el fondo actual elegido por el usuario,
    //para usarlo de entrada para que la red nos de su
    //prediccion del mejor color de texto a utilizar
    var entrada = {
        rojo: rgb[0]/255,
        verde: rgb[1]/255,
        azul: rgb[2]/255,
    };

    //Obtener la prediccion de la red
    var resultado = network.run(entrada);
    //console.log(resultado);

    //Si resultado > .5, se considera color de texto blanco
    if (resultado.color > .5) {
        div.style.color = "white";
        letters = "white";
    }  else {
        div.style.color = "black";
        letters = "black";
    }
}

//Inicializar red neuronal
var network = new brain.NeuralNetwork();
//Entrenarla, darle ejemplos de cuando poner
//texto blanco, o texto negro segun el fondo
network.train([
    //Fondo negro (entrada en 0s) = texto blanco (salida = 1)
    {input: {rojo: 0, verde: 0, azul: 0}, output: {color: 1}},
    //Fondo blanco (entrada en 1s) = texto negro (salida = 0)
    {input: {rojo: 1, verde: 1, azul: 1}, output: {color: 0}},
    //Fondo verde, texto negro
    {input: {rojo: 0, verde: 1, azul: 0}, output: {color: 0}},
    //Fondo azul, texto blanco
    {input: {rojo: 0, verde: .43, azul: 1}, output: {color: 1}},
    //Fondo rojo, texto blanco
    {input: {rojo: 1, verde: 0, azul: 0}, output: {color: 1}},
]);