$(document).ready(function () {

    $("#profiledropdown").mouseover(function () {
        $("#profiledropdown").addClass("show");
        $("#profilelinks").addClass("show");
    });

    $("#profiledropdown").mouseout(function () {
        $("#profiledropdown").removeClass("show");
        $("#profilelinks").removeClass("show");
    });


   


    $("#dropitem1").mouseover(function () {
        $("#dropitem1").addClass("active");

    });
    $("#dropitem1").mouseout(function () {
        $("#dropitem1").removeClass("active");
    });




    $("#dropitem2").mouseover(function () {
        $("#dropitem2").addClass("active");

    });
    $("#dropitem2").mouseout(function () {
        $("#dropitem2").removeClass("active");
    });



    $("#dropitem3").mouseover(function () {
        $("#dropitem3").addClass("active");

    });
    $("#dropitem3").mouseout(function () {
        $("#dropitem3").removeClass("active");
    });

});