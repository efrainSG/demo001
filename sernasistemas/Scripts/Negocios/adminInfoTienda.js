var initAdminInfoTienda = function (element, datos) {
    var html = '<h1 class="well">Administrar Perfil Propietario de Tienda</h1>' +
        '<div class="well well-sm form">' +
        '  <div class="row">' +
        '    <div class="col-sm-2 col-md-2">Nombre:' +
        '    </div> ' +
        '    <div class="col-sm-4 col-md-4">' +
        '      <input type="text" class="form-control" id="txtNombreAdmin"></input>' +
        '    </div> ' +
        '    <div class="col-sm-2 col-md-2">Teléfono:' +
        '    </div> ' +
        '    <div class="col-sm-4 col-md-4">' +
        '      <input type="text" class="form-control" id="txtTelefonoAdmin"></input>' +
        '    </div> ' +
        '  </div> ' +
        '  <div class="row">' +
        '    <div class="col-sm-2 col-md-2">Correo electrónico:' +
        '    </div> ' +
        '    <div class="col-sm-4 col-md-4">' +
        '      <input type="mail" class="form-control" id="txtEmailAdmin"></input>' +
        '    </div> ' +
        '  </div> ' +
        '  <div class="row">' +
        '    <div class="col-sm-2 col-md-2">Usuario:' +
        '    </div> ' +
        '    <div class="col-sm-4 col-md-4">' +
        '      <input type="text" class="form-control" id="txtUsuarioAdmin"></input>' +
        '    </div> ' +
        '    <div class="col-sm-2 col-md-2">Contraseña:' +
        '    </div> ' +
        '    <div class="col-sm-4 col-md-4">' +
        '      <input type="password" class="form-control" id="txtPasswordAdmin"></input>' +
        '    </div>' +
        '  </div>' +
        '  <div class="row">' +
        '    <div class="col-sm-4 col-md-4">' +
        '      <a href="#" class="btn btn-sm btn-lg btn-primary" id="btnGuardarAdmin">' +
        '        <span class="glyphicon glyphicon-save"></span>Guardar' +
        '      </a>' +
        '    </div>' +
        '  </div>' +
        '</div > ';
    element.append(html);
    eventosAdminInfoTienda();
};
var cargarAdminInfoTienda = function () {
    var url = window.location;

    var server = url.protocol + '//' + url.host +
        (url.host === "localhost" ? url.port : "") + "/Negocios/obtenerInfoPerfil";
    $.ajax({
        async: false,
        dataType: "json",
        url: server,
        type: "post",
        data: {
            Id: viewmodel.IdUsuario
        }
    })
        .done(function (obj) {
            $("#txtNombreAdmin").val(obj.Nombre);
            $("#txtTelefonoAdmin").val(obj.Telefono);
            $("#txtEmailAdmin").val(obj.Correo);
            $("#txtUsuarioAdmin").val(obj.Usuario);
        })
        .fail(function (obj) {
            console.log(a);
        }).always(function (obj) {
            $btnBuscar.removeClass("disabled");
        });
};
var eventosAdminInfoTienda = function () {
    var $btnGuardar = $("#btnGuardarAdmin");
    $btnGuardar.off("click").on("click", function () {
        console.log("Evento de guardar");
    });
};

 // Inicializa la administración de datos principales de la tienda.
var initAdminTienda = function (element) {
    var html = '<h1 class="well">Administrar Info principal de tienda</h1>' +
        '<div class="well well-sm well-md">' +
        '  <div class="row">' +
        '    <div class="col-sm-2 col-md-2">' +
        '      Nombre:' +
        '    </div>' +
        '    <div class="col-sm-9 col-md-9">' +
        '      <input type="text" id="txtNombreTienda" class="form-control"></input>' +
        '    </div>' +
        '  </div>' +
        '  <div class="row">' +
        '    <div class="col-sm-2 col-md-2">' +
        '      Dirección:' +
        '    </div>' +
        '    <div class="col-sm-9 col-md-9">' +
        '      <input type="text" id="txtDireccionTienda" class="form-control"></input>' +
        '    </div>' +
        '  </div>' +
        '  <div class="row">' +
        '    <div class="col-sm-2 col-md-2">' +
        '      Teléfono:' +
        '    </div>' +
        '    <div class="col-sm-3 col-md-3">' +
        '      <input type="text" id="txtTelefonoTienda" class="form-control"></input>' +
        '    </div>' +
        '    <div class="col-sm-2 col-md-2">' +
        '      Correo electrónico:' +
        '    </div>' +
        '    <div class="col-sm-4 col-md-4">' +
        '      <input type="mail" id="txtCorreoTienda" class="form-control"></input>' +
        '    </div>' +
        '  </div>' +
        '  <div class="row">' +
        '    <div class="col-sm-2 col-md-2">' +
        '      Latitud:' +
        '    </div>' +
        '    <div class="col-sm-3 col-md-3">' +
        '      <input type="text" id="txtLatitudTienda" class="form-control"></input>' +
        '    </div>' +
        '    <div class="col-sm-3 col-md-3">' +
        '      Longitud:' +
        '    </div>' +
        '    <div class="col-sm-3 col-md-3">' +
        '      <input type="text" id="txtLongitudTienda" class="form-control"></input>' +
        '    </div>' +
        '  </div>' +
        '  <div class="row">' +
        '    <div class="col-sm-2 col-md-2">' +
        '      Razón social:' +
        '    </div>' +
        '    <div class="col-sm-9 col-md-9">' +
        '      <input type="text" id="txtRazonTienda" class="form-control"></input>' +
        '    </div>' +
        '  </div>' +
        '  <div class="row">' +
        '    <div class="col-sm-2 col-md-2">' +
        '      Giro:' +
        '    </div>' +
        '    <div class="col-sm-9 col-md-9">' +
        '      <select id="txtGiroTienda" class="form-control"></select>' +
        '    </div>' +
        '  </div>' +
        '  <div class="row">' +
        '    <div class="col-sm-9 col-md-9">' +
        '      <a href="#" class="btn btn-sm btn-lg btn-primary" id="btnGuardarAdmin">' +
        '        <span class="glyphicon glyphicon-save"></span>Guardar' +
        '      </a>' +
        '    </div>' +
        '  </div>' +
        '</div>';
    element.append(html);
    eventosAdminTienda();
};
var cargarAdminPerfilInfoTienda = function () {
    var url = window.location;

    var server = url.protocol + '//' + url.host +
        (url.host === "localhost" ? url.port : "") + "/Negocios/obtenerInfoNegocio";
    $.ajax({
        async: false,
        dataType: "json",
        url: server,
        type: "post",
        data: {
            Id: viewmodel.IdTienda
        }
    })
        .done(function (obj) {
            $("#txtNombreAdmin").val(obj.Nombre);
            $("#txtTelefonoAdmin").val(obj.Telefono);
            $("#txtEmailAdmin").val(obj.Correo);
            $("#txtUsuarioAdmin").val(obj.Usuario);
        })
        .fail(function (obj) {
            console.log(a);
        }).always(function (obj) {
            $btnBuscar.removeClass("disabled");
        });
};

var eventosAdminTienda = function () {
    var $btnGuardar = $("#btnGuardarAdminTienda");
    $btnGuardar.off("click").on("click", function () {
        console.log("Evento de guardar");
    });
};
