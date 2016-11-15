// Write your Javascript code.
window.onload = function () {
    $("#menu_button").on("click", function () {
        menuShowHide();
    });
}

function menuShowHide() {
    if ($("header").css("display") == "none") {
        $("header").show();
        $("footer").show();
        $("#side_container").css("width", "20%");
        $("#menu_button").css("margin-right", "5%");
        $("#menu_button span").removeClass("glyphicon-chevron-right");
        $("#menu_button span").addClass("glyphicon-chevron-left");
        $(".body-content").css("width", "75%");
    }
    else {
        $("header").hide();
        $("footer").hide();
        $("#side_container").css("width", "4%");
        $("#menu_button").css("margin-right", "43%");
        $("#menu_button span").removeClass("glyphicon-chevron-left");
        $("#menu_button span").addClass("glyphicon-chevron-right");
        $(".body-content").css("width", "95%");
    }
}