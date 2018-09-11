var initAdminProductos = function (element, datos) {
    var html = '<h1 class="well">Administrar Productos</h1>' +
        '<div class="well well-sm form">' +
        '  <div class="row">' +
        '    <div class="col-sm-1 col-md-1">Id</div> ' +
        '    <div class="col-sm-2 col-md-2">Producto</div> ' +
        '    <div class="col-sm-5 col-md-5">Resumen</div> ' +
        '    <div class="col-sm-2 col-md-2">Precio</div> ' +
        '    <div class="col-sm-2 col-md-2">Acciones</div> ' +
        '</div> ';
    element.append(html).append(prodServhelper(
        { "Id": "1", "Nombre": "Elemento", "Resumen": "Descripción breve", "Precio": "10.00" }
    ));
    eventosAdminProductos();
};

var prodServhelper = function (datos) {
    var $fila, $celId, $celNombre, $celResumen, $celPrecio, $celAcciones;
    var $btnEdit, $btnDel;

    $fila = $('<div class="row">');
    $celId = $('<div class="col-sm-1 col-md-1" id="celId_' + datos.Id + '">');
    $celNombre = $('<div class="col-sm-2 col-md-2" id="celNombre_' + datos.Id + '">');
    $celResumen = $('<div class="col-sm-5 col-md-5" id="celResumen_' + datos.Id + '">');
    $celPrecio = $('<div class="col-sm-2 col-md-2" id="celPrecio_' + datos.Id + '">');
    $celAcciones = $('<div class="col-sm-2 col-md-2 btn-group btn-group-sm" id="celAcciones_' + datos.Id + '">');
    $btnEdit = $('<a href="#" class="btn btn-info" id="btnEdit_' + datos.Id + '">');
    $btnEdit.append('<span class="glyphicon glyphicon-edit"></span>');
    $btnDel = $('<a href="#" class="btn sm btn-danger" id="btnDel_' + datos.Id + '">');
    $btnDel.append('<span class="glyphicon glyphicon-remove"></span>');
    $celAcciones
        .append($btnEdit)
        .append($btnDel);
    $fila
        .append($celId.append(datos.Id))
        .append($celNombre.append(datos.Nombre))
        .append($celResumen.append(datos.Resumen))
        .append($celPrecio.append(datos.Precio))
        .append($celAcciones);

    return $fila;
};

var eventosAdminProductos = function () {
    var $btnGuardar = $("#btnGuardarAdmin");
    $btnGuardar.off("click").on("click", function () {
        console.log("Evento de guardar");
    });
};
