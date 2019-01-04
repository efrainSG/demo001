// Perfil del administrador de la tienda
var initAdminInfoTienda = function (element, datos) {
    var $form = $('<div class="well well-sm form">'),
        $fila1 = $('<div class="row">'),
        $col01 = $('<div class="col-sm-2 col-md-2">'),
        $col02 = $('<div class="col-sm-4 col-md-4">'),
        $txtNombre = $('<input type="text" class="form-control" id="txtNombreAdmin">'),
        $col03 = $('<div class="col-sm-2 col-md-2">'),
        $col04 = $('<div class="col-sm-4 col-md-4">'),
        $txtTelefono = $('<input type="text" class="form-control" id="txtTelefonoAdmin">'),
        $fila2 = $('<div class="row">'),
        $col05 = $('<div class="col-sm-2 col-md-2">'),
        $col06 = $('<div class="col-sm-4 col-md-4">'),
        $txtCorreo = $('<input type="mail" class="form-control" id="txtEmailAdmin">'),
        $fila3 = $('<div class="row">'),
        $col07 = $('<div class="col-sm-2 col-md-2">'),
        $col08 = $('<div class="col-sm-4 col-md-4">'),
        $txtUsuario = $('<input type="text" class="form-control" id="txtUsuarioAdmin">'),
        $col09 = $('<div class="col-sm-2 col-md-2">'),
        $col0A = $('<div class="col-sm-4 col-md-4">'),
        $txtPassword = $('<input type="password" class="form-control" id="txtPasswordAdmin">'),
        $fila4 = $('<div class="row">'),
        $col0B = $('<div class="col-sm-4 col-md-4">'),
        $btnGuardar = $('<a href="#" class="btn btn-sm btn-lg btn-primary" id="btnGuardarAdmin"><span class="glyphicon glyphicon-save"></span>Guardar</a>');
    $col01.append("Nombre:");
    $col02.append($txtNombre);
    $col03.append("Teléfono:");
    $col04.append($txtTelefono);
    $col05.append("Correo electrónico:");
    $col06.append($txtCorreo);
    $col07.append("Usuario:");
    $col08.append($txtUsuario);
    $col09.append("Contraseña:");
    $col0A.append($txtPassword);
    $col0B.append($btnGuardar);
    $form.append($fila1).append($fila2).append($fila3).append($fila4);
    $fila1.append($col01).append($col02).append($col03).append($col04);
    $fila2.append($col05).append($col06).append($col07).append($col08);
    $fila3.append($col09).append($col0A);
    $fila4.append($col0B);
    var html = '<h2 class="well">Administrar Perfil Propietario de Tienda</h2>';
    element.append(html).append($form);
    var datos = cargarAdminInfoTienda();

    $("#txtNombreAdmin").val(datos.Nombre);
    $("#txtTelefonoAdmin").val(datos.Telefono);
    $("#txtEmailAdmin").val(datos.Correo);
    $("#txtUsuarioAdmin").val(datos.Usuario);

    eventosAdminInfoTienda();
};
var cargarAdminInfoTienda = function () {
    var url = window.location;
    var datos;
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
            datos = {
                Nombre: obj.Propietario.Nombre,
                Telefono: obj.Propietario.Telefono,
                Correo: obj.Propietario.Correo,
                Usuario: obj.Propietario.Usuario,
                Id: obj.Propietario.Id,
                error: obj.tieneError
            };
        })
        .fail(function (obj) {
            datos = {
                Nombre: "",
                Telefono: "",
                Correo: "",
                Usuario: "",
                Id: 0,
                error: true
            };
        }).always(function (obj) {
        });
    return datos;
};
var eventosAdminInfoTienda = function () {
    var $btnGuardar = $("#btnGuardarAdmin");
    $btnGuardar.off("click").on("click", function () {
        var clases = $btnGuardar.attr("class");
        var url = window.location;
        var server = url.protocol + '//' + url.host + (url.host === "localhost" ? url.port : "") + "/Negocios/guardarInfoPerfil";
        $btnGuardar.addClass("disabled");
        $.ajax({
            url: server,
            data: {
                id: viewmodel.IdTienda,
                nombre: $("#txtNombreAdmin").val(),
                correo: $("#txtEmailAdmin").val(),
                telefono: $("#txtTelefonoAdmin").val(),
                password: $("#txtPasswordAdmin").val(),
            },
            type: "post",
            dataType: "json"
        })
            .done(function (obj) {
                console.log(obj);
            })
            .fail(function (a) {
                console.log(a);
            })
            .always(function (e) {
                $btnGuardar.removeClass("disabled");
            });

    });
};

