var ListarResultadosPropiedades = { inicio: 0, fin: 0, total: 0, desplazamiento: 10 };
var initListarResultados = function (element, resultados) {
    var $tabla, $fila, $celdaid, $celdanombre, $celdadireccion, $celdatelefono;
    $tabla = $('<div>')
        .addClass("col-ms-12 col-md-12")
        .attr("id", "tablaResultados");
    ListarResultadosPropiedades.total = $(resultados).length;
    if (ListarResultadosPropiedades.total > 0) {
        element.append($("<div>").addClass("row well well-sm").append($tabla));
        $(resultados).each(function (ndx) {
            $celdaid = $('<div>')
                .attr("id", "celdaResultadoId_" + ndx)
                .addClass("col-sm-2 col-md-2")
                .append('<a href="./Negocios/verNegocio/' + $(this)[0].id + '" target="_blank" class="btn btn-sm btn-primary">Visitar</a>');
            $celdanombre = $('<div>')
                .attr("id", "celdaResultadoNombre_" + ndx)
                .addClass("col-sm-4 col-md-4")
                .append($(this)[0].nombre);
            $celdadireccion = $('<div>')
                .attr("id", "celdaResultadoDireccion_" + ndx)
                .addClass("col-sm-4 col-md-4")
                .append($(this)[0].direccion);
            $celdatelefono = $('<div>')
                .attr("id", "celdaResultadoTelefono_" + ndx)
                .addClass("col-sm-2 col-md-2")
                .append($(this)[0].telefono);
            $fila = $('<div id="filaResultado_' + ndx + '" >')
                .addClass("row")
                .append($celdaid)
                .append($celdanombre)
                .append($celdadireccion)
                .append($celdatelefono);
            if (ndx >= ListarResultadosPropiedades.desplazamiento) {
                $fila.hide();
            }
            $tabla.append($fila);
        });
        ListarResultadosPropiedades.fin = ListarResultadosPropiedades.inicio + ListarResultadosPropiedades.desplazamiento - 1;
        element.append(loadNavegador(ListarResultadosPropiedades.total >= ListarResultadosPropiedades.desplazamiento));
    } else {
        element.append($('<span class="text-warning">Lo siento, no tengo negocios que coincidan con lo que buscas. Prueba con otros datos.</span>'));
    }
};

var loadNavegador = function (mostrar) {
    var $btnPrimero, $btnAnterior, $btnSiguiente, $btnUltimo, $botonera;
    if (mostrar) {
        $botonera = $.find("#botonera");
        $btnPrimero = $.find("#btnPrimero");
        $btnAnterior = $.find("#btnAnterior");
        $btnSiguiente = $.find("#btnSiguiente");
        $btnUltimo = $.find("#btnUltimo");
        if ($btnPrimero.length == 0)
            $btnPrimero = $('<a href="#" id="btnPrimero">')
                .addClass("btn btn-primary")
                .append($('<span class="glyphicon glyphicon-fast-backward">'))
                .off().on("click", function () {
                    console.log("PRIMERO");
                    $("[id^='filaResultado_']").hide();
                    ListarResultadosPropiedades.inicio = 0;
                    ListarResultadosPropiedades.fin = ListarResultadosPropiedades.inicio + ListarResultadosPropiedades.desplazamiento;
                    console.log(ListarResultadosPropiedades);
                    for (i = ListarResultadosPropiedades.inicio; i < ListarResultadosPropiedades.fin; i++) {
                        var item = $.find("#filaResultado_" + i)[0];
                        if (item != undefined)
                            $(item).show();
                    }
                });
        if ($btnAnterior.length == 0)
            $btnAnterior = $('<a href="#" id="btnAnterior">')
                .addClass("btn btn-primary")
                .append($('<span class="glyphicon glyphicon-backward">'))
                .off().on("click", function () {
                    console.log("ANTERIOR");
                    $("[id^='filaResultado_']").hide();
                    ListarResultadosPropiedades.inicio -= ListarResultadosPropiedades.desplazamiento;
                    if (ListarResultadosPropiedades.inicio < 0)
                        ListarResultadosPropiedades.inicio = 0;
                    ListarResultadosPropiedades.fin = ListarResultadosPropiedades.inicio + ListarResultadosPropiedades.desplazamiento;
                    console.log(ListarResultadosPropiedades);
                    for (i = ListarResultadosPropiedades.inicio; i < ListarResultadosPropiedades.fin; i++) {
                        var item = $.find("#filaResultado_" + i)[0];
                        if (item != undefined)
                            $(item).show();
                    }
                });
        if ($btnSiguiente.length == 0)
            $btnSiguiente = $('<a href="#" id="btnSiguiente">')
                .addClass("btn btn-primary")
                .append($('<span class="glyphicon glyphicon-forward">'))
                .off().on("click", function () {
                    console.log("SIGUIENTE");
                    $("[id^='filaResultado_']").hide();
                    ListarResultadosPropiedades.inicio += ListarResultadosPropiedades.desplazamiento;
                    ListarResultadosPropiedades.fin = ListarResultadosPropiedades.inicio + ListarResultadosPropiedades.desplazamiento;
                    console.log(ListarResultadosPropiedades);
                    for (i = ListarResultadosPropiedades.inicio; i < ListarResultadosPropiedades.fin; i++) {
                        var item = $.find("#filaResultado_" + i)[0];
                        if (item != undefined)
                            $(item).show();
                    }
                });
        if ($btnUltimo.length == 0)
            $btnUltimo = $('<a href="#" id="btnUltimo">')
                .addClass("btn btn-primary")
                .append($('<span class="glyphicon glyphicon-fast-forward">'))
                .off().on("click", function () {
                    console.log("ULTIMO");
                    $("[id^='filaResultado_']").hide();
                    ListarResultadosPropiedades.inicio = ListarResultadosPropiedades.total - ListarResultadosPropiedades.desplazamiento;
                    ListarResultadosPropiedades.fin = ListarResultadosPropiedades.inicio + ListarResultadosPropiedades.desplazamiento;
                    console.log(ListarResultadosPropiedades);
                    for (i = ListarResultadosPropiedades.inicio; i < ListarResultadosPropiedades.fin; i++) {
                        var item = $.find("#filaResultado_" + i)[0];
                        if (item != undefined)
                            $(item).show();
                    }
                });
        if ($botonera.length == 0)
            $botonera = $('<div id="botonera">')
                .addClass("btn-group")
                .append($btnPrimero)
                .append($btnAnterior)
                .append($btnSiguiente)
                .append($btnUltimo);

    }
    return $botonera;
}

var loadResultados = function (resultados) {
    console.log(resultados);
};