var opcioneslogin;

var initLogin = function (element, controller, metodo) {
    var $form, $filaUsuario, $filaPassword, $celUsuario, $celPassword, $filaBotones, $celBotones;
    var $addonUsuario, $addonPassword, $txtUsuario, $txtPassword, $btnInicio;
    var $msgUsuario, $msgPassword, $msg;
    if (controller != undefined && metodo != undefined)
        opcioneslogin = { controller: controller, metodo: metodo };

    $form = $('<form id="frmLogin">').addClass("form-group well");

    $form.append('<input type="hidden" id="hidCtrl" value="' + (!controller ? opcioneslogin.controller : controller ) + '">');

    $filaUsuario = $('<div id="divFilaUsuario">').addClass("row").appendTo($form);
    $filaPassword = $('<div id="divFilaPassword">').addClass("row").appendTo($form);
    $filaBotones = $('<div id="divFilaBotones">').addClass("row").appendTo($form);

    $celUsuario = $('<div id="divCelUsuario">').addClass("col-md-12 col-sm-12 input-group").appendTo($filaUsuario);
    $celPassword = $('<div id="divCelPassword">').addClass("col-md-12 col-sm-12 input-group").appendTo($filaPassword);
    $celBotones = $('<div id="divCelBotones">').addClass("col-md-12 col-sm-12 input-group").appendTo($filaBotones);

    $addonUsuario = $('<span class="input-group-addon" id="addonUsuario"><i class="glyphicon glyphicon-user"></i></span>')
        .appendTo($celUsuario);
    $txtUsuario = $('<input type="text" id="txtUsuario" class="form-control" name="txtUsuario" placeholder="Escribe tu usuario" required>')
        .appendTo($celUsuario);
    $msgUsuario = $('<span id="msgLoginUsuario" class="text-danger bg-danger" style="display:none;"></span><br />')
        .appendTo($filaUsuario);

    $addonPassword = $('<span class="input-group-addon" id="addonPassword"><i class="glyphicon glyphicon-lock"></i></span>')
        .appendTo($celPassword);
    $txtPassword = $('<input type="password" id="txtPassword" class="form-control" name="txtPassword" placeholder="Escribe tu contraseña" required>')
        .appendTo($celPassword);
    $msgPassword = $('<span id="msgLoginPassword" class="text-danger bg-danger" style="display:none;"></span><br />')
        .appendTo($filaPassword);

    $btnInicio = $('<a href="#" id="btnLogin">Iniciar sesión</a>').addClass("btn btn-primary").appendTo($celBotones);
    $btnInicio.off().on("click", btnLogin_click);
    $form.append('<span id="spanResultadoLogin">');
    $form.appendTo(element);
}

var btnLogin_click = function () {
    var $form, $txtUsuario, $txtPassword, errores = 0;
    var $msgUsuario, $msgPassword, $msg, $controller;
    $btnInicio = $("#btnLogin");
    $form = $("#frmLogin");
    $txtPassword = $("#txtPassword");
    $txtUsuario = $("#txtUsuario");
    $msgUsuario = $("#msgLoginUsuario");
    $msgPassword = $("#msgLoginPassword");
    $controller = $("#hidCtrl");

    if ($txtUsuario.val().trim() === "") {
        errores++;
        $msgUsuario.text("Falta nombre de usuario");
    }

    if ($txtPassword.val().trim() === "") {
        errores++;
        $msgPassword.text("Falta contraseña");
    }

    if (errores !== 0) {
        $('[id^="msgLogin"]').show().delay(1000).fadeOut();
    } else {
        var clases = $btnInicio.attr("class");
        var url = window.location;
        var server = url.protocol + '//' + url.host + (url.host === "localhost" ? url.port : "") + "/" + opcioneslogin.controller + "/Login";
        $btnInicio.addClass("disabled");
        $.ajax({
            url: server,
            data: {
                usuario: $txtUsuario.val(),
                password: $txtPassword.val(),
                controller: ($controller != undefined) ? $controller.val() : ""
            },
            type: "post",
            dataType: "json",
            async: false
        })
            .done(function (obj) {
                console.log(obj);
                if (!obj.tieneError) {
                    if (opcioneslogin.callback != undefined)
                        opcioneslogin.callback();
                    else {
                        $("#spanResultadoLogin")
                            .empty()
                            .addClass("text-info")
                            .append(obj.msg)
                            .fadeIn()
                            .delay(3500)
                            .fadeOut("slow");
                        $form.delay(5000).hide("slow");
                    }
                } else {
                    $("#spanResultadoLogin")
                        .empty()
                        .addClass("text-error")
                        .append(obj.Mensaje)
                        .fadeIn()
                        .delay(3500)
                        .fadeOut("slow");
                }
            })
            .fail(function (a) {
                console.log(a);
            })
            .always(function (e) {
                $btnInicio.removeClass("disabled");
            });

    }
}