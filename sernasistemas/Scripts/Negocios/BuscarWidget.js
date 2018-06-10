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
    var url = window.location;
    $btnBuscar = $("#btnBuscar");
    $txtBuscador = $("#txtBuscador");
    $selGiro = $("#selGiros");
    $btnBuscar.addClass("disabled");

    var server = url.protocol + '//' + url.host +
        (url.host === "localhost" ? url.port : "") + "/Negocios/BuscarNegocio";
    var $r = [];
    $.ajax({
        async: false,
        dataType: "json",
        url: server,
        type: "post",
        data: {
            consulta: $txtBuscador.val(),
            giro: $selGiro.val()
        }
    })
        .done(function (obj) {
            $.each(obj.resultados, function (i) {
                $this = $(this)[0];
                $r.push({
                    id: $this.Id,
                    nombre: $this.Nombre,
                    direccion: $this.Direccion,
                    telefono: $this.Telefono,
                    latitud: $this.Latitud,
                    longitud: $this.Longitud
                });
            });
        })
        .fail(function (obj) {
            console.log(a);
        }).always(function (obj) {
            $btnBuscar.removeClass("disabled");
        });


    for (i = 0; i < 10; i++) {
    }
    return $r;
};

var cargarGiros = function (element) {
    var url = window.location;
    var $selGiros = $("#selGiros");
    var server = url.protocol + '//' + url.host +
        (url.host === "localhost" ? url.port : "") + "/Negocios/listarGiros";
    var $r = [];
    $.ajax({
        async: false,
        dataType: "json",
        url: server,
        type: "post"
    })
        .done(function (obj) {
            if (obj.resultados.length > 0)
                $selGiros.append('<option value="" selected>-- Elige un giro para filtrar (opcional)--</option>');
            $.each(obj.resultados, function (i) {
                $this = $(this)[0];
                $selGiros.append('<option value="' + $this.Key + '">' + $this.Value + '</option>');
            });
        })
        .fail(function (obj) {
            console.log(a);
        }).always(function (obj) {
        });
};