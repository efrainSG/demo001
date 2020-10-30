var puntos = new Array(12);
var $objAntecedentes = Array(),
    $objEnfermedades = Array(),
    $objMedicacion = Array(),
    $objSistema = Array(),
    Escalas = Array(12);

$(document).ready(function () {
    var puntos = new Array(12);
    const $btnAgregarAntecedente = $("#btnAgregarAntecedente");
    const $btnAgregarEnfermedad = $("#btnAgregarEnfermedad");
    const $btnAgregarMedicacion = $("#btnAgregarMedicacion");
    const $btnAgregarSistema = $("#btnAgregarSistema");

    const $value1 = $("#slider1");
    const $value2 = $("#slider2");
    const $value3 = $("#slider3");
    const $value4 = $("#slider4");
    const $value5 = $("#slider5");
    const $value6 = $("#slider6");
    const $value7 = $("#slider7");
    const $value8 = $("#slider8");
    const $value9 = $("#slider9");
    const $value10 = $("#slider10");
    const $value11 = $("#slider11");
    const $value12 = $("#slider12");
    const $value13 = $("#slider13");
    const $value14 = $("#slider14");
    const $value15 = $("#slider15");
    const $value16 = $("#slider16");
    const $value17 = $("#slider17");
    const $value18 = $("#slider18");
    const $value19 = $("#slider19");
    const $value20 = $("#slider20");
    const $value21 = $("#slider21");
    const $value22 = $("#slider22");
    const $value23 = $("#slider23");
    const $value24 = $("#slider24");

    const $valueSpan1 = $(".valueSpan1");
    const $valueSpan2 = $(".valueSpan2");
    const $valueSpan3 = $(".valueSpan3");
    const $valueSpan4 = $(".valueSpan4");
    const $valueSpan5 = $(".valueSpan5");
    const $valueSpan6 = $(".valueSpan6");
    const $valueSpan7 = $(".valueSpan7");
    const $valueSpan8 = $(".valueSpan8");
    const $valueSpan9 = $(".valueSpan9");
    const $valueSpan10 = $(".valueSpan10");
    const $valueSpan11 = $(".valueSpan11");
    const $valueSpan12 = $(".valueSpan12");

    const lienzo = document.getElementById("riodorakuCanvas");
    var contexto = lienzo.getContext("2d");

    for (i = 0; i < 12; i++)
        Escalas[i] = new Array();

    Escalas[0].push(1420);
    Escalas[0].push(1318);
    Escalas[0].push(1258);
    Escalas[0].push(1212);
    Escalas[0].push(1169);
    Escalas[0].push(1128);
    Escalas[0].push(1083);
    Escalas[0].push(1047);
    Escalas[0].push(1002);
    Escalas[0].push(965);
    Escalas[0].push(926);
    Escalas[0].push(890);
    Escalas[0].push(851);
    Escalas[0].push(822);
    Escalas[0].push(785);
    Escalas[0].push(755);
    Escalas[0].push(718);
    Escalas[0].push(685);
    Escalas[0].push(659);
    Escalas[0].push(635);
    Escalas[0].push(606);
    Escalas[0].push(580);
    Escalas[0].push(551);
    Escalas[0].push(529);
    Escalas[0].push(502);
    Escalas[0].push(480);
    Escalas[0].push(458);
    Escalas[0].push(434);
    Escalas[0].push(412);
    Escalas[0].push(387);
    Escalas[0].push(367);
    Escalas[0].push(349);
    Escalas[0].push(325);
    Escalas[0].push(306);
    Escalas[0].push(289);
    Escalas[0].push(266);
    Escalas[0].push(242);
    Escalas[0].push(227);
    Escalas[0].push(212);
    Escalas[0].push(194);
    Escalas[0].push(177);

    Escalas[1].push(1420);
    Escalas[1].push(1305);
    Escalas[1].push(1249);
    Escalas[1].push(1200);
    Escalas[1].push(1152);
    Escalas[1].push(1107);
    Escalas[1].push(1058);
    Escalas[1].push(1010);
    Escalas[1].push(971);
    Escalas[1].push(931);
    Escalas[1].push(893);
    Escalas[1].push(855);
    Escalas[1].push(813);
    Escalas[1].push(773);
    Escalas[1].push(738);
    Escalas[1].push(708);
    Escalas[1].push(678);
    Escalas[1].push(644);
    Escalas[1].push(617);
    Escalas[1].push(585);
    Escalas[1].push(559);
    Escalas[1].push(527);
    Escalas[1].push(504);
    Escalas[1].push(473);
    Escalas[1].push(445);
    Escalas[1].push(423);
    Escalas[1].push(401);
    Escalas[1].push(380);
    Escalas[1].push(359);
    Escalas[1].push(333);
    Escalas[1].push(309);
    Escalas[1].push(289);
    Escalas[1].push(265);
    Escalas[1].push(247);
    Escalas[1].push(229);
    Escalas[1].push(211);
    Escalas[1].push(193);
    Escalas[1].push(175);
    Escalas[1].push(175);
    Escalas[1].push(175);
    Escalas[1].push(175);

    Escalas[2].push(1420);
    Escalas[2].push(1294);
    Escalas[2].push(1235);
    Escalas[2].push(1176);
    Escalas[2].push(1119);
    Escalas[2].push(1069);
    Escalas[2].push(1014);
    Escalas[2].push(963);
    Escalas[2].push(915);
    Escalas[2].push(865);
    Escalas[2].push(819);
    Escalas[2].push(773);
    Escalas[2].push(736);
    Escalas[2].push(697);
    Escalas[2].push(659);
    Escalas[2].push(622);
    Escalas[2].push(585);
    Escalas[2].push(550);
    Escalas[2].push(517);
    Escalas[2].push(486);
    Escalas[2].push(454);
    Escalas[2].push(423);
    Escalas[2].push(396);
    Escalas[2].push(369);
    Escalas[2].push(342);
    Escalas[2].push(314);
    Escalas[2].push(295);
    Escalas[2].push(267);
    Escalas[2].push(245);
    Escalas[2].push(220);
    Escalas[2].push(195);
    Escalas[2].push(170);
    Escalas[2].push(170);
    Escalas[2].push(170);
    Escalas[2].push(170);
    Escalas[2].push(170);
    Escalas[2].push(170);
    Escalas[2].push(170);
    Escalas[2].push(170);
    Escalas[2].push(170);
    Escalas[2].push(170);

    Escalas[3].push(1420);
    Escalas[3].push(1311);
    Escalas[3].push(1252);
    Escalas[3].push(1201);
    Escalas[3].push(1151);
    Escalas[3].push(1110);
    Escalas[3].push(1065);
    Escalas[3].push(1023);
    Escalas[3].push(979);
    Escalas[3].push(935);
    Escalas[3].push(892);
    Escalas[3].push(856);
    Escalas[3].push(818);
    Escalas[3].push(780);
    Escalas[3].push(743);
    Escalas[3].push(714);
    Escalas[3].push(677);
    Escalas[3].push(646);
    Escalas[3].push(618);
    Escalas[3].push(590);
    Escalas[3].push(559);
    Escalas[3].push(530);
    Escalas[3].push(501);
    Escalas[3].push(477);
    Escalas[3].push(453);
    Escalas[3].push(427);
    Escalas[3].push(401);
    Escalas[3].push(379);
    Escalas[3].push(359);
    Escalas[3].push(336);
    Escalas[3].push(311);
    Escalas[3].push(290);
    Escalas[3].push(267);
    Escalas[3].push(247);
    Escalas[3].push(221);
    Escalas[3].push(199);
    Escalas[3].push(177);
    Escalas[3].push(177);
    Escalas[3].push(177);
    Escalas[3].push(177);
    Escalas[3].push(177);

    Escalas[4].push(1420);
    Escalas[4].push(1324);
    Escalas[4].push(1260);
    Escalas[4].push(1224);
    Escalas[4].push(1175);
    Escalas[4].push(1138);
    Escalas[4].push(1094);
    Escalas[4].push(1029);
    Escalas[4].push(1017);
    Escalas[4].push(982);
    Escalas[4].push(944);
    Escalas[4].push(910);
    Escalas[4].push(875);
    Escalas[4].push(840);
    Escalas[4].push(810);
    Escalas[4].push(775);
    Escalas[4].push(744);
    Escalas[4].push(716);
    Escalas[4].push(685);
    Escalas[4].push(657);
    Escalas[4].push(631);
    Escalas[4].push(609);
    Escalas[4].push(585);
    Escalas[4].push(556);
    Escalas[4].push(532);
    Escalas[4].push(510);
    Escalas[4].push(486);
    Escalas[4].push(464);
    Escalas[4].push(442);
    Escalas[4].push(421);
    Escalas[4].push(399);
    Escalas[4].push(377);
    Escalas[4].push(359);
    Escalas[4].push(338);
    Escalas[4].push(318);
    Escalas[4].push(301);
    Escalas[4].push(280);
    Escalas[4].push(266);
    Escalas[4].push(248);
    Escalas[4].push(229);
    Escalas[4].push(213);

    Escalas[5].push(1420);
    Escalas[5].push(1330);
    Escalas[5].push(1266);
    Escalas[5].push(1224);
    Escalas[5].push(1181);
    Escalas[5].push(1142);
    Escalas[5].push(1100);
    Escalas[5].push(1062);
    Escalas[5].push(1027);
    Escalas[5].push(986);
    Escalas[5].push(947);
    Escalas[5].push(910);
    Escalas[5].push(883);
    Escalas[5].push(844);
    Escalas[5].push(812);
    Escalas[5].push(782);
    Escalas[5].push(749);
    Escalas[5].push(721);
    Escalas[5].push(691);
    Escalas[5].push(663);
    Escalas[5].push(635);
    Escalas[5].push(613);
    Escalas[5].push(589);
    Escalas[5].push(561);
    Escalas[5].push(536);
    Escalas[5].push(515);
    Escalas[5].push(492);
    Escalas[5].push(471);
    Escalas[5].push(446);
    Escalas[5].push(424);
    Escalas[5].push(403);
    Escalas[5].push(384);
    Escalas[5].push(361);
    Escalas[5].push(341);
    Escalas[5].push(322);
    Escalas[5].push(303);
    Escalas[5].push(287);
    Escalas[5].push(265);
    Escalas[5].push(248);
    Escalas[5].push(232);
    Escalas[5].push(217);

    Escalas[6].push(1420);
    Escalas[6].push(1302);
    Escalas[6].push(1248);
    Escalas[6].push(1197);
    Escalas[6].push(1139);
    Escalas[6].push(1093);
    Escalas[6].push(1047);
    Escalas[6].push(999);
    Escalas[6].push(952);
    Escalas[6].push(907);
    Escalas[6].push(864);
    Escalas[6].push(824);
    Escalas[6].push(785);
    Escalas[6].push(746);
    Escalas[6].push(715);
    Escalas[6].push(678);
    Escalas[6].push(644);
    Escalas[6].push(613);
    Escalas[6].push(582);
    Escalas[6].push(547);
    Escalas[6].push(519);
    Escalas[6].push(491);
    Escalas[6].push(464);
    Escalas[6].push(437);
    Escalas[6].push(410);
    Escalas[6].push(383);
    Escalas[6].push(360);
    Escalas[6].push(337);
    Escalas[6].push(313);
    Escalas[6].push(289);
    Escalas[6].push(265);
    Escalas[6].push(247);
    Escalas[6].push(222);
    Escalas[6].push(197);
    Escalas[6].push(177);
    Escalas[6].push(177);
    Escalas[6].push(177);
    Escalas[6].push(177);
    Escalas[6].push(177);
    Escalas[6].push(177);
    Escalas[6].push(177);

    Escalas[7].push(1420);
    Escalas[7].push(1293);
    Escalas[7].push(1224);
    Escalas[7].push(1154);
    Escalas[7].push(1087);
    Escalas[7].push(1029);
    Escalas[7].push(970);
    Escalas[7].push(916);
    Escalas[7].push(862);
    Escalas[7].push(809);
    Escalas[7].push(762);
    Escalas[7].push(718);
    Escalas[7].push(670);
    Escalas[7].push(631);
    Escalas[7].push(589);
    Escalas[7].push(549);
    Escalas[7].push(510);
    Escalas[7].push(477);
    Escalas[7].push(443);
    Escalas[7].push(408);
    Escalas[7].push(378);
    Escalas[7].push(345);
    Escalas[7].push(313);
    Escalas[7].push(285);
    Escalas[7].push(255);
    Escalas[7].push(229);
    Escalas[7].push(206);
    Escalas[7].push(183);
    Escalas[7].push(160);
    Escalas[7].push(160);
    Escalas[7].push(160);
    Escalas[7].push(160);
    Escalas[7].push(160);
    Escalas[7].push(160);
    Escalas[7].push(160);
    Escalas[7].push(160);
    Escalas[7].push(160);
    Escalas[7].push(160);
    Escalas[7].push(160);
    Escalas[7].push(160);
    Escalas[7].push(160);

    Escalas[8].push(1420);
    Escalas[8].push(1297);
    Escalas[8].push(1245);
    Escalas[8].push(1190);
    Escalas[8].push(1139);
    Escalas[8].push(1086);
    Escalas[8].push(1036);
    Escalas[8].push(991);
    Escalas[8].push(947);
    Escalas[8].push(903);
    Escalas[8].push(863);
    Escalas[8].push(822);
    Escalas[8].push(784);
    Escalas[8].push(745);
    Escalas[8].push(709);
    Escalas[8].push(677);
    Escalas[8].push(641);
    Escalas[8].push(608);
    Escalas[8].push(576);
    Escalas[8].push(543);
    Escalas[8].push(516);
    Escalas[8].push(490);
    Escalas[8].push(457);
    Escalas[8].push(431);
    Escalas[8].push(405);
    Escalas[8].push(377);
    Escalas[8].push(355);
    Escalas[8].push(330);
    Escalas[8].push(304);
    Escalas[8].push(283);
    Escalas[8].push(261);
    Escalas[8].push(241);
    Escalas[8].push(222);
    Escalas[8].push(204);
    Escalas[8].push(187);
    Escalas[8].push(171);
    Escalas[8].push(171);
    Escalas[8].push(171);
    Escalas[8].push(171);
    Escalas[8].push(171);
    Escalas[8].push(171);

    Escalas[9].push(1420);
    Escalas[9].push(1284);
    Escalas[9].push(1222);
    Escalas[9].push(1168);
    Escalas[9].push(1115);
    Escalas[9].push(1068);
    Escalas[9].push(1014);
    Escalas[9].push(965);
    Escalas[9].push(922);
    Escalas[9].push(880);
    Escalas[9].push(829);
    Escalas[9].push(790);
    Escalas[9].push(748);
    Escalas[9].push(713);
    Escalas[9].push(678);
    Escalas[9].push(642);
    Escalas[9].push(607);
    Escalas[9].push(571);
    Escalas[9].push(543);
    Escalas[9].push(510);
    Escalas[9].push(478);
    Escalas[9].push(451);
    Escalas[9].push(424);
    Escalas[9].push(395);
    Escalas[9].push(370);
    Escalas[9].push(343);
    Escalas[9].push(318);
    Escalas[9].push(293);
    Escalas[9].push(271);
    Escalas[9].push(248);
    Escalas[9].push(223);
    Escalas[9].push(200);
    Escalas[9].push(177);
    Escalas[9].push(177);
    Escalas[9].push(177);
    Escalas[9].push(177);
    Escalas[9].push(177);
    Escalas[9].push(177);
    Escalas[9].push(177);
    Escalas[9].push(177);
    Escalas[9].push(177);

    Escalas[10].push(1420);
    Escalas[10].push(1284);
    Escalas[10].push(1213);
    Escalas[10].push(1151);
    Escalas[10].push(1083);
    Escalas[10].push(1026);
    Escalas[10].push(966);
    Escalas[10].push(913);
    Escalas[10].push(857);
    Escalas[10].push(809);
    Escalas[10].push(759);
    Escalas[10].push(716);
    Escalas[10].push(672);
    Escalas[10].push(630);
    Escalas[10].push(590);
    Escalas[10].push(550);
    Escalas[10].push(512);
    Escalas[10].push(475);
    Escalas[10].push(441);
    Escalas[10].push(409);
    Escalas[10].push(376);
    Escalas[10].push(348);
    Escalas[10].push(316);
    Escalas[10].push(287);
    Escalas[10].push(257);
    Escalas[10].push(234);
    Escalas[10].push(208);
    Escalas[10].push(183);
    Escalas[10].push(160);
    Escalas[10].push(160);
    Escalas[10].push(160);
    Escalas[10].push(160);
    Escalas[10].push(160);
    Escalas[10].push(160);
    Escalas[10].push(160);
    Escalas[10].push(160);
    Escalas[10].push(160);
    Escalas[10].push(160);
    Escalas[10].push(160);
    Escalas[10].push(160);
    Escalas[10].push(160);

    Escalas[11].push(1420);
    Escalas[11].push(1285);
    Escalas[11].push(1223);
    Escalas[11].push(1166);
    Escalas[11].push(1106);
    Escalas[11].push(1054);
    Escalas[11].push(997);
    Escalas[11].push(948);
    Escalas[11].push(897);
    Escalas[11].push(851);
    Escalas[11].push(808);
    Escalas[11].push(762);
    Escalas[11].push(720);
    Escalas[11].push(680);
    Escalas[11].push(641);
    Escalas[11].push(608);
    Escalas[11].push(571);
    Escalas[11].push(536);
    Escalas[11].push(503);
    Escalas[11].push(473);
    Escalas[11].push(439);
    Escalas[11].push(411);
    Escalas[11].push(382);
    Escalas[11].push(350);
    Escalas[11].push(322);
    Escalas[11].push(294);
    Escalas[11].push(270);
    Escalas[11].push(245);
    Escalas[11].push(222);
    Escalas[11].push(199);
    Escalas[11].push(177);
    Escalas[11].push(177);
    Escalas[11].push(177);
    Escalas[11].push(177);
    Escalas[11].push(177);
    Escalas[11].push(177);
    Escalas[11].push(177);
    Escalas[11].push(177);
    Escalas[11].push(177);
    Escalas[11].push(177);
    Escalas[11].push(177);

    $btnAgregarAntecedente.off().on("click", function () {
        var $IdFamiliar = $("#AntecedenteHereditario_IdFamiliar"),
            $Padecimiento = $("#AntecedenteHereditario_Padecimiento");
        var $tblAntecedentes = $("#tblAntecedentes");
        var fila = $("<tr>"),
            celFamiliar = $("<td>"),
            celEnfermedad = $("<td>"),
            celAcciones = $("<td>");

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

        $Padecimiento.val("");
    });

    $btnAgregarEnfermedad.off().on("click", function () {
        var $FechaInicio = $("#AntecedentePatologico_FechaInicio"),
            $Enfermedad = $("#AntecedentePatologico_Enfermedad"),
            $IdStatus = $("#chkAntecedentePatologico_IdStatus");
        var $tblAntecedentes = $("#tblAntecedentesPatologicos");
        var fila = $("<tr>"),
            celEnfermedad = $("<td>"),
            celInicio = $("<td>"),
            celStatus = $("<td>"),
            celAcciones = $("<td>");

        $objEnfermedades.push({
            Enfermedad: $Enfermedad.val(),
            FechaInicio: $FechaInicio.val(),
            IdStatus: $IdStatus.prop('checked') ? 25 : 26
        });

        celEnfermedad.append($Enfermedad.val());
        celInicio.append($FechaInicio.val());
        celStatus.append($IdStatus.prop('checked') ? 'Activo' : 'Inactivo');
        fila.append(celAcciones);
        fila.append(celEnfermedad)
        fila.append(celInicio);
        fila.append(celStatus);
        $tblAntecedentes.find("tbody").append(fila);

        $Enfermedad.val("");
    });

    $btnAgregarMedicacion.off().on("click", function () {
        var $Medicamento = $("#Medicacion_Medicamento"),
            $Dosis = $("#Medicacion_Dosis"),
            $Inicio = $("#Medicacion_FechaInicio");
        var $tblMedicacion = $("#tblMedicacion");
        var fila = $("<tr>"),
            celMedicacion = $("<td>"),
            celInicio = $("<td>"),
            celDosis = $("<td>"),
            celAcciones = $("<td>");

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

        $Medicamento.val("");
        $Dosis.val("");
    });

    $btnAgregarSistema.off().on("click", function () {
        var $Sistema = $("#Sistema_IdSistema"),
            $Descripcion = $("#Sistema_Descripcion");
        var $tblSistema = $("#tblSistemas");
        var $fila = $("<tr>"),
            celSistema = $("<td>"),
            celDescripcion = $("<td>"),
            celAcciones = $("<td>");

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

        $Descripcion.val("");
    });

    $('input[type=radio][name="Paciente.IdSexo"]').change(function () {
        if ($(this).val() == 16)
            $("#divGineco").hide();
        if ($(this).val() == 15)
            $("#divGineco").show();
    });

    $("#dpHistoriaClinica_FechaHistoria, #dpPaciente_FechaNacimiento, #dpAntecedentePatologico_FechaInicio, #dpAntecedentesGinecoObstetricios_FUR, #dpAntecedentesGinecoObstetricios_Papanicolaou, #dpAntecedentesGinecoObstetricios_Mastografia, #dpMedicacion_FechaInicio, #dpAntecedentesGinecoObstetricios_Menarca")
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
            var $AntecedentesHereditarios = $("#colecciones");
            var $colecciones = Array();
            $colecciones.push({ Antecedentes: $objAntecedentes });
            $colecciones.push({ Enfermedades: $objEnfermedades });
            $colecciones.push({ Medicacion: $objMedicacion });
            $colecciones.push({ Sistemas: $objSistema });
            $AntecedentesHereditarios.val(JSON.stringify($colecciones));
        });

    puntos[0] = (parseInt($value1.val()) + parseInt($value2.val())) / 2;
    puntos[1] = (parseInt($value3.val()) + parseInt($value4.val())) / 2;
    puntos[2] = (parseInt($value5.val()) + parseInt($value6.val())) / 2;
    puntos[3] = (parseInt($value7.val()) + parseInt($value8.val())) / 2;
    puntos[4] = (parseInt($value9.val()) + parseInt($value10.val())) / 2;
    puntos[5] = (parseInt($value11.val()) + parseInt($value12.val())) / 2;
    puntos[6] = (parseInt($value13.val()) + parseInt($value14.val())) / 2;
    puntos[7] = (parseInt($value15.val()) + parseInt($value16.val())) / 2;
    puntos[8] = (parseInt($value17.val()) + parseInt($value18.val())) / 2;
    puntos[9] = (parseInt($value19.val()) + parseInt($value20.val())) / 2;
    puntos[10] = (parseInt($value21.val()) + parseInt($value22.val())) / 2;
    puntos[11] = (parseInt($value23.val()) + parseInt($value24.val())) / 2;

    $value1.on('input change', () => {
        puntos[0] = (parseInt($value1.val()) + parseInt($value2.val())) / 2;
        $valueSpan1.html(puntos[0]);
    });
    $value2.on('input change', () => {
        puntos[0] = (parseInt($value1.val()) + parseInt($value2.val())) / 2;
        $valueSpan1.html(puntos[0]);
    });

    $value3.on('input change', () => {
        puntos[1] = (parseInt($value3.val()) + parseInt($value4.val())) / 2;
        $valueSpan2.html(puntos[1]);
    });
    $value4.on('input change', () => {
        puntos[1] = (parseInt($value3.val()) + parseInt($value4.val())) / 2;
        $valueSpan2.html(puntos[1]);
    });

    $value5.on('input change', () => {
        puntos[2] = (parseInt($value5.val()) + parseInt($value6.val())) / 2;
        $valueSpan3.html(puntos[2]);
    });
    $value6.on('input change', () => {
        puntos[2] = (parseInt($value5.val()) + parseInt($value6.val())) / 2;
        $valueSpan3.html(puntos[2]);
    });

    $value7.on('input change', () => {
        puntos[3] = (parseInt($value7.val()) + parseInt($value8.val())) / 2;
        $valueSpan4.html(puntos[3]);
    });
    $value8.on('input change', () => {
        puntos[3] = (parseInt($value7.val()) + parseInt($value8.val())) / 2;
        $valueSpan4.html(puntos[3]);
    });

    $value9.on('input change', () => {
        puntos[4] = (parseInt($value9.val()) + parseInt($value10.val())) / 2;
        $valueSpan5.html(puntos[4]);
    });
    $value10.on('input change', () => {
        puntos[4] = (parseInt($value9.val()) + parseInt($value10.val())) / 2;
        $valueSpan5.html(puntos[4]);
    });

    $value11.on('input change', () => {
        puntos[5] = (parseInt($value11.val()) + parseInt($value12.val())) / 2;
        $valueSpan6.html(puntos[5]);
    });
    $value12.on('input change', () => {
        puntos[5] = (parseInt($value11.val()) + parseInt($value12.val())) / 2;
        $valueSpan6.html(puntos[5]);
    });

    $value13.on('input change', () => {
        puntos[6] = (parseInt($value13.val()) + parseInt($value14.val())) / 2;
        $valueSpan7.html(puntos[6]);
    });
    $value14.on('input change', () => {
        puntos[6] = (parseInt($value13.val()) + parseInt($value14.val())) / 2;
        $valueSpan7.html(puntos[6]);
    });

    $value15.on('input change', () => {
        puntos[7] = (parseInt($value15.val()) + parseInt($value16.val())) / 2;
        $valueSpan8.html(puntos[7]);
    });
    $value16.on('input change', () => {
        puntos[7] = (parseInt($value15.val()) + parseInt($value16.val())) / 2;
        $valueSpan8.html(puntos[7]);
    });

    $value17.on('input change', () => {
        puntos[8] = (parseInt($value17.val()) + parseInt($value18.val())) / 2;
        $valueSpan9.html(puntos[8]);
    });
    $value18.on('input change', () => {
        puntos[8] = (parseInt($value17.val()) + parseInt($value18.val())) / 2;
        $valueSpan9.html(puntos[8]);
    });

    $value19.on('input change', () => {
        puntos[9] = (parseInt($value19.val()) + parseInt($value20.val())) / 2;
        $valueSpan10.html(puntos[9]);
    });
    $value20.on('input change', () => {
        puntos[9] = (parseInt($value19.val()) + parseInt($value20.val())) / 2;
        $valueSpan10.html(puntos[9]);
    });

    $value21.on('input change', () => {
        puntos[10] = (parseInt($value21.val()) + parseInt($value22.val())) / 2;
        $valueSpan11.html(puntos[10]);
    });
    $value22.on('input change', () => {
        puntos[10] = (parseInt($value21.val()) + parseInt($value22.val())) / 2;
        $valueSpan11.html(puntos[10]);
    });

    $value23.on('input change', () => {
        puntos[11] = (parseInt($value23.val()) + parseInt($value24.val())) / 2;
        $valueSpan12.html(puntos[11]);
    });
    $value24.on('input change', () => {
        puntos[11] = (parseInt($value23.val()) + parseInt($value24.val())) / 2;
        $valueSpan12.html(puntos[11]);
    });

    $("#btnGrafica").on("click", function () {
        var x = 0;
        var dx = lienzo.width / 11;
        var escala = 0;
        contexto.clearRect(0, 0, lienzo.width, lienzo.height);
        contexto.fillStyle = "#FFFFFF";
        contexto.fillRect(0, 0, lienzo.width, lienzo.height);
        contexto.stroke();

        contexto.strokeStyle = "#ffeeee";
        for (i = 0; i < 12; i++) {
            contexto.moveTo(x, 0);
            contexto.lineTo(x, 400);
            x += dx;
        }
        contexto.stroke();

        x = 0;

        contexto.strokeStyle = "#000000";
        contexto.beginPath();
        var escala = Escalas[0][parseInt(puntos[0] / 5)];
        contexto.moveTo(x, escala * lienzo.height / 1420);
        for (i = 1; i < 12; i++) {
            x += dx;
            escala = Escalas[i][parseInt(puntos[i] / 5)]
            contexto.lineTo(x, (escala * lienzo.height / 1420));
        }
        x = 0;
        contexto.stroke();

    });

    $("#btnGuardarGrafica").off()
        .on("click", function () {
            var $AntecedentesHereditarios = $("#colecciones");
            var $colecciones = Array();
            $colecciones.push({ Antecedentes: $objAntecedentes });
            $colecciones.push({ Enfermedades: $objEnfermedades });
            $colecciones.push({ Medicacion: $objMedicacion });
            $colecciones.push({ Sistemas: $objSistema });
            $AntecedentesHereditarios.val(JSON.stringify($colecciones));
        });

    $.each($("[id*='_Fecha']"), function (n, i) {
        var partes = $(i).val().split(' ')[0].split('/');
        var id = $(i).attr('id');
        try {
            var fecha = new Date(partes[2] + '-' + partes[1] + '-' + partes[0]).toISOString().split('T')[0];
            $("#dp" + id).val(fecha);
        } catch (e) {
        }
    });

    var $sexo = $('input[type = radio][name = "Paciente.IdSexo"]:checked');
    $sexo.change();

    var partes = $("#AntecedentesGinecoObstetricios_Menarca").val().split(' ')[0].split('/');
    var fecha = new Date(partes[1] + '-' + partes[0] + '-' + partes[2]).toISOString().split('T')[0];
    $("#dpAntecedentesGinecoObstetricios_Menarca").val(fecha);

    partes = $("#AntecedentesGinecoObstetricios_FUR").val().split(' ')[0].split('/');
    fecha = new Date(partes[1] + '-' + partes[0] + '-' + partes[2]).toISOString().split('T')[0];
    $("#dpAntecedentesGinecoObstetricios_FUR").val(fecha);

    partes = $("#AntecedentesGinecoObstetricios_Papanicolaou").val().split(' ')[0].split('/');
    fecha = new Date(partes[1] + '-' + partes[0] + '-' + partes[2]).toISOString().split('T')[0];
    $("#dpAntecedentesGinecoObstetricios_Papanicolaou").val(fecha);

    partes = $("#AntecedentesGinecoObstetricios_Mastografia").val().split(' ')[0].split('/');
    fecha = new Date(partes[1] + '-' + partes[0] + '-' + partes[2]).toISOString().split('T')[0];
    $("#dpAntecedentesGinecoObstetricios_Mastografia").val(fecha);

});