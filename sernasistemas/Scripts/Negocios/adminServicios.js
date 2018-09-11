var initAdminServicios = function (element) {
        var html = '<h1 class="well">Administrar Servicios</h1>' +
            '<div class="well well-sm form">' +
            '  <div class="row">' +
            '    <div class="col-sm-1 col-md-1">Id</div> ' +
            '    <div class="col-sm-2 col-md-2">Servicio</div> ' +
            '    <div class="col-sm-5 col-md-5">Resumen</div> ' +
            '    <div class="col-sm-2 col-md-2">Precio</div> ' +
            '    <div class="col-sm-2 col-md-2">Acciones</div> ' +
            '</div> ';
        element.append(html).append(prodServhelper(
            { "Id": "1", "Nombre": "Elemento", "Resumen": "Descripción breve", "Precio": "10.00" }
        ));
        eventosAdminServicios();
    };

var eventosAdminServicios = function () {
    var $btnGuardar = $("#btnGuardarAdmin");
    $btnGuardar.off("click").on("click", function () {
        console.log("Evento de guardar");
    });
};
