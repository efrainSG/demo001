var initAdminServicios = function (element, datos) {
    var $form = $('<div class="well well-sm form" id="frmDatos" style="display:none;">'),

        $navegador = $('<ul class="nav nav-tabs">'),
        $tab1 = $('<li class="active" > <a data-toggle="tab" href="#menu1">Datos generales</a></li >'),
        $tab2 = $('<li><a data-toggle="tab" href="#menu2">Datos adicionales</a></li>');

    var $contenedor = $('<div class="tab-content">'),
        $panel1 = $('<div id="menu1" class="tab-pane fade in active">'),
        $panel2 = $('<div id="menu2" class="tab-pane">');

    $form.append($navegador).append($contenedor);
    $navegador.append($tab1).append($tab2);
    $contenedor.append($panel1).append($panel2);

    var $contenidoPanel1 = $('<div class="well well-sm">'),
        $fila1 = $('<div class="row">'),
        $col01 = $('<div class="col-sm-3">'),
        $txtId = $('<input type="number" id="txtId" placeholder="Id" class="form-control">'),
        $col02 = $('<div class="col-sm-3">'),
        $txtIdTienda = $('<input type="number" id="txtIdTienda" placeholder="Id de tienda" class="form-control">'),
        $col03 = $('<div class="col-sm-3">'),
        $txtNombre = $('<input type="text" id="txtNombre" placeholder="Nombre" class="form-control">'),
        $fila2 = $('<div class="row">'),
        $col04 = $('<div class="col-sm-3">'),
        $txtDescBreve = $('<input type="text" id="txtDescBreve" placeholder="Descripción breve" class="form-control">'),
        $col05 = $('<div class="col-sm-3">'),
        $txtDescripcion = $('<input type="text" id="txtDescripcion" placeholder="Descripción completa" class="form-control">'),
        $fila3 = $('<div class="row">'),
        $col06 = $('<div class="col-sm-3">'),
        $txtPrecio = $('<input type="number" id="txtPrecio" placeholder="Precio" class="form-control">'),
        $col07 = $('<div class="col-sm-3">'),
        $txtUnidad = $('<input type="text" id="txtUnidad" placeholder="Unidad" class="form-control">'),
        $col08 = $('<div class="col-sm-3">'),
        $txtTipo = $('<input type="number" id="txtIdTipo" placeholder="Tipo de oferta" class="form-control">'),
        $fila4 = $('<div class="row">'),
        $col09 = $('<div class="col-sm-3">'),
        $btnGuardar = $('<a href="#" class="btn btn-sm btn-lg btn-primary" id="btnGuardar2"><span class="glyphicon glyphicon-save"></span>Guardar</a>');
    $contenidoPanel1.append($fila1).append($fila2).append($fila3).append($fila4);
    $fila1.append($col01.append($txtId)).append($col02.append($txtIdTienda)).append($col03.append($txtNombre));
    $fila1.append($col04.append($txtDescBreve)).append($col05.append($txtDescripcion));
    $fila1.append($col06.append($txtPrecio)).append($col07.append($txtUnidad)).append($col08.append($txtTipo));
    $fila1.append($col09.append($btnGuardar));

    var $contenidoPanel2 = $('<div class="well well-sm">'),
        $fila5 = $('<div class="row">'),
        $col0A = $('<div class="col-sm-3">'),
        $txtIdAdicional = $('<input type="number" id="txtIdAdicional" placeholder="Id" class="form-control">'),
        $col0B = $('<div class="col-sm-3">'),
        $col0C = $('<div class="col-sm-3">'),
        $txtIdSucursal = $('<input type="number" id="txtIdSucursal" placeholder="Id de sucursal" class="form-control">'),
        $col0D = $('<div class="col-sm-3">'),
        $fila6 = $('<div class="row">'),
        $col0E = $('<div class="col-sm-3">');
    $contenidoPanel2.append($fila5).append($fila6);
    $fila5.append($col0A.append($txtIdAdicional)).append($col0B.append($txtIdSucursal));

    $panel1.append($contenidoPanel1);
    $panel2.append($contenidoPanel2);

    cargarServicios(datos, element.append('<h2 class="well">Administrar Servicios</h2>').append($form));
    eventosAdminServicios();
};


