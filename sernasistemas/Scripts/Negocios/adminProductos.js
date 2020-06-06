var initAdminProductos = function (element, datos) {
    var $form = $('<div class="well well-sm form" id="frmDatos" style="display:none;">'),

        $navegador = $('<ul class="nav nav-tabs">'),
        $tab1 = $('<li class="active" > <a data-toggle="tab" href="#menu1">Datos generales</a></li >'),
        $tab2 = $('<li><a data-toggle="tab" href="#menu2">Datos adicionales</a></li>');

    var $contenedor = $('<div class="tab-content">'),
        $panel1 = $('<div id="menu1" class="tab-pane fade in active">'),
        $panel2 = $('<div id="menu2" class="tab-pane">');

    var $hIdOS = $('<input type="hidden" id="IdOS">'),
        $txtId = $('<input type="hidden" id="txtId" placeholder="Id" class="form-control">'),
        $txtNombre = $('<input type="text" id="txtNombre" placeholder="Nombre" class="form-control">'),
        $txtDescBreve = $('<input type="text" id="txtDescBreve" placeholder="Descripción breve" class="form-control">'),
        $txtDescripcion = $('<input type="text" id="txtDescripcion" placeholder="Descripción completa" class="form-control">'),
        $txtPrecio = $('<input type="number" id="txtPrecio" placeholder="Precio" class="form-control">'),
        $txtUnidad = $('<input type="text" id="txtUnidad" placeholder="Unidad" class="form-control">'),
        $txtIdSucursal = $('<select id="selIdSucursal" placeholder="Id de sucursal" class="form-control">'),

        $btnGuardar = $('<a href="#" class="btn btn-sm btn-lg btn-primary" id="btnGuardar2"><span class="glyphicon glyphicon-save"></span>Guardar</a>'),
        $contenidoPanel1 = $('<div class="well well-sm">'),
        $fila1 = $('<div class="row">'),
        $fila2 = $('<div class="row">'),
        $fila3 = $('<div class="row">'),
        $fila4 = $('<div class="row">'),
        $fila5 = $('<div class="row">'),
        $fila6 = $('<div class="row">'),

        $col01 = $('<div class="col-sm-3">').append("Nombre:"),
        $col02 = $('<div class="col-sm-8">').append($txtNombre),
        $col03 = $('<div class="col-sm-3">').append("Descripción breve:"),
        $col04 = $('<div class="col-sm-8">').append($txtDescBreve),
        $col05 = $('<div class="col-sm-3">').append("Descripción completa:"),
        $col06 = $('<div class="col-sm-8">').append($txtDescripcion),
        $col07 = $('<div class="col-sm-3">').append("Precio:"),
        $col08 = $('<div class="col-sm-3">').append($txtPrecio),
        $col09 = $('<div class="col-sm-2">').append("Unidad:"),
        $col0A = $('<div class="col-sm-3">').append($txtUnidad),
        $col0B = $('<div class="col-sm-3">').append("Sucursal:"),
        $col0C = $('<div class="col-sm-8">').append($txtIdSucursal),
        $col0D = $('<div class="col-sm-3">').append($btnGuardar);

    $contenidoPanel1.append($fila1).append($fila2).append($fila3).append($fila4).append($fila5).append($fila6);
    $fila1.append($col01).append($col02);
    $fila2.append($col03).append($col04);
    $fila3.append($col05).append($col06);
    $fila4.append($col07).append($col08).append($col09).append($col0A);
    $fila5.append($col0B).append($col0C);
    $fila6.append($col0D);

    //var $contenidoPanel2 = $('<div class="well well-sm">'),
    //    $col0C = $('<div class="col-sm-3">'),
    //    $col0D = $('<div class="col-sm-3">'),
    //    $fila6 = $('<div class="row">'),
    //    $col0E = $('<div class="col-sm-3">');
    //$contenidoPanel2.append($fila5).append($fila6);
    //$fila5.append($col0A).append($col0B.append($txtIdSucursal).append($hIdOS));

    //var $contenidoPanel3 = $('<div class="well well-sm">'),
    //    $fila7 = $('<div class="row">'),
    //    $col0F = $('<div class="col-sm-4">'),
    //    $txtIdFoto = $('<input type="number" id="txtIdFoto" placeholder="Id de foto" class="form-control">'),
    //    $col10 = $('<div class="col-sm-4">'),
    //    $txtOrden = $('<input type="number" id="txtOrden" placeholder="Orden de fotos" class="form-control">'),
    //    $col11 = $('<div class="col-sm-4">'),
    //    $btnCargar = $('<a href="#" class="btn btn-sm btn-lg btn-primary" id="btnCargar"><span class="glyphicon glyphicon-upload"></span>Cargar</a>');
    //$contenidoPanel3.append($fila7);
    //$fila7.append($col0F.append($txtIdFoto)).append($col10.append($txtOrden)).append($col11.append($btnCargar));

    $panel1.append($contenidoPanel1);
    //$panel2.append($contenidoPanel2);
    $form.append($hIdOS).append($txtId).append($navegador).append($contenedor);
    $navegador.append($tab1);//.append($tab2);
    $contenedor.append($panel1);//.append($panel2);

    var sucursales = cargarSucursales(viewmodel.IdTienda);
    if (!sucursales.tieneError) {
        $txtIdSucursal.append('<option value="0" selected>- Elige una sucursal -</option>');
        $.each(sucursales.Sucursales, function (s) {
            $txtIdSucursal.append('<option value="' + this.Id + '">' + this.Tipo + ': ' + this.Direccion + '</option>');
        });
    }

    cargarProductos(datos, element.append('<h2 class="well">Administrar Productos</h2>').append($form));
    eventosAdminProductos();
};

