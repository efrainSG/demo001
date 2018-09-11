var initMapa = function (opciones, element) {
    var $divContenedor, $fila, $titulo, $columna;
    
    $divContenedor = $('<div id="divContenedorMapa" style="height:300px">').addClass("well well-sm col-md-12");
    //$fila = $('<div class="row">');
    //$columna = $('<div class="col-md-12" id="divMapa">');
    //$titulo = $('<h3 id="tituloMapa" class="tituloOferta">' + opciones.Nombre + '</h3>');

    //$divContenedor; //.append($titulo).append($fila);
    //$fila.append($columna);
    element.append($divContenedor);
};

var elMapa = function(mapa) {
    var mapProp = {
        center: new google.maps.LatLng(51.508742, -0.120850),
        zoom: 5,
    };
    var map = new google.maps.Map(document.getElementById("divContenedorMapa"), mapProp);
}

var addScript = function (element, _src) {
    var nuevoScript = document.createElement("script");
    nuevoScript.src = _src;
    element.append(nuevoScript);
}