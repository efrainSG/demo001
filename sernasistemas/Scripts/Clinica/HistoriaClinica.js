$(document).ready(function () {
    var $btnAgregarAntecedente = $("#btnAgregarAntecedente");
    var $btnAgregarEnfermedad = $("#btnAgregarEnfermedad");
    var $btnAgregarMedicacion = $("#btnAgregarMedicacion");
    var $btnAgregarSistema = $("#btnAgregarSistema");

    var $objAntecedentes = Array(), $objEnfermedades = Array(), $objMedicacion = Array(), $objSistema = Array();

    $btnAgregarAntecedente.off().on("click", function () {
        var $IdFamiliar = $("#AntecedenteHereditario_IdFamiliar"), $Padecimiento = $("#AntecedenteHereditario_Padecimiento");
        var $tblAntecedentes = $("#tblAntecedentes");
        var fila = $("<tr>"), celFamiliar = $("<td>"), celEnfermedad = $("<td>"), celAcciones = $("<td>");

        $objAntecedentes.push({
            IdFamiliar: $IdFamiliar.val(),
            Padecimiento: $Padecimiento.val()
        });

        celEnfermedad.append($Padecimiento.val());
        celFamiliar.append($("#AntecedenteHereditario_IdFamiliar option:selected").text());
        fila.append(celAcciones);
        fila.append(celFamiliar)
        fila.append(celEnfermedad);
        $tblAntecedentes.find("tbody").append(fila);
    });

    $btnAgregarEnfermedad.off().on("click", function () {
        var $FechaInicio = $("#AntecedentePatologico_FechaInicio"), $Enfermedad = $("#AntecedentePatologico_Enfermedad"),
            $IdStatus = $("#AntecedentePatologico_IdStatus");
        var $tblAntecedentes = $("#tblAntecedentesPatologicos");
        var fila = $("<tr>"), celEnfermedad = $("<td>"), celInicio = $("<td>"), celStatus = $("<td>"), celAcciones = $("<td>");

        $objEnfermedades.push({
            Enfermedad: $Enfermedad.val(),
            FechaInicio: $FechaInicio.val(),
            IdStatus: $IdStatus.val()
        });

        celEnfermedad.append($Enfermedad.val());
        celInicio.append($FechaInicio.val());
        celStatus.append($IdStatus.val());
        fila.append(celAcciones);
        fila.append(celEnfermedad)
        fila.append(celInicio);
        fila.append(celStatus);
        $tblAntecedentes.find("tbody").append(fila);
    });

    $btnAgregarMedicacion.off().on("click", function () {
        var $Medicamento = $("#Medicacion_Medicamento"), $Dosis = $("#Medicacion_Dosis"), $Inicio = $("#Medicacion_FechaInicio");
        var $tblMedicacion = $("#tblMedicacion");
        var fila = $("<tr>"), celMedicacion = $("<td>"), celInicio = $("<td>"), celDosis = $("<td>"), celAcciones = $("<td>");

        $objMedicacion.push({
            Medicacion: $Medicamento.val(),
            FechaInicio: $Inicio.val(),
            Dosis: $Dosis.val()
        });

        celMedicacion.append($Medicamento.val());
        celInicio.append($Inicio.val());
        celDosis.append($Dosis.val());
        fila.append(celAcciones);
        fila.append(celMedicacion)
        fila.append(celDosis);
        fila.append(celInicio);
        $tblMedicacion.find("tbody").append(fila);
    });

    $btnAgregarSistema.off().on("click", function () {
        var $Sistema = $("#Sistema_IdSistema"), $Descripcion = $("#Sistema_Descripcion");
        var $tblSistema = $("#tblSistemas");
        var $fila = $("<tr>"), celSistema = $("<td>"), celDescripcion = $("<td>"), celAcciones = $("<td>");

        $objSistema.push({
            IdSistema: $Sistema.val(),
            Descripcion: $Descripcion.val()
        });

        celSistema.append($("#Sistema_IdSistema option:selected").text());
        celDescripcion.append($Descripcion.val());
        $fila.append(celAcciones);
        $fila.append(celSistema);
        $fila.append(celDescripcion);
        $tblSistema.find("tbody").append($fila);
    });

    $('input[type=radio][name="Paciente.IdSexo"]').change(function () {
        if ($(this).val() == 16)
            $("#divGineco").hide();
        if ($(this).val() == 15)
            $("#divGineco").show();
    });

    $("#dpHistoriaClinica_FechaHistoria, #dpPaciente_FechaNacimiento, #dpAntecedentePatologico_FechaInicio, #dpAntecedentesGinecoObstetricios_FUR, #dpAntecedentesGinecoObstetricios_Papanicolaou, #dpAntecedentesGinecoObstetricios_Mastografia, #dpMedicacion_FechaInicio")
        .off()
        .on("change", function () {
            var id = $(this).attr('id').split('dp')[1];
            $("#" + id).val($(this).val());
        });

    $("#chkAntecedentePatologico_IdStatus")
        .off()
        .on("click", function () {
            console.log($(this).val());
        });

    $("#btnGuardarHC").off()
        .on("click", function () {
            debugger;
            var $AntecedentesHereditarios = $("#colecciones");
            var $colecciones = Array();
            $colecciones.push({ Antecedentes: $objAntecedentes });
            $colecciones.push({ Enfermedades: $objEnfermedades });
            $colecciones.push({ Medicacion: $objMedicacion });
            $colecciones.push({ Sistemas: $objSistema });
            $AntecedentesHereditarios.val(JSON.stringify($colecciones));
        })

});