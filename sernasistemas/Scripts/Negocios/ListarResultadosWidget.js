var initListarResultados = function (element, resultados) {
    var $tabla, $fila, $celdaid, $celdanombre, $celdadireccion, $celdatelefono;
    debugger;
    $tabla = $('<table>')
        .addClass("table table-condensed table-hover")
        .attr("id", "tablaResultados");

    $(resultados).each(function (ndx) {
        debugger;
        $celdaid = $('<td>').attr("id", "celdaResultadoId_" + ndx).append($(this)[0].id);
        $celdanombre = $('<td>').attr("id", "celdaResultadoNombre_" + ndx)
            .append('<a href="./Negocios/verNegocio/' + $(this)[0].id + '" target="_blank">' + $(this)[0].nombre + '</a>');
        $celdadireccion = $('<td>').attr("id", "celdaResultadoDireccion_" + ndx).append($(this)[0].direccion);
        $celdatelefono = $('<td>').attr("id", "celdaResultadoTelefono_" + ndx).append($(this)[0].telefono);
        $fila = $('<tr>')
            .append($celdaid)
            .append($celdanombre)
            .append($celdadireccion)
            .append($celdatelefono);
        $tabla.append($fila);
    });
    console.log($tabla);
    element.append($tabla);
};

var loadResultados = function (resultados) {
    console.log(resultados);
};