var cargarServicios = function (datos, contenedor) {
    var url = window.location;
    var server = url.protocol + '//' + url.host +
        (url.host === "localhost" ? url.port : "") + "/Negocios/obtenerOfertas";
    $.ajax({
        async: false,
        dataType: "json",
        url: server,
        type: "post",
        data: {
            Id: viewmodel.IdTienda,
            Tipo: 2
        }
    })
        .done(function (obj) {
            $.each(obj.Servicios, function (item) {
                    contenedor.append(prodServhelper({
                        "Id": $(this)[0].Id,
                        "Nombre": $(this)[0].Nombre,
                        "Resumen": $(this)[0].DescripcionBreve,
                        "Precio": $(this)[0].Precio,
                        "Visible": $(this)[0].Visible
                    }));
            });
        })
        .fail(function (obj) {
            console.log(a);
        }).always(function (obj) {
        });
}

var cargarDatosServicio = function (id) {
    var url = window.location;
    var datos;
    var server = url.protocol + '//' + url.host +
        (url.host === "localhost" ? url.port : "") + "/Negocios/obtenerOferta";
    $.ajax({
        async: false,
        dataType: "json",
        url: server,
        type: "post",
        data: {
            IdOferta: id,
            Tipo: 2
        }
    })
        .done(function (obj) {
            console.log(obj);
            datos = obj;
        })
        .fail(function (obj) {
            console.log(a);
        }).always(function (obj) {
        });
    return datos;
}



var eventosAdminServicios = function () {
    var $btnGuardar = $("[id^='btnGuardar']"),
        $btnsEdit = $("[id^='btnEdit_']"),
        $btnsDel = $("[id^='btnToggle_']");

    $btnGuardar.off("click").on("click", function () {
        var clases = $btnGuardar.attr("class");
        var url = window.location;
        var server = url.protocol + '//' + url.host + (url.host === "localhost" ? url.port : "") + "/Negocios/guardarOferta";
        $btnGuardar.addClass("disabled");
        $.ajax({
            url: server,
            data: {
                idTienda: viewmodel.IdTienda,
                id: $("#txtId").val(),
                nombre: $("#txtNombre").val(),
                DescripcionBreve: $("#txtDescBreve").val(),
                Descripcion: $("#txtDescripcion").val(),
                Precio: $("#txtPrecio").val(),
                Unidad: $("#txtUnidad").val(),
                Tipo: viewmodel.AdminTienda.TipoOferta,
                IdSucursal: $("#txtIdSucursal").val(),
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
    $btnsEdit.off("click").on("click", function () {
        $("#frmDatos").show();
        var datos = cargarDatosProducto($(this).attr("id").substring(8));
        $('[id^="btnDel"]').removeAttr("disabled");
        var self = $(this);
        self.parent().closest('[id^="btnDel"]').attr("disabled", "disabled");
        $("#txtId").val(datos.Producto.Id).attr("diabled", "disabled");
        $("#txtNombre").val(datos.Producto.Nombre);
        $("#txtUnidad").val(datos.Producto.Unidad);
        $("#txtPrecio").val(datos.Producto.Precio);
        $("#txtDescBreve").val(datos.Producto.DescripcionBreve);
        $("#txtDescripcion").val(datos.Producto.Descripcion);
    });
    $btnsDel.off("click").on("click", function () {
        var $self = $(this);
        var clases = $self.attr("class");
        var url = window.location;
        var server = url.protocol + '//' + url.host + (url.host === "localhost" ? url.port : "") + "/Negocios/invertirOferta";
        $self.addClass("disabled");
        $.ajax({
            url: server,
            data: {
                id: parseInt($self.attr('id').split('_')[1]),
                idTipo: 5
            },
            type: "post",
            dataType: "json",
            async: false
        })
            .done(function (obj) {
                if (obj.response.Servicio.Visible) {
                    $("#btnToggle_" + obj.response.Servicio.Id).removeClass("btn-warning").addClass("btn-success");
                    $("#btnToggle_" + obj.response.Servicio.Id).find('span').removeClass("glyphicon-eye-close").addClass("glyphicon-eye-open");
                } else {
                    $("#btnToggle_" + obj.response.Servicio.Id).removeClass("btn-success").addClass("btn-warning");
                    $("#btnToggle_" + obj.response.Servicio.Id).find('span').removeClass("glyphicon-eye-open").addClass("glyphicon-eye-close");
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
