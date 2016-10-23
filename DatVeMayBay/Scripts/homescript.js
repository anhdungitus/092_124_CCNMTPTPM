$(document).ready(function () {

    $("#divDatCho").hide();
    $("#m_ticket02").click(function () {
        $("#chonngayVe").hide();
    });

    $("#m_ticket01").click(function () {
        $("#chonngayVe").show();
    });



    $.ajax({
        url: "/api/flights/sanbaydi/",
        dataType: "json",
        type: "GET", 
        beforeSend: function() {

        }, 
        success: function (data) {
            debugger;
            $("#noidi").empty();
            $.each(data, function (index, sanbaydi) {
                $("#noidi").append("<option>" + sanbaydi + "</option>");
            });

            $.ajax({
                url: "/api/flights/" + $("#noidi option:selected").text(),
                type: "GET",
                dataType: "json",
                success: function (data) {
                    debugger;
                    $("#noiden").empty();
                    if (data != null)
                        $.each(data, function (index, sanbayden) {
                            $("#noiden").append("<option value=''>" + sanbayden + "</option>");
                        });
                },
                error: function () {
                }
            });
        }
    });

    $("#noidi").on("change", function () {
        $.ajax({
            url: "/api/flights/sanbaydi/" + $("#noidi option:selected").text(),
            type: "GET",
            dataType: "json",
            success: function (data) {
                debugger;
                $("#noiden").empty();
                if (data != null)
                    $.each(data, function (index, sanbayden) {
                        $("#noiden").append("<option value=''>" + sanbayden + "</option>");
                    });
            },
            error: function () {
            }
        });
    });

    $("#btnSearch").click(function () {
        $.ajax({
            url: "/api/flights/",
            type: "GET",
            dataType: "json",
            success: function (data) {
                debugger;
                $("#bangTimKiemVe").hide();
                $("#divDatCho").show();
            },
            error: function () {
            }
        });
    });
});