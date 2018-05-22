var $resultadosBuscador;

var initBuscadorNegocio = function (element, fcallback) {
    var $form, $filaBuscador, $filaGiros, $celBuscador, $celGiros, $celbtnBuscador;
    var $txtBuscador, $selGiros, $btnBuscar, $addonBuscar;
    $form = $('<form id="frmBuscarNegocio" class="form-group">').appendTo(element);

    $filaBuscador = $('<div id="divFilaBuscador" class="row">').appendTo($form);
    $celBuscador = $('<div id="celBuscador" class="col-md-12 input-group">').appendTo($filaBuscador);
    $txtBuscador = $('<input type="text" id="txtBuscador" class="form-control" name="txtBuscador" placeholder="¿Qué estás buscando?" required>').appendTo($celBuscador);

    $filaGiros = $('<div id="divFilaGiros" class="row">').appendTo($form);
    $celGiros = $('<div id="celGiros" class="col-md-12 input-group">').appendTo($filaGiros);
    $selGiros = $('<select id="selGiros" name="selGiros" class="form-control">').appendTo($celGiros);
    cargarGiros($selGiros);

    $celbtnBuscador = $('<div class="input-group-btn">').appendTo($celBuscador);
    $btnBuscar = $('<a href="#" id="btnBuscar" class="btn btn-primary"><i class="glyphicon glyphicon-search"></i></a>').appendTo($celbtnBuscador)
        .off()
        .on("click", function () {
            $resultadosBuscador = buscar();
            fcallback($resultadosBuscador);
        });
};

var buscar = function () {
    var $r = [];
    for (i = 0; i < 10; i++) {
        $r.push({
            id: i,
            nombre: "Negocio " + i,
            direccion: "Dirección " + i,
            telefono: "Teléfono " + i,
            latitud: "Latitud " + i,
            longitud: "Longitud " + i
        });
    }
    return $r;
};

var cargarGiros = function (element) {
    element.append($('<option>', {
        value: 0,
        text: "--selecciona el giro de tu interés--"
    })).append($('<option>', {
        value: 1,
        text: "Arte y manualidades"
    }));
};