var cargarSucursales = function (id) {
    var url = window.location;
    var datos;
    var server = url.protocol + '//' + url.host +
        (url.host === "localhost" ? url.port : "") + "/Negocios/listarSucursales";
    $.ajax({
        async: false,
        dataType: "json",
        url: server,
        type: "post",
        data: {
            IdTienda: id
        }
    })
        .done(function (obj) {
            datos = obj;
        })
        .fail(function (obj) {
            console.log(obj);
        }).always(function (obj) {
        });
    return datos;
}
var cargarProductos = function (datos, contenedor) {
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
            Tipo: 1
        }
    })
        .done(function (obj) {
            $.each(obj.Productos, function (item) {
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

var cargarDatosProducto = function (id) {
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
            Tipo: 1
        }
    })
        .done(function (obj) {
            datos = obj;
        })
        .fail(function (obj) {
            console.log(a);
        }).always(function (obj) {
        });
    return datos;
}

var prodServhelper = function (datos) {
    var $fila, $celId, $celNombre, $celResumen, $celPrecio, $celAcciones;
    var $btnEdit, $btnDel, $btnDelGlyph;
    debugger;
    $fila = $('<div class="row">');
    $celId = $('<div class="col-sm-1 col-md-1" id="celId_' + datos.Id + '">');
    $celNombre = $('<div class="col-sm-2 col-md-2" id="celNombre_' + datos.Id + '">');
    $celResumen = $('<div class="col-sm-5 col-md-5" id="celResumen_' + datos.Id + '">');
    $celPrecio = $('<div class="col-sm-2 col-md-2" id="celPrecio_' + datos.Id + '">');
    $celAcciones = $('<div class="col-sm-2 col-md-2 btn-group btn-group-sm" id="celAcciones_' + datos.Id + '">');
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
        .append($celId.append(datos.Id))
        .append($celNombre.append(datos.Nombre))
        .append($celResumen.append(datos.Resumen))
        .append($celPrecio.append(datos.Precio))
        .append($celAcciones);

    return $fila;
};

var eventosAdminProductos = function () {
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
                Precio: $("#txtPrecio").val() || 0,
                Unidad: $("#txtUnidad").val(),
                Tipo: viewmodel.AdminTienda.TipoOferta,
                IdSucursal: $("#selIdSucursal").val() || 0,
                IdOS: $("#hidOS").val() || 0
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
        $("#selIdSucursal").val(datos.Producto.IdSucursal);
        $("#hIdOS").val(datos.Producto.IdOS);
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
                idTipo: 4
            },
            type: "post",
            dataType: "json",
            async: false
        })
            .done(function (obj) {
                if (obj.response.Producto.Visible) {
                    $("#btnToggle_" + obj.response.Producto.Id).removeClass("btn-warning").addClass("btn-success");
                    $("#btnToggle_" + obj.response.Producto.Id).find('span').removeClass("glyphicon-eye-close").addClass("glyphicon-eye-open");
                } else {
                    $("#btnToggle_" + obj.response.Producto.Id).removeClass("btn-success").addClass("btn-warning");
                    $("#btnToggle_" + obj.response.Producto.Id).find('span').removeClass("glyphicon-eye-open").addClass("glyphicon-eye-close");
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
