var initSeguidorDeProyecto = function (element) {
    var $contenedor, $form, $filaFolioProyecto, $celFolioProyecto, $addonProyecto, $txtProyecto, $btnProyecto;
    var $divdetalles, $filaProyecto, $filaSprint, $filaFecha, $filaActividades, $filaDescripcion;
    var $celProyecto, $celSprint, $celFecha, $celActividades, $celDescripcion;
    $contenedor = $('<div id="divContenedorProyecto">').append('<h4>Consulta el avance de tu proyecto</h4>');
    $form = $('<form id="frmProyectos" class="form-group well">').appendTo($contenedor);
    $filaFolioProyecto = $('<div id="divFilaProyecto" class="row">').appendTo($form);
    $celFolioProyecto = $('<div id="celFilaProyecto" class="col-md-12 input-group">').appendTo($filaFolioProyecto);
    $addonProyecto = $('<span class="input-group-addon" id="addonProyecto"><i class="glyphicon glyphicon-user"></i></span>').appendTo($celFolioProyecto);
    $txtProyecto = $('<input type="text" id="txtTicket" class="form-control" name="txtTicket" placeholder="Escribe tu número de proyecto" required>').appendTo($celFolioProyecto);
    $btnProyecto = $('<a href="#" id="btnConsultarProyecto" class="btn btn-lg btn-primary">Consultar</a>').appendTo($form)
        .off()
        .on("click", consultarStatusProyecto);
    element.append($contenedor);

    $divdetalles = $('<div class="well well-sm" id="divDetalles" style="display:none;">').appendTo($contenedor);

    $filaProyecto = $('<div class="row" id="filaProyecto">').appendTo($divdetalles);
    $filaSprint = $('<div class="row" id="filaSprint">').appendTo($divdetalles);
    $filaFecha = $('<div class="row" id="filaFecha">').appendTo($divdetalles);
    $filaActividades = $('<div class="row" id="filaActividades">').appendTo($divdetalles);
    $filaDescripcion = $('<div class="row" id="filaDescripcion">').appendTo($divdetalles);

    $celProyecto = $('<div class="col-md-12" id="celProyecto">').appendTo($filaProyecto);
    $celSprint = $('<div class="col-md-12" id="celSprint">').appendTo($filaSprint);
    $celFecha = $('<div class="col-md-12" id="celFecha">').appendTo($filaFecha);
    $celActividades = $('<div class="col-md-12" id="celActividades">').appendTo($filaActividades);
    $celDescripcion = $('<div class="col-md-12" id="celDescripcion">').appendTo($filaDescripcion);
};

var consultarStatusProyecto = function () {
    var $btnConsultar, $txtFolio;
    var url = window.location;
    var server = url.protocol + '//' + url.host + (url.host === "localhost" ? url.port : "") + "/Home/ConsultaProyecto";
    $btnConsultar = $("#btnConsultarProyecto");
    $txtFolio = $("#txtTicket");
    $btnConsultar.addClass("disabled");

    $.ajax({
        async: false,
        dataType: "json",
        url: server,
        type: "post",
        data: {
            Folio: $txtFolio.val()
        }
    })
        .done(function (obj) {
            var $celProyecto, $celSprint, $celFecha, $celActividades, $celDescripcion;
            var $divdetalles;
            $celProyecto = $("#celProyecto");
            $celSprint = $("#celSprint");
            $celFecha = $("#celFecha");
            $celActividades = $("#celActividades");
            $celDescripcion = $("#celDescripcion");
            $divdetalles = $("#divDetalles");
            
            $celProyecto.append('<span class="text-info">Proyecto: </span>' + '<span class="text-primary">' + obj.data.Proyecto + '</span><br /><span class="text-primary">' + obj.data.Plataforma + '</span>');
            $celSprint.append('<span class="text-info">Sprint actual: </span>' + '<span class="text-primary">' + obj.data.Sprint + '</span>');
            $celFecha.append('<span class="text-info">Fecha de término: </span>' + '<span class="text-primary">' + obj.data.FechaTermino + '</span>');
            $celActividades.append('<span class="text-info">Actividades restantes: </span>' + '<span class="text-primary">' + obj.data.Actividades + '</span>');
            $celDescripcion.append('<span class="text-info">Descrpición: </span>' + '<span class="text-primary">' + obj.data.Descripcion + '</span>');
            $divdetalles.show("slow");
        })
        .fail(function (obj) {
        }).always(function (obj) {
            $btnConsultar.removeClass("disabled");
        });
};