// Inicializa la administración de datos principales de la tienda.
var initAdminTienda = function (element) {
    var $form = $('<div class="well well-sm form" id="frmDatos">'),

        $tab1 = $('<li class="active" > <a data-toggle="tab" href="#menu1">Datos generales</a></li >'),
        $tab2 = $('<li><a data-toggle="tab" href="#menu2">Info de secciones</a></li>'),
        $navegador = $('<ul class="nav nav-tabs">')
            .append($tab1).append($tab2),

        $panel1 = $('<div id="menu1" class="tab-pane fade in active">'),
        $panel2 = $('<div id="menu2" class="tab-pane">'),
        $contenedor = $('<div class="tab-content">')
            .append($panel1).append($panel2),

        $txtNombreTienda = $('<input type="text" id="txtNombreTienda" class="form-control">'),
        $txtDireccionTienda = $('<input type="text" id="txtDireccionTienda" class="form-control">'),
        $txtTelefonoTienda = $('<input type="text" id="txtTelefonoTienda" class="form-control">'),
        $txtCorreoTienda = $('<input type="mail" id="txtCorreoTienda" class="form-control">'),
        //$txtLatitudTienda = $('<input type="text" id="txtLatitudTienda" class="form-control">'),
        //$txtLongitudTienda = $('<input type="text" id="txtLongitudTienda" class="form-control">'),
        $txtRazonTienda = $('<input type="text" id="txtRazonTienda" class="form-control">'),
        $txtGiroTienda = $('<select id="txtGiroTienda" class="form-control">'),
        $spanGuardar = $('<span class="glyphicon glyphicon-save">'),
        $btnGuardar = $('<a href="#" class="btn btn-sm btn-lg btn-primary" id="btnGuardarAdminTienda">')
            .append($spanGuardar).append('Guardar'),

        $col01 = $('<div class="col-sm-2 col-md-2">').append("Nombre:"),
        $col02 = $('<div class="col-sm-9 col-md-9">').append($txtNombreTienda),
        $col03 = $('<div class="col-sm-2 col-md-2">').append("Dirección:"),
        $col04 = $('<div class="col-sm-9 col-md-9">').append($txtDireccionTienda),
        $col05 = $('<div class="col-sm-2 col-md-2">').append("Teléfono:"),
        $col06 = $('<div class="col-sm-3 col-md-3">').append($txtTelefonoTienda),
        $col07 = $('<div class="col-sm-2 col-md-2">').append("Correo electrónico:"),
        $col08 = $('<div class="col-sm-4 col-md-4">').append($txtCorreoTienda),
        //$col09 = $('<div class="col-sm-2 col-md-2">').append("Latitud:"),
        //$col0A = $('<div class="col-sm-3 col-md-3">').append($txtLatitudTienda),
        //$col0B = $('<div class="col-sm-2 col-md-2">').append("Longitud:"),
        //$col0C = $('<div class="col-sm-3 col-md-3">').append($txtLongitudTienda),
        $col0D = $('<div class="col-sm-2 col-md-2">').append("Razón social:"),
        $col0E = $('<div class="col-sm-9 col-md-9">').append($txtRazonTienda),
        $col0F = $('<div class="col-sm-2 col-md-2">').append("Giro:"),
        $col10 = $('<div class="col-sm-9 col-md-9">').append($txtGiroTienda),
        $col11 = $('<div class="col-sm-9 col-md-9">').append($btnGuardar),

        $fila1 = $('<div class="row">').append($col01).append($col02),
        $fila2 = $('<div class="row">').append($col03).append($col04),
        $fila3 = $('<div class="row">').append($col05).append($col06).append($col07).append($col08),
        //$fila4 = $('<div class="row">').append($col09).append($col0A).append($col0B).append($col0C),
        $fila5 = $('<div class="row">').append($col0D).append($col0E),
        $fila6 = $('<div class="row">').append($col0F).append($col10),
        $fila7 = $('<div class="row">').append($col11),

        $contenidoPanel1 = $('<div class="well well-sm">')
            .append($fila1).append($fila2).append($fila3)
            //.append($fila4)
            .append($fila5).append($fila6).append($fila7),
        $contenidoPanel2 = $('<div class="well well-sm">');

    $form.append($navegador).append($contenedor);
    $panel1.append($contenidoPanel1);
    $panel2.append($contenidoPanel2);

    var html = '<h2 class="well">Administrar Info principal de tienda</h2>';

    element.append(html).append($form);
    cargarCatalogos($txtGiroTienda, $contenidoPanel2);
    cargarAdminTienda();
    eventosAdminTienda();
};
var cargarCatalogos = function ($selGiros, $contenido) {
    var deferred = $.Deferred();
    var url = window.location;

    var server = url.protocol + '//' + url.host +
        (url.host === "localhost" ? url.port : "") + "/Negocios/listarGiros";
    $.ajax({
        async: false,
        dataType: "json",
        url: server,
        type: "post"
    })
        .done(function (obj) {
            var $giros = $selGiros;
            $(obj.resultados).each(function (r) {
                var $this = $(this)[0];
                $giros.append($('<option>', { value: $this.Key, text: $this.Value }));
            });
            deferred.resolve({ Msg: "Ok", Obj: obj });
            server = url.protocol + '//' + url.host + (url.host === "localhost" ? url.port : "") + "/Negocios/listarSecciones";
            $.ajax({
                data: {
                    idTienda: viewmodel.IdTienda
                },
                async: false,
                dataType: "json",
                url: server,
                type: "post"
            })
                .done(function (obj) {
                    deferred.resolve({ Msg: "Ok", Obj: obj });
                    $(obj.resultados).each(function (r) {
                        var $this = $(this)[0];
                        var $valores = $this.Value.split("|");
                        $contenido
                            .append($('<div class="row">')
                                .append($('<div class="col-sm-1">')
                                    .append($('<input type="hidden" id="hidSeccion_' + $this.Key + '_' + viewmodel.IdTienda + '">').val($valores[0]))
                                )
                                .append($('<div class="col-sm-2">')
                                    .append($valores[1])
                                )
                                .append($('<div class="col-sm-3">')
                                    .append($('<input type="text" id="txtTituloSeccion_' + $this.Key + '_' + viewmodel.IdTienda + '" class="form-control">')
                                        .val($valores[2]))
                                )
                                .append($('<div class="col-sm-4">')
                                    .append($('<textarea id="txtDescripcionSeccion_' + $this.Key + '_' + viewmodel.IdTienda + '" class="form-control" rows="3">')
                                        .val($valores[3]))
                                )
                                .append($('<div class="col-sm-1">')
                                    .append($('<a href="#btn_guardar_' + $this.Key + '_' + viewmodel.IdTienda + '" id="btnGuardarSeccion_' + $this.Key + '_' + viewmodel.IdTienda + '" class="btn btn-sm btn-success" id="btn_guardar_' + $this.Key + '_' + viewmodel.IdTienda + '">')
                                        .append('<span class="glyphicon glyphicon-save"></span>')
                                    )
                                )
                            );
                    });
                })
                .fail(function (obj) {
                    deferred.reject({ Msg: "Error al cargar secciones", Obj: obj });
                });
        })
        .fail(function (obj) {
            deferred.reject({ Msg: "Error al cargar giros", Obj: obj });
        });

    return deferred;
}
var cargarAdminTienda = function () {
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
            console.log(obj);
            $("#txtNombreTienda").val(obj.InfoTienda.Nombre);
            $("#txtDireccionTienda").val(obj.InfoTienda.Direccion);
            $("#txtTelefonoTienda").val(obj.InfoTienda.Telefono);
            $("#txtRazonTienda").val(obj.InfoTienda.RazonSocial);
            //$("#txtLatitudTienda").val(obj.InfoTienda.Latitud);
            //$("#txtLongitudTienda").val(obj.InfoTienda.Longitud);
            $("#txtCorreoTienda").val(obj.InfoTienda.CorreoElectronico);
            $("#txtGiroTienda").val(obj.InfoTienda.Giro);
        })
        .fail(function (obj) {
            console.log(obj);
        }).always(function (obj) {
        });
};
var eventosAdminTienda = function () {
    var $btnGuardar = $("#btnGuardarAdminTienda");
    $btnGuardar.off("click").on("click", function () {
        var clases = $btnGuardar.attr("class");
        var url = window.location;
        var server = url.protocol + '//' + url.host + (url.host === "localhost" ? url.port : "") + "/Negocios/guardarInfoNegocio";
        $btnGuardar.addClass("disabled");
        $.ajax({
            url: server,
            data: {
                id: viewmodel.IdTienda,
                nombre: $("#txtNombreTienda").val(),
                direccion: $("#txtDireccionTienda").val(),
                telefono: $("#txtTelefonoTienda").val(),
                razonsocial: $("#txtRazonTienda").val(),
                latitud: "", //$("#txtLatitudTienda").val(),
                longitud: "", //$("#txtLongitudTienda").val(),
                correo: $("#txtCorreoTienda").val(),
                giro: $("#txtGiroTienda").val()
            },
            type: "post",
            dataType: "json"
        })
            .done(function (obj) {
                console.log(obj);
            })
            .fail(function (a) {
                console.log(a);
            })
            .always(function (e) {
                $btnGuardar.removeClass("disabled");
            });

    });
    $btnGuardarSeccion = $("[id^='btnGuardarSeccion_']");
    $btnGuardarSeccion.off("click").on("click", function () {
        $self = $(this);
        var split = $self.attr("id").split("_");
        var url = window.location;
        var server = url.protocol + '//' + url.host + (url.host === "localhost" ? url.port : "") + "/Negocios/guardarSeccion";
        $self.addClass("disabled");
        $.ajax({
            url: server,
            data: {
                IdSeccion: split[1],
                IdTienda: split[2],
                Titulo: $("#txtTituloSeccion_" + split[1] + "_" + split[2]).val(),
                Descripcion: $("#txtDescripcionSeccion_" + split[1] + "_" + split[2]).val().replace("<", "&lt;").replace(">", "&gt;")
            },
            type: "post",
            dataType: "json"
        }).done(function (obj) {

        }).fail(function (obj) {
            console.log(obj);
        }).always(function (e) {
            $self.removeClass("disabled");
        });
    });
};

