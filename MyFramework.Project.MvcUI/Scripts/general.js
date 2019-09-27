$(document).ready(function () {
    $('#myFile').change(function (e) {
        $('#myFileName').attr('value', e.target.files[0].name);
    });

    var my = $.connection.myHub;
    $.connection.hub.start();

    $(".aktiflik").click(function () {

        var id = parseInt($(this).attr("id"));
        var aktifMi = true;
        if ($(this).attr("class") == "btn btn-success aktiflik") {
            $(this).attr("class", "btn btn-danger aktiflik");
            $(this).text("Pasif");
            aktifMi = false;
            my.server.disabled(id, aktifMi);
        }
        else {
            $(this).attr("class", "btn btn-success aktiflik");
            $(this).text("Aktif");
            my.server.enabled(id, aktifMi);
        }


    });

    $(".siraNo").keyup(function () {
        var sira = $(this).val();
        var id = parseInt($(this).attr("id"));
        my.server.updateSiraNo(id,sira);
    });


    my.client.updateDate = function (dateTime, id) {

        $(".time" + id).text(dateTime);
    };


});


$(document).on('click', '#myButton', function () {
    $('#myModal').modal('show');
    $("#myButtonDelete").attr("href", "/Admin/HaberDelete/" + $(this).attr("data-target"));
});