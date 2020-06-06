var initFoto = function (element, ndx, opciones) {
    var $divContenedor, $fila, $titulo, $descripcion, $foto, $valoracion;
    var $columna1;
    $divContenedor = $('<div id="div' + ndx + '">').addClass("well well-sm col-md-4");
    $fila = $('<div class="row">');
    $columna1 = $('<div class="col-md-12">');

    $titulo = $('<h4 id="titulo' + ndx + '">' + 'foto #' + opciones.Id + '</h3>');
    $descripcion = $('<h5 id="descripcion' + ndx + '">'+ opciones.Titulo + '</h5>');
    $foto = $('<div class="img-thumbnail"><img src="' + opciones.Ruta + opciones.Titulo+ '" width="100%"></div>');
    $valoracion = $('<p>Aceptación en estrellas</p >');
    $foto
        .off()
        .on("click", function () {
            jQuery.noConflict();
            $("#myModal").modal();
        });

    $divContenedor.append($titulo).append($fila);
    $fila.append($columna1);
    $columna1.append($foto);
    $columna1.append($descripcion);//.append($valoracion);
    element.append($divContenedor);
};
//<a href="#divProducto1">Info</a>