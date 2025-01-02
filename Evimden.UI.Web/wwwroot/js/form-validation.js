$(document).ready(function () {
    $("form").submit(function (event) {
        if (!$(this).valid()) {
            event.preventDefault();  // Form geçersizse, gönderimi engelle
        }
    });
});
