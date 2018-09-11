var initProducto = function (element, tipo, index, opciones) {
    var $divContenedor, $fila, $titulo, $precio, $descripcion, $foto, $valoracion, $btnInfo;
    var $columna1, $columna2;
    var data = opciones;
    $divContenedor = $('<div id="div' + tipo + index + '">').addClass("well well-sm col-md-4 Servicio");
    $fila = $('<div class="row">');
    $columna1 = $('<div class="col-md-4">');
    $columna2 = $('<div class="col-md-8">');

    $titulo = $('<h3 id="titulo' + data.Id + '" class="tituloOferta">' + data.Nombre + '</h3>');
    $precio = $('<h3 id="precio' + data.Id + '">' + data.Precio + '</h3>');
    $descripcion = $('<p id="descripcion' + data.Id + '">' + data.DescripcionBreve + '</p>');
    $foto = $('<div class="img-thumbnail"><img src="' + data.Ruta + data.Foto + '" style="width:100%;"></div>');
    $valoracion = $('<p>' + data.Aceptacion + '</p >');
    $btnInfo = $('<a href="#" id="lnkInfo' + data.Id + '">Info</a>').addClass("btn btn-sm btn-info");
    $btnInfo
        .off()
        .on("click", function () {
            verProducto(data, $("#modalHdr"), $("#divModalBody"), $("#myModal"));   
        });

    $divContenedor.append($titulo).append($fila);
    $fila.append($columna1).append($columna2);
    $columna1.append($descripcion).append($precio)
        .append($btnInfo);//.append($valoracion);
    $columna2.append($foto);
    element.append($divContenedor);
};

var verProducto = function (obj, hdr, body, modal) {
    hdr.empty().html(obj.Nombre);
    var $divizquierdo = $('<div>').addClass("col-sm-6 col-sm-6");
    var $img = $('<img>').addClass("img-responsive")
        .attr("src", obj.Ruta + obj.Foto);
    var $divderecho = $('<div>').addClass("col-sm-6 col-md-6");
    var $filaderecha1 = $('<div>').addClass("row");
    var $divprecio = $('<div>').addClass("col-sm-12 col-md-12 precio").html("$ " + obj.Precio);
    var $filaderecha2 = $('<div>').addClass("row");
    var $divDescripcion = $('<div>').addClass("col-sm-12 col-md-12").html(obj.Descripcion);

    $divizquierdo.append($img);
    $divderecho.append($filaderecha1.append($divprecio)).append($filaderecha2.append($divDescripcion));
    body.empty().append($('<div class="row">').append($divizquierdo).append($divderecho));

    modal.modal();
}