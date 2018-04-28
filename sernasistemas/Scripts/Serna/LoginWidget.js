var initLogin = function (element) {
    var $form, $filaUsuario, $filaPassword, $celUsuario, $celPassword, $filaBotones, $celBotones;
    var $addonUsuario, $addonPassword, $txtUsuario, $txtPassword, $btnInicio;
    var $msgUsuario, $msgPassword, $msg;

    $form = $('<form id="frmLogin">').addClass("form-group well");

    $filaUsuario = $('<div id="divFilaUsuario">').addClass("row").appendTo($form);
    $filaPassword = $('<div id="divFilaPassword">').addClass("row").appendTo($form);
    $filaBotones = $('<div id="divFilaBotones">').addClass("row").appendTo($form);

    $celUsuario = $('<div id="divCelUsuario">').addClass("col-md-12 input-group").appendTo($filaUsuario);
    $celPassword = $('<div id="divCelPassword">').addClass("col-md-12 input-group").appendTo($filaPassword);
    $celBotones = $('<div id="divCelBotones">').addClass("col-md-12 input-group").appendTo($filaBotones);

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
    $btnInicio.off().on("click",btnLogin_click);
    $form.appendTo(element);
}

var btnLogin_click = function () {
    var $form, $txtUsuario, $txtPassword, errores = 0;
    var $msgUsuario, $msgPassword, $msg;
    $btnInicio = $("#btnLogin");
    $form = $("#frmLogin");
    $txtPassword = $("#txtPassword");
    $txtUsuario = $("#txtUsuario");
    $msgUsuario = $("#msgLoginUsuario");
    $msgPassword = $("#msgLoginPassword");

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
        var server = url.protocol + '//' + url.host + (url.host === "localhost" ? url.port : "") + "/Home/Login";
        $btnInicio.addClass("disabled");
        $.ajax({
            url: server,
            data: {
                nombre: $txtUsuario.val(),
                password: $txtPassword.val()
            },
            type: "post",
            dataType: "json"
        })
            .done(function (obj) {
                if (obj.error === "NO") {
                    $("#spanResultado")
                        .empty()
                        .addClass("text-info")
                            .append(obj.msg)
                            .fadeIn()
                            .delay(3500)
                            .fadeOut("slow");
                    $form.delay(5000).hide("slow");
                    viewmodel.attr("token", obj.token);
                    console.log(viewmodel);
                } else {
                    $("#spanResultado")
                        .empty()
                        .addClass("text-error")
                            .append(obj.msg)
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