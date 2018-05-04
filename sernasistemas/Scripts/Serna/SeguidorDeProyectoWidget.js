var initSeguidorDeProyecto = function (element) {
    var $contenedor, $form, $filaFolioProyecto, $celFolioProyecto, $addonProyecto, $txtProyecto, $btnProyecto;
    var $divdetalles, $filaProyecto, $filaSprint, $filaFecha, $filaActividades, $filaDescripcion;
    var $celProyecto, $celSprint, $celFecha, $celActividades, $celDescripcion, $btnDetalles;
    $contenedor = $('<div id="divContenedorProyecto">').append('<h4><span class="glyphicon glyphicon-chevron-down"></span>Consulta el avance de tu proyecto<span class="glyphicon glyphicon-chevron-down"></span></h4>');
    $form = $('<form id="frmProyectos" class="form-group well">').appendTo($contenedor);
    $filaFolioProyecto = $('<div id="divFilaProyecto" class="row">').appendTo($form);
    $celFolioProyecto = $('<div id="celFilaProyecto" class="col-md-12 input-group">').appendTo($filaFolioProyecto);
    $addonProyecto = $('<span class="input-group-addon" id="addonProyecto"><i class="glyphicon glyphicon-user"></i></span>').appendTo($celFolioProyecto);
    $txtProyecto = $('<input type="text" id="txtTicket" class="form-control" name="txtTicket" placeholder="Escribe tu número de proyecto" required>').appendTo($celFolioProyecto);
    $btnProyecto = $('<a href="#" id="btnConsultarProyecto" class="btn btn-lg btn-primary">Consultar</a>').appendTo($form)
        .off()
        .on("click", consultarStatusProyecto);
    element.append($contenedor);
    $btnDetalles = $('<a href="#" id="btnDetalles" class="btn btn-lg btn-info">Detalles</a>')
        .off()
        .on("click", detallesProyecto);

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

    $btnDetalles.appendTo($divdetalles);
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
            var $divdetalles, $btnDetalles;
            $celProyecto = $("#celProyecto");
            $celSprint = $("#celSprint");
            $celFecha = $("#celFecha");
            $celActividades = $("#celActividades");
            $celDescripcion = $("#celDescripcion");
            $divdetalles = $("#divDetalles");
            $celProyecto.empty().append('<span class="text-info">Proyecto: </span>' + '<span class="text-primary">' + obj.data.Proyecto + '</span><br /><span class="text-primary">' + obj.data.Plataforma + '</span>');
            $celSprint.empty().append('<span class="text-info">Sprint actual: </span>' + '<span class="text-primary">' + obj.data.Sprint + '</span>');
            $celFecha.empty().append('<span class="text-info">Fecha de término: </span>' + '<span class="text-primary">' + obj.data.FechaTermino + '</span>');
            $celActividades.empty().append('<span class="text-info">Actividades restantes: </span>' + '<span class="text-primary">' + obj.data.Actividades + '</span>');
            $celDescripcion.empty().append('<span class="text-info">Descrpición: </span>' + '<span class="text-primary">' + obj.data.Descripcion + '</span>');
            $divdetalles.show("slow");
        })
        .fail(function (obj) {
        }).always(function (obj) {
            $btnConsultar.removeClass("disabled");
        });
};

var detallesProyecto = function () {
    var url = window.location;
    var server = url.protocol + '//' + url.host + (url.host === "localhost" ? url.port : "");
    var $modalBody, $modalFooter, $btnDetalles,
        $filaUsuario, $celUsuario, $txtUsuario, $addonUsuario,
        $filaPassword, $celPassword, $txtPassword, $addonPassword,
        $btnCancelar, $btnAceptar;
    $modalBody = $("#modalBody");
    $modalFooter = $("#modalFooter");

    $modalBody.empty();
    $modalFooter.empty();

    $filaUsuario = $('<div id="modalFilaUsuario" class="row">').appendTo($modalBody);
    $filaPassword = $('<div id="modalFilaPassword" class="row">').appendTo($modalBody);

    $celUsuario = $('<div id="modalCelUsuario" class="col-md-12 input-group">').appendTo($filaUsuario);
    $celPassword = $('<div id="modalCelPassword" class="col-md-12 input-group">').appendTo($filaPassword);

    $addonUsuario = $('<span class="input-group-addon" id="modalAddonUsuario"><i class="glyphicon glyphicon-user"></i></span>').appendTo($celUsuario);
    $txtUsuario = $('<input type="text" id="txtModalUsuario" class="form-control" name="txtModalUsuario" placeholder="Nombre de usuario" required>').appendTo($celUsuario);

    $addonPassword = $('<span class="input-group-addon" id="modalAddonPassword"><i class="glyphicon glyphicon-user"></i></span>').appendTo($celPassword);
    $txtPassword = $('<input type="password" id="txtModalPassword" class="form-control" name="txtModalPassword" placeholder="Escribe tu contraseña" required>').appendTo($celPassword);

    $btnAceptar = $('<a href="#" id="btnModalAceptar", class="btn btn-primary btn-lg">Iniciar sesión</a>')
        .off()
        .on("click", function () {
            IniciarSesion(server, $txtUsuario.val(), $txtPassword.val());
        })
        .appendTo($modalFooter);
    $btnCancelar = $('<a href="#" id="btnModalCancelar", class="btn btn-warning btn-lg">Cancelar</a>')
        .off()
        .on("click", cerrarModal)
        .appendTo($modalFooter);

    jQuery.noConflict();
    $("#myModal").modal('toggle');
}
//debugger;
var IniciarSesion = function (server, usuario, password) {
    $.ajax({
        async: false,
        dataType: "json",
        url: server + "/Home/Login",
        type: "post",
        data: {
            usuario: usuario,
            password: password
        }
    })
        .done(function (obj) {
            debugger;
            if (obj.error === "NO") {
                window.location.href = server + "/Seguimientos/Index";
            } else {
                alert(obj.msg);
            }            
        })
        .fail(function (obj) {

        }).always(function (obj) {

        });
}
var cerrarModal = function () {
    jQuery.noConflict();
    $("#myModal").modal('toggle');
}