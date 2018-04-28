var initApps = function (element) {
}

var btnLogin_click = function () {
    if (errores !== 0) {
        $('[id^="msgLogin"]').show().delay(1000).fadeOut();
    } else {
        var clases = $btnInicio.attr("class");
        var url = window.location;
        var server = url.protocol + '//' + url.host + (url.host === "localhost" ? url.port : "") + "/Home/GetApps";

        $.ajax({
            url: server,
            data: {

            },
            type: "post",
            dataType: "json"
        })
            .done(function (obj) {
                if (obj.error === "NO") {

                } else {

                }
            })
            .fail(function (a) {
                console.log(a);
            })
            .always(function (e) {

            });

    }
}