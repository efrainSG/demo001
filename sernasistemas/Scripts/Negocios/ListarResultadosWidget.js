var initListarResultados = function (element, resultados) {
    var $tabla, $fila, $celdaid, $celdanombre, $celdadireccion, $celdatelefono;
    $tabla = $('<table>')
        .addClass("table table-condensed table-hover")
        .attr("id", "tablaResultados");

    if ($(resultados).length > 0) {
        $(resultados).each(function (ndx) {
            
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
    } else {
        element.append($('<span class="text-warning">Lo siento, no tengo negocios que coincidan con lo que buscas. Prueba con otros datos.</span>'));
    }
};

var loadResultados = function (resultados) {
    console.log(resultados);
};