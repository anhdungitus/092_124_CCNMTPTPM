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
            url: "/api/flights/" + $("#noidi option:selected").text() + "/"
                + $("#noiden option:selected").text()
                + "/" + $("#ngaydi").val() + "/" + $("#soluonghanhkhach").val() 
                + "/" + $("#hangve option:selected").val(),
            type: "GET",
            dataType: "json",
            success: function (data) {
                debugger;
                $("#bangTimKiemVe").hide();
                $("#divDatCho").show();
                if (data != null)
                    $.each(data, function (index, ve) {
                        $("#tblDanhSachChuyenBay").append(
                            "<tr>"
                                +"<td style=\"padding-left:10px;\"> " + ve.Ma + "</td>"
                                +"<td style=\"padding-left:10px;\"> " + ve.NoiDi + "</td>"
                                +"<td style=\"padding-left:10px;\"> " + ve.NoiDen + "</td>"
                                +"<td style=\"padding-left:10px;\"> " + ve.Ngay + "</td>"
                                +"<td style=\"padding-left:10px;\"> " + ve.Gio + "</td>"
                                +"<td style=\"padding-left:10px;\"> " + ve.Hang + "</td>"
                                +"<td style=\"padding-left:10px;\"> " + ve.MucGia + "</td>"
                                +"<td style=\"padding-left:10px;\"> " + ve.SoLuongGhe + "</td>"
                                +"<td style=\"padding-left:10px;\"> " + ve.GiaBan + "</td>"

                                +"<td style=\"padding-left:10px;\">"
                                   + "<button id=\"Datcho\" class=\"btn btn-primary\">Đặt chỗ</button>"
                                + "</td>"
                           +"</tr>"
                        );
                    });
            },
            error: function () {
            }
        });
    });
});