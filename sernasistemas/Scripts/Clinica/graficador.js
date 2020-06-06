var respSlide = function (ui, am0, am1, avg0) {
    am0.val(ui.value);
    var i = parseInt(amo0.val()) + parseInt(am1.val());
    avg0.val(~~(i / 2));
};

var respoSlider = function (Slider, Orientation, Range, Min, Max, Value, amount1, amount2, Avg) {
    $(Slider).slider({
        orientation: Orientation,
        range: Range,
        min: Min,
        max: Max,
        value: Value,
        slide: function (event, ui) {
            respSlide(ui, $(amount1), $(amount2), $(Avg));
        }
    });
};

var initGraf = function () {
    respoSlider("#sliderVertical00", "vertical", "min", 0, 190, 50, "#amount00", "#amount01", "#avg0");
    respoSlider("#sliderVertical01", "vertical", "min", 0, 190, 50, "#amount01", "#amount00", "#avg0");

    respoSlider("#sliderVertical02", "vertical", "min", 0, 170, 50, "#amount02", "#amount03", "#avg1");
    respoSlider("#sliderVertical03", "vertical", "min", 0, 170, 50, "#amount03", "#amount02", "#avg1");

    respoSlider("#sliderVertical04", "vertical", "min", 0, 140, 50, "#amount04", "#amount05", "#avg2");
    respoSlider("#sliderVertical05", "vertical", "min", 0, 140, 50, "#amount05", "#amount04", "#avg2");

    respoSlider("#sliderVertical06", "vertical", "min", 0, 170, 50, "#amount06", "#amount07", "#avg3");
    respoSlider("#sliderVertical07", "vertical", "min", 0, 170, 50, "#amount07", "#amount06", "#avg3");

    respoSlider("#sliderVertical08", "vertical", "min", 0, 200, 50, "#amount08", "#amount09", "#avg4");
    respoSlider("#sliderVertical09", "vertical", "min", 0, 200, 50, "#amount09", "#amount08", "#avg4");

    respoSlider("#sliderVertical0A", "vertical", "min", 0, 200, 50, "#amount0A", "#amount0B", "#avg5");
    respoSlider("#sliderVertical0B", "vertical", "min", 0, 200, 50, "#amount0B", "#amount0A", "#avg5");

    respoSlider("#sliderVertical0C", "vertical", "min", 0, 160, 50, "#amount0C", "#amount0D", "#avg6");
    respoSlider("#sliderVertical0D", "vertical", "min", 0, 160, 50, "#amount0D", "#amount0C", "#avg6");

    respoSlider("#sliderVertical0E", "vertical", "min", 0, 130, 50, "#amount0E", "#amount0F", "#avg7");
    respoSlider("#sliderVertical0F", "vertical", "min", 0, 130, 50, "#amount0F", "#amount0E", "#avg7");

    respoSlider("#sliderVertical10", "vertical", "min", 0, 160, 50, "#amount10", "#amount11", "#avg8");
    respoSlider("#sliderVertical11", "vertical", "min", 0, 160, 50, "#amount11", "#amount10", "#avg8");

    respoSlider("#sliderVertical12", "vertical", "min", 0, 150, 50, "#amount12", "#amount13", "#avg9");
    respoSlider("#sliderVertical13", "vertical", "min", 0, 150, 50, "#amount13", "#amount12", "#avg9");

    respoSlider("#sliderVertical14", "vertical", "min", 0, 150, 50, "#amount14", "#amount15", "#avgA");
    respoSlider("#sliderVertical15", "vertical", "min", 0, 150, 50, "#amount15", "#amount14", "#avgA");

    respoSlider("#sliderVertical16", "vertical", "min", 0, 150, 50, "#amount16", "#amount17", "#avgB");
    respoSlider("#sliderVertical17", "vertical", "min", 0, 150, 50, "#amount17", "#amount16", "#avgB");

    $("#amount00").val($("#slideVertical00").slider("value"));
    $("#amount01").val($("#slideVertical01").slider("value"));
    $("#amount02").val($("#slideVertical02").slider("value"));
    $("#amount03").val($("#slideVertical03").slider("value"));
    $("#amount04").val($("#slideVertical04").slider("value"));
    $("#amount05").val($("#slideVertical05").slider("value"));
    $("#amount06").val($("#slideVertical06").slider("value"));
    $("#amount07").val($("#slideVertical07").slider("value"));
    $("#amount08").val($("#slideVertical08").slider("value"));
    $("#amount09").val($("#slideVertical09").slider("value"));
    $("#amount0A").val($("#slideVertical0A").slider("value"));
    $("#amount0B").val($("#slideVertical0B").slider("value"));
    $("#amount0C").val($("#slideVertical0C").slider("value"));
    $("#amount0D").val($("#slideVertical0D").slider("value"));
    $("#amount0E").val($("#slideVertical0E").slider("value"));
    $("#amount0F").val($("#slideVertical0F").slider("value"));
    $("#amount10").val($("#slideVertical10").slider("value"));
    $("#amount11").val($("#slideVertical11").slider("value"));
    $("#amount12").val($("#slideVertical12").slider("value"));
    $("#amount13").val($("#slideVertical13").slider("value"));
    $("#amount14").val($("#slideVertical14").slider("value"));
    $("#amount15").val($("#slideVertical15").slider("value"));
    $("#amount16").val($("#slideVertical16").slider("value"));
    $("#amount17").val($("#slideVertical17").slider("value"));

    var i = parseInt($("#amount00").val()) + parseInt($("#amount01").val());
    $("#avg0").val(~~(i / 2));
    i = parseInt($("#amount02").val()) + parseInt($("#amount03").val());
    $("#avg1").val(~~(i / 2));
    i = parseInt($("#amount04").val()) + parseInt($("#amount05").val());
    $("#avg2").val(~~(i / 2));
    i = parseInt($("#amount06").val()) + parseInt($("#amount07").val());
    $("#avg3").val(~~(i / 2));
    i = parseInt($("#amount08").val()) + parseInt($("#amount09").val());
    $("#avg4").val(~~(i / 2));
    i = parseInt($("#amount0A").val()) + parseInt($("#amount0B").val());
    $("#avg5").val(~~(i / 2));
    i = parseInt($("#amount0C").val()) + parseInt($("#amount0D").val());
    $("#avg6").val(~~(i / 2));
    i = parseInt($("#amount0E").val()) + parseInt($("#amount0F").val());
    $("#avg7").val(~~(i / 2));
    i = parseInt($("#amount10").val()) + parseInt($("#amount11").val());
    $("#avg8").val(~~(i / 2));
    i = parseInt($("#amount12").val()) + parseInt($("#amount13").val());
    $("#avg9").val(~~(i / 2));
    i = parseInt($("#amount14").val()) + parseInt($("#amount15").val());
    $("#avgA").val(~~(i / 2));
    i = parseInt($("#amount16").val()) + parseInt($("#amount17").val());
    $("#avgB").val(~~(i / 2));
};