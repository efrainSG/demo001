var initProducto = function (element, tipo, index) {
    var $divContenedor, $fila, $titulo, $precio, $descripcion, $foto, $valoracion;
    var $columna1, $columna2;
    $divContenedor = $('<div id="div' + tipo + index + '">').addClass("well well-sm");
    $fila = $('<div class="row">');
    $columna1 = $('<div class="col-md-4">');
    $columna2 = $('<div class="col-md-8">');

    $titulo = $('<h3 id="titulo' + index + '">'+ tipo + ' #' + index + '</h3>');
    $precio = $('<h3 id="precio' + index + '">Precio</h3>');
    $descripcion = $('<p id="descripcion' + index + '">Descripción breve</p>');
    $foto = $('<div class="img-thumbnail"><span class="glyphicon glyphicon-picture"></span></div>');
    $valoracion = $('<p>Aceptación en estrellas</p >');

    $divContenedor.append($titulo).append($fila);
    $fila.append($columna1).append($columna2);
    $columna1.append($descripcion).append($precio).append($valoracion);
    $columna2.append($foto);
    element.append($divContenedor);
};
//<a href="#divProducto1">Info</a>