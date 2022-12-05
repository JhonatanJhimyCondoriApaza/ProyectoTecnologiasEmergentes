$(document).ready(function(){
    var color_RGB = randomRGB();
    update(color_RGB);
    $.get("http://ipinfo.io",function(response){
        console.log(response.ip)
    },"jsonp");
});

let state = 0;
let letters = '';
let background = new Array();
let weizhi = '';

let riqi = new Date();
riqi = new Date(riqi.getTime() - 3000000);
let last_form_from_riqi = riqi.getFullYear().toString()+"-"+((riqi.getMonth()+1).toString().length==2?(riqi.getMonth()+1).toString():"0"+(riqi.getMonth()+1).toString())+"-"+(riqi.getDate().toString().length==2?riqi.getDate().toString():"0"+riqi.getDate().toString())+" "+(riqi.getHours().toString().length==2?riqi.getHours().toString():"0"+riqi.getHours().toString())+":"+((parseInt(riqi.getMinutes()/5)*5).toString().length==2?(parseInt(riqi.getMinutes()/5)*5).toString():"0"+(parseInt(riqi.getMinutes()/5)*5).toString())+":00";


const dislike = document.getElementById('dk');
const like = document.getElementById('lk');


dislike.addEventListener('click', function(){
    state = 1;
    send_dataToWCF();
});
like.addEventListener('click', function(){
    state = 0;
    send_dataToWCF();
});


function send_dataToWCF(){
    alert(background+'\n'+letters+'\n'+state+'\n'+weizhi+'\n'+riqi);
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