var initSucursales = function (element) {
    var $form = $('<div class="well well-sm form" id="frmDatos">'),

        $tab1 = $('<li class="active" > <a data-toggle="tab" href="#menu1">Datos generales</a></li >'),
        $navegador = $('<ul class="nav nav-tabs">')
            .append($tab1),

        $panel1 = $('<div id="menu1" class="tab-pane fade in active">'),
        $contenedor = $('<div class="tab-content">')
            .append($panel1),
        $txtId = $('<input type="hidden" id="txtId">'),
        $txtDireccionTienda = $('<input type="text" id="txtDireccionSucursal" class="form-control">'),
        $txtTelefonoTienda = $('<input type="text" id="txtTelefonoSucursal" class="form-control">'),
        $txtCorreoTienda = $('<input type="mail" id="txtCorreoSucursal" class="form-control">'),
        $txtTipoSucursal = $('<select id="selTipoSucursal" class="form-control">'),
        $spanGuardar = $('<span class="glyphicon glyphicon-save">'),
        $btnGuardar = $('<a href="#" class="btn btn-sm btn-lg btn-primary" id="btnGuardarSucursal">')
            .append($spanGuardar).append('Guardar'),

        $col03 = $('<div class="col-sm-2 col-md-2">').append("Dirección:"),
        $col04 = $('<div class="col-sm-9 col-md-9">').append($txtDireccionTienda),
        $col05 = $('<div class="col-sm-2 col-md-2">').append("Teléfono:"),
        $col06 = $('<div class="col-sm-3 col-md-3">').append($txtTelefonoTienda),
        $col07 = $('<div class="col-sm-2 col-md-2">').append("Correo electrónico:"),
        $col08 = $('<div class="col-sm-4 col-md-4">').append($txtCorreoTienda),
        $col0F = $('<div class="col-sm-2 col-md-2">').append("Tipo de local:"),
        $col10 = $('<div class="col-sm-9 col-md-9">').append($txtTipoSucursal),
        $col11 = $('<div class="col-sm-9 col-md-9">').append($btnGuardar),

        $fila2 = $('<div class="row">').append($col03).append($col04),
        $fila3 = $('<div class="row">').append($col05).append($col06).append($col07).append($col08),
        $fila6 = $('<div class="row">').append($col0F).append($col10),
        $fila7 = $('<div class="row">').append($col11),

        $contenidoPanel1 = $('<div class="well well-sm">')
            .append($txtId)
            .append($fila2).append($fila3).append($fila6).append($fila7);

    $form.append($navegador).append($contenedor);
    $form.hide();
    $panel1.append($contenidoPanel1);

    var html = '<h2 class="well">Administrar información de local</h2>';
    element.append(html).append($form);
    cargarTiposSucursales($txtTipoSucursal);
    cargarAdminSucursales(element);
    eventosSucursales();
};
var cargarAdminSucursales = function (contenedor) {
    var url = window.location;
    var server = url.protocol + '//' + url.host +
        (url.host === "localhost" ? url.port : "") + "/Negocios/listarSucursales";
    $.ajax({
        async: false,
        dataType: "json",
        url: server,
        type: "post",
        data: {
            IdTienda: viewmodel.IdTienda
        }
    })
        .done(function (obj) {
            var datos = obj.Sucursales;
            $.each(datos, function (s) {
                contenedor.append(SucursalHelper({
                    "Id": $(this)[0].Id,
                    "Direccion": $(this)[0].Direccion,
                    "Correo": $(this)[0].Correo,
                    "Telefono": $(this)[0].Telefono,
                    "IdTipo": $(this)[0].IdTipo,
                    "Tipo": $(this)[0].Tipo,
                    "Status": $(this)[0].Status,
                    "Visible": $(this)[0].Visible
                }));

            });
        })
        .fail(function (obj) {
            console.log(obj);
        }).always(function (obj) {
        });
};
var eventosSucursales = function () {
    var $btnGuardar = $("[id^='btnGuardar']"),
        $btnsEdit = $("[id^='btnEdit_']"),
        $btnsDel = $("[id^='btnToggle_']");

    $btnGuardar.off("click").on("click", function () {
        var clases = $btnGuardar.attr("class");
        var url = window.location;
        var server = url.protocol + '//' + url.host + (url.host === "localhost" ? url.port : "") + "/Negocios/guardarSucursal";
        $btnGuardar.addClass("disabled");
        $.ajax({
            url: server,
            data: {
                Id: $("#txtId").val(),
                IdTienda: viewmodel.IdTienda,
                IdTipo: $("#selTipoSucursal").val() || 0,
                Status: 0,

                Direccion: $("#txtDireccionSucursal").val(),
                Telefono: $("#txtTelefonoSucursal").val(),
                Correo: $("#txtCorreoSucursal").val()
            },
            type: "post",
            dataType: "json"
        })
            .done(function (obj) {
                console.log(obj);
            })
            .fail(function (a) {
                console.log(a);
            })
            .always(function (e) {
                $btnGuardar.removeClass("disabled");
            });
    });
    $btnsEdit.off("click").on("click", function () { cargarDatosSucursal($(this)) });
    $btnsDel.off("click").on("click", function () {
        var $self = $(this);
        var clases = $self.attr("class");
        var url = window.location;
        var server = url.protocol + '//' + url.host + (url.host === "localhost" ? url.port : "") + "/Negocios/invertirSucursal";
        $self.addClass("disabled");
        $.ajax({
            url: server,
            data: {
                id: parseInt($self.attr('id').split('_')[1]),
                idTipo: 4
            },
            type: "post",
            dataType: "json",
            async: false
        })
            .done(function (obj) {
                if (obj.response.Sucursal.Visible) {
                    $("#btnToggle_" + obj.response.Sucursal.Id).removeClass("btn-warning").addClass("btn-success");
                    $("#btnToggle_" + obj.response.Sucursal.Id).find('span').removeClass("glyphicon-eye-close").addClass("glyphicon-eye-open");
                } else {
                    $("#btnToggle_" + obj.response.Sucursal.Id).removeClass("btn-success").addClass("btn-warning");
                    $("#btnToggle_" + obj.response.Sucursal.Id).find('span').removeClass("glyphicon-eye-open").addClass("glyphicon-eye-close");
                }
            })
            .fail(function (a) {
                console.log(a);
            })
            .always(function (e) {
                $self.removeClass("disabled");
            });
    });
};
var cargarTiposSucursales = function ($selTipos) {
    var deferred = $.Deferred();
    var url = window.location;

    var server = url.protocol + '//' + url.host +
        (url.host === "localhost" ? url.port : "") + "/Negocios/listarTiposSucursales";
    $.ajax({
        async: false,
        dataType: "json",
        url: server,
        type: "post"
    })
        .done(function (obj) {
            var $tipos = $selTipos;
            $(obj.resultados).each(function (r) {
                var $this = $(this)[0];
                $tipos.append($('<option>', { value: $this.Key, text: $this.Value }));
            });
            deferred.resolve({ Msg: "Ok", Obj: obj });
        })
        .fail(function (obj) {
            deferred.reject({ Msg: "Error al cargar tipos de sucursales", Obj: obj });
        });

    return deferred;
}
var cargarDatosSucursal = function (boton) {
    var datos = {
        Sucursal: { Id: 0, Direccion: "", Telefono: "", Correo: "", IdTipo: 0 }
    };

    var contenedor = boton.parent().parent().parent().children("div:lt(5)");
    boton.parent().closest('[id^="btnDel"]').attr("disabled", "disabled");
    $("#frmDatos").show();
    $('[id^="btnDel"]').removeAttr("disabled");
    debugger;
    if (contenedor.attr("id") == "frmDatos")
        return;
    console.log(contenedor);
    contenedor.each(function (o, s) {
        console.log(s);
        switch (o) {
            case 0:
                $("#txtId").val($(s).children(0).val()).attr("diabled", "disabled");
                break;
            case 1:
                $("#txtDireccionSucursal").val($(s).text());
                break;
            case 2:
                $("#txtCorreoSucursal").val($(s).text());
                break;
            case 3:
                $("#txtTelefonoSucursal").val($(s).text());
                break;
            case 4:
                $("#selTipoSucursal").val($(s).children(0).val());
                break;
        }
    });
    return datos;
}
var SucursalHelper = function (datos) {
    var $fila, $celId, $celDireccion, $celCorreo, $celTelefono, $hIdTipo, $celTipo, $celAcciones;
    var $btnEdit, $btnDel, $btnDelGlyph;

    $fila = $('<div class="row">');
    $hIdTipo = $('<input type="hidden" id="hIdTipo_' + datos.Id + '">').val(datos.IdTipo);
    $celId = $('<div class="col-sm-1 col-md-1" id="celId_' + datos.Id + '">');
    $celDireccion = $('<div class="col-sm-3 col-md-3" id="celDireccion_' + datos.Id + '">');
    $celCorreo = $('<div class="col-sm-3 col-md-3" id="celCorreo_' + datos.Id + '">');
    $celTelefono = $('<div class="col-sm-2 col-md-2" id="celTelefono_' + datos.Id + '">');
    $celTipo = $('<div class="col-sm-2 col-md-2" id="celTipo_' + datos.Id + '">');
    $celAcciones = $('<div class="col-sm-1 col-md-1 btn-group btn-group-sm" id="celAcciones_' + datos.Id + '">');
    $btnEdit = $('<a href="#" class="btn btn-info" id="btnEdit_' + datos.Id + '">');
    $btnEdit.append('<span class="glyphicon glyphicon-edit" id="btnEdit_' + datos.Id + '"></span>');
    $btnDel = $('<a href="#" class="btn sm" id="btnToggle_' + datos.Id + '">');
    $btnDelGlyph = $('<span class="glyphicon">');
    if (datos.Visible) {
        $btnDel.addClass("btn-success");
        $btnDelGlyph.addClass("glyphicon-eye-open");
    } else {
        $btnDel.addClass("btn-warning");
        $btnDelGlyph.addClass("glyphicon-eye-close");
    }
    $celAcciones
        .append($btnEdit)
        .append($btnDel.append($btnDelGlyph));
    $fila
        .append($celId.append($('<input type="hidden" id="txtId_' + datos.Id + '">').val(datos.Id)))
        .append($celDireccion.append(datos.Direccion))
        .append($celCorreo.append(datos.Correo))
        .append($celTelefono.append(datos.Telefono))
        .append($celTipo.append(datos.Tipo).append($hIdTipo))
        .append($celAcciones);

    return $fila;
};
