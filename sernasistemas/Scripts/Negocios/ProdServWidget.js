var initProducto = function (element, tipo, index, opciones) {
    var $divContenedor, $fila, $titulo, $precio, $descripcion, $foto, $valoracion, $btnInfo;
    var $columna1, $columna2;
    var data = opciones;
    $divContenedor = $('<div id="div' + tipo + index + '">').addClass("well well-sm col-md-4 Servicio");
    $fila = $('<div class="row">');
    $columna1 = $('<div class="col-md-12">');
    //$columna2 = $('<div class="col-md-8">');

    $titulo = $('<h3 id="titulo' + data.Id + '" class="tituloOferta text-right bg-success" style="padding:0.4em;">' + data.Nombre + '</h3>');
    $precio = $('<h4 id="precio' + data.Id + '" class="col-md-8">$' + data.Precio + '.00</h4>');
    $descripcion = $('<p id="descripcion' + data.Id + '">' + data.DescripcionBreve + '</p>');
    //$foto = $('<div class="img-thumbnail"><img src="' + data.Ruta + data.Foto + '" style="width:100%;"></div>');
    $valoracion = $('<p>' + data.Aceptacion + '</p >');
    $btnInfo = $('<a href="#" id="lnkInfo' + data.Id + '">Info</a>').addClass("btn btn-sm btn-info col-md-2 offset-md-2");
    $btnInfo
        .off()
        .on("click", function () {
            verProducto(data, $("#modalHdr"), $("#divModalBody"), $("#myModal"));   
        });

    $divContenedor.append($titulo).append($fila);
    $fila.append($columna1).append($columna2);
    $columna1.append($descripcion).append($precio)
        .append($btnInfo);//.append($valoracion);
    //$columna2.append($foto);
    element.append($divContenedor.attr("style", "min-height:230px; max-height:230px;"));
};

var verProducto = function (obj, hdr, body, modal) {
    console.log(obj);
    hdr.empty().html('<span style="padding-left:0.2em;">' + obj.Nombre + '</span>').removeClass().addClass("modal-title text-left text-primary bg-primary");
    //var $divizquierdo = $('<div>').addClass("col-sm-6 col-sm-6");
    //var $img = $('<img>').addClass("img-responsive").attr("src", obj.Ruta + obj.Foto);
    var $divderecho = $('<div>').addClass("col-md-12");
    var $filaderecha1 = $('<div>').addClass("row");
    var $divprecio = $('<div>').addClass("col-md-3").html('<h2 class="text-warning bg-warning text-center" style="padding:0.5em;">$' + obj.Precio+'.00</h2>');
    var $filaderecha2 = $('<div>').addClass("row");
    var $divDescripcion = $('<div>').addClass("col-md-8").html(obj.Descripcion);

    //$divizquierdo.append($img);
    $divderecho.append($filaderecha1.append($divprecio)).append($filaderecha2.append('<div class="col-md-4">').append($divDescripcion));
    body.empty().append($('<div class="row">')
        //.append($divizquierdo)
        .append($divderecho));

    modal.modal();
}