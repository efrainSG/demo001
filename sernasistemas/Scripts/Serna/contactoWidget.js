var initContacto = function (element) {
    var $form, $filaNombre, $filaTelefono, $filaCorreo, $filaComentario, $filaBoton;
    var $txtNombre, $txtTelefono, $txtCorreo, $txtComentario, $btnEnviar;
    var $addonNombre, $addonTelefono, $addonCorreo, $addonComentario;
    var $msgNombre, $msgTelefono, $msgCorreo, $msgComentario;
    var $celNombre, $celTelefono, $celCorreo, $celComentario, $celBoton;

    $form = $('<form id="frmContacto" class="form-group well">')
        .append('<h4 class="text-primary">Ponte en contacto conmigo</h4>')
        .append('<span id="spanResultado" style="display:none;"></span>');
    $txtNombre = $('<input type="text" id="txtNombre" class="form-control" name="txtNombre" placeholder="Escribe tu nombre" required>');
    $txtTelefono = $('<input type="text" id="txtTelefono" class="form-control" name="txtTelefono" placeholder="Escribe tu teléfono o celular" required>');
    $txtCorreo = $('<input type="mail" id="txtCorreo" class="form-control" name="txtCorreo" placeholder="Escribe tu dirección de correo" required>');
    $txtComentario = $('<textarea id="txtComentario" class="form-control" name="txtComentario" placeholder="describe en qué te puedo ayudar" rows="3" required>');
    $msgNombre = $('<span id="msgNombre" class="text-danger bg-danger" style="display:none;">Necesito saber tu nombre</span><br />');
    $msgCorreo = $('<span id="msgCorreo" class="text-danger bg-danger" style="display:none;">Necesito tu correo para contactarte</span><br />');
    $msgComentario = $('<span id="msgComentario" class="text-danger bg-danger" style="display:none;">Te faltó decirme en qué puedo ayudarte</span><br />');
    $msgTelefono = $('<span id="msgTelefono" class="text-info bg-info" style="display:none;">Es recomendable que me des un número para localizarte</span><br />');
    $btnEnviar = $('<a href="#" id="btnEnviarComentario" class="btn btn-lg btn-primary">Enviar</a>')
        .off()
        .on("click", enviarComentario_click);

    $addonNombre = $('<span class="input-group-addon" id="addonNombre"><i class="glyphicon glyphicon-user"></i></span>');
    $addonTelefono = $('<span class="input-group-addon" id="addonTelefono"><i class="glyphicon glyphicon-phone-alt"></i></span>');
    $addonCorreo = $('<span class="input-group-addon" id="addonCorreo"><i class="glyphicon glyphicon-envelope"></i></span>');
    $addonComentario = $('<span class="input-group-addon" id="addonComentario"><i class="glyphicon glyphicon-comment"></i></span>');

    $celNombre = $('<div class="col-md-12 input-group">')
        .append($addonNombre)
        .append($txtNombre)
        .append($msgNombre);
    $celTelefono = $('<div class="col-md-12 input-group">')
        .append($addonTelefono)
        .append($txtTelefono)
        .append($msgTelefono);
    $celComentario = $('<div class="col-md-12 input-group">')
        .append($addonComentario)
        .append($txtComentario)
        .append($msgComentario);
    $celCorreo = $('<div class="col-md-12 input-group">')
        .append($addonCorreo)
        .append($txtCorreo)
        .append($msgCorreo);
    $celBoton = $('<div class="col-md-12">')
        .append($btnEnviar);

    $filaNombre = $('<div class="row">')
        .append($celNombre);
    $filaTelefono = $('<div class="row">')
        .append($celTelefono);
    $filaCorreo = $('<div class="row">')
        .append($celCorreo);
    $filaComentario = $('<div class="row">')
        .append($celComentario);
    $filaBoton = $('<div class="row">')
        .append($celBoton);

    $form
        .append($filaNombre)
        .append($filaTelefono)
        .append($filaCorreo)
        .append($filaComentario)
        .append($filaBoton);
    element
        .append($form);
};

var enviarComentario_click = function () {
    var $form = $("#frmContacto"),
        errores = 0;
    var $txtNombre = $("#txtNombre"),
        $txtTelefono = $("#txtTelefono"),
        $txtCorreo = $("#txtCorreo"),
        $txtComentario = $("#txtComentario"),
        $btnEnviar = $("#btnEnviar");

    if ($txtNombre.val().trim() === "") {
        $msgNombre.show();
        errores++;
    }
    if ($txtCorreo.val().trim() === "") {
        $msgCorreo.show();
        errores++;
    }
    if ($txtComentario.val().trim() === "") {
        $msgComentario.show();
        errores++;
    }
    if (errores !== 0) {
        if ($txtTelefono.val().trim() === "") {
            $msgTelefono.show();
        }
        $('[id^="msg"]').delay(1000).fadeOut();
    } else {
        var clases = $btnEnviar.attr("class");
        var url = window.location;
        var server = url.protocol + '//' + url.host + (url.host === "localhost" ? url.port : "") + "/Home/SendContacto";
        $btnEnviar.addClass("disabled");
        $.ajax({
            url: server,
            data: {
                nombre: $txtNombre.val(),
                telefono: $txtTelefono.val(),
                correo: $txtCorreo.val(),
                comentario: $txtComentario.val()
            },
            type: "post",
            dataType: "json"
        })
            .done(function (obj) {

                $("#spanResultado")
                    .empty()
                    .addClass(
                    (obj.error === "NO") ? "text-info" : "text-error"
                    )
                    .append(obj.msg)
                    .fadeIn()
                    .delay(3500)
                    .fadeOut("slow");
            })
            .fail(function (a) {
                console.log(a);
            })
            .always(function (e) {
                $btnEnviar.removeClass("disabled");
            });
    }
};