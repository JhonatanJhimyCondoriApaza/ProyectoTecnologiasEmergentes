$(function () {
    var customer = {
        nombre:"Scott",
        color:"Scott",
        genero:"Scott",
        like:"Scott",
        location:"HP"};
    $.ajax({
        type: "POST",
        data :JSON.stringify(customer),
        url: "https://proyectote-production.up.railway.app/api/persona/create",
        contentType: "application/json"
    }).done(function(){console.log("createDAte")});
});