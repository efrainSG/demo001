var initFoto = function (element, index) {
    var $divContenedor, $fila, $titulo, $descripcion, $foto, $valoracion;
    var $columna1;
    $divContenedor = $('<div id="div' + index + '">').addClass("well well-sm");
    $fila = $('<div class="row">');
    $columna1 = $('<div class="col-md-12">');

    $titulo = $('<h4 id="titulo' + index + '">' + 'foto #' + index + '</h3>');
    $descripcion = $('<h5 id="descripcion' + index + '">Descripción breve</h5>');
    $foto = $('<div class="img-thumbnail"><span class="glyphicon glyphicon-picture"></span></div>');
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
    $columna1.append($descripcion).append($valoracion);
    element.append($divContenedor);
};
//<a href="#divProducto1">Info</a>