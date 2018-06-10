var initProducto = function (element, tipo, index, opciones) {
    var $divContenedor, $fila, $titulo, $precio, $descripcion, $foto, $valoracion, $btnInfo;
    var $columna1, $columna2;
    
    $divContenedor = $('<div id="div' + tipo + index + '">').addClass("well well-sm col-md-4");
    $fila = $('<div class="row">');
    $columna1 = $('<div class="col-md-4">');
    $columna2 = $('<div class="col-md-8">');

    $titulo = $('<h3 id="titulo' + opciones.Id + '">'+ opciones.Nombre + '</h3>');
    $precio = $('<h3 id="precio' + opciones.Id + '">' + opciones.Precio + '</h3>');
    $descripcion = $('<p id="descripcion' + opciones.Id + '">' + opciones.DescripcionBreve + '</p>');
    $foto = $('<div class="img-thumbnail"><img src="' + opciones.Ruta + opciones.Foto + '" style="width:150px;"></div>');
    $valoracion = $('<p>' + opciones.Aceptacion + '</p >');
    $btnInfo = $('<a href="#" id="lnkInfo' + opciones.Id + '">Info</a>').addClass("btn btn-sm btn-info");
    $btnInfo
        .off()
        .on("click", function () {
            jQuery.noConflict();
            $("#myModal").modal();
        });

    $divContenedor.append($titulo).append($fila);
    $fila.append($columna1).append($columna2);
    $columna1.append($descripcion).append($precio).append($valoracion).append($btnInfo);
    $columna2.append($foto);
    element.append($divContenedor);
};
//
