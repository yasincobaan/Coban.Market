$("#Name").focusout(function () {
    var name = $("#Name").val();
    if (name.length > 3 && name.length < 150) {
        $("#Name").css("border", "1px solid green");
    }
    else {
        $("#Name").css("border", "1px solid red");
        $('span[data-valmsg-for="Name"]').text("İsim alanı en az 3 karakter en fazla 150 karakter olmak zorundadır.");
    }
});

$("#Surname").focusout(function () {
    var surname = $("#Surname").val();
    if (surname.length > 3 && surname.length < 150) {
        $("#Surname").css("border", "1px solid green");
    }
    else {
        $("#Surname").css("border", "1px solid red");
        $('span[data-valmsg-for="Surname"]').text("Soyisim alanı en az 3 karakter en fazla 150 karakter olmak zorundadır.");
    }
});



$("#Username").focusout(function () {
    var username = $("#Username").val();
    if (username.length > 3 && username.length < 150) {

        $("#Username").css("border", "1px solid green");
    }
    else {
        $("#Username").css("border", "1px solid red");
        $('span[data-valmsg-for="Username"]').text("Kullanıcı adı en az 3 karakter en fazla 150 karakter olmak zorundadır.");
    }
});



$("#Email").focusout(function () {
    var email = $("#Email").val();
    if (email.length > 3 && email.length < 150) {
        if (validateEmail(email)) {
            $("#Email").css("border", "1px solid green");
        } else {
            $("#Email").css("border", "1px solid red");
            $('span[data-valmsg-for="Email"]').text("E-Posta adresi geçilmez.");
        }
    }
    else {
        $("#Email").css("border", "1px solid red");
        $('span[data-valmsg-for="Email"]').text("Kullanıcı adı en az 3 karakter en fazla 150 karakter olmak zorundadır.");
    }
});

function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}