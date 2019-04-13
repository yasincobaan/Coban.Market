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
    $("#dropitem4").mouseover(function () {
        $("#dropitem4").addClass("active");

    });
    $("#dropitem4").mouseout(function () {
        $("#dropitem4").removeClass("active");
    });
    
    var url = $("#url").val();
    if (url == "/Category") {
        $("#catItem").addClass("active");
        $("#catMenu").attr("aria-expanded", "true");
        $("#collapseCat").addClass("show");
        $("#catMenu").removeClass("collapsed").addClass("show");
        $("#categoriesLinks").addClass("active");
    }
    else if (url == "/Category/Index") {
        $("#catItem").addClass("active");
        $("#catMenu").attr("aria-expanded", "true");
        $("#collapseCat").addClass("show");
        $("#catMenu").removeClass("collapsed").addClass("show");
        $("#categoriesLinks").addClass("active");
    }
    else if (url == "/Category/Create") {
        $("#catItem").addClass("active");
        $("#catMenu").attr("aria-expanded", "true");
        $("#collapseCat").addClass("show");
        $("#catMenu").removeClass("collapsed").addClass("show");
        $("#categoryAddLinks").addClass("active");
    }
    else if (url == "/Product") {
        $("#prdItem").addClass("active");
        $("#prdMenu").attr("aria-expanded", "true");
        $("#collapsePrd").addClass("show");
        $("#prdMenu").removeClass("collapsed").addClass("show");
        $("#productsLinks").addClass("active");
    }
    else if (url == "/Product/Index") {
        $("#prdItem").addClass("active");
        $("#prdMenu").attr("aria-expanded", "true");
        $("#collapsePrd").addClass("show");
        $("#prdMenu").removeClass("collapsed").addClass("show");
        $("#productsAddLinks").addClass("active");
    }
    else if (url == "/Product/Create") {
        $("#prdItem").addClass("active");
        $("#prdMenu").attr("aria-expanded", "true");
        $("#collapsePrd").addClass("show");
        $("#prdMenu").removeClass("collapsed").addClass("show");
        $("#productsAddLinks").addClass("active");
    }
    else if (url == "/MarketUser") {
        $("#userItem").addClass("active");
        $("#userMenu").attr("aria-expanded", "true");
        $("#collapseUser").addClass("show");
        $("#userMenu").removeClass("collapsed").addClass("show");
        $("#usersLinks").addClass("active");
    }
    else if (url == "/MarketUser/Index") {
        $("#userItem").addClass("active");
        $("#userMenu").attr("aria-expanded", "true");
        $("#collapseUser").addClass("show");
        $("#userMenu").removeClass("collapsed").addClass("show");
        $("#usersLinks").addClass("active");
    }
    else if (url == "/MarketUser/Create") {
        $("#userItem").addClass("active");
        $("#userMenu").attr("aria-expanded", "true");
        $("#collapseUser").addClass("show");
        $("#userMenu").removeClass("collapsed").addClass("show");
        $("#usersAddLinks").addClass("active");
    }
    else {
        $("#focusHome").addClass("active");
    }
});