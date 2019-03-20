
function validateEmail(user) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(user);
}

$("#email").keydown(function () {
    var user = $("#email").val();

    if (user.length > 4) {
        if (validateEmail(user)) {
            $("#email").css("border", "1px solid green");
        }
        else {
            $("#email").css("border", "1px solid red");
            $(".error").text("");
            $(".error").text("E-Posta adresi geçersiz.");
        }
    }
    else {
        $("#email").css("border", "1px solid red");
        $(".error").text("");
        $(".error").text("E-Posta adresi en az 5 karakter olmak zorundadır.");
    }

});

$("#password").keydown(function () {
    var pass = $("#password").val();
    if (pass.length > 4) {
        $("#password").css("border", "1px solid green");
        $(".error").empty();
    }
    else {
        $("#password").css("border", "1px solid red");
        $(".error").text("Şifre en az 5 karakter olmak zorundadır.");
    }

});

$(".sign").click(function () {
    var Login = {
        Email: $("#email").val(),
        Password: $("#password").val()
    }

    $('.login').addClass('loading');
    $('.state').html('Giriş Doğrulanıyor');

    $.ajax({
        url: '/Account/isLogin',
        type: 'POST',
        dataType: 'json',
        data: Login,
        success: function (data) {
            if (data.Result == true) {
                setTimeout(function () {
                    $('.state').html('Giriş');
                    $('.login').removeClass('loading');
                    $('.login').addClass('ok');
                    $('.state').html('Tekrar Hoşgeldiniz !');
                    window.location.href = "http://localhost:50259/";
                }, 1000);
            }
            else {
                $('.state').html('Giriş');
                $('.login').removeClass('loading');
                $(".error").show();
                $(".error").text(data.Response[0].Message);
            }
        }

    });
});



