window.onload = function () {
    var a = $("#recall-btn").parent();
    var b = $("#product-btn").parent();
    $("#recall-btn").on("click", function () {
        $("#recall-btn").parent().addClass("active");
        $("#recalls").show();
        $("#product-btn").parent().removeClass("active");
        $("#products").hide();
    });
    $("#product-btn").on("click", function () {
        $("#product-btn").parent().addClass("active");
        $("#products").show();
        $("#recall-btn").parent().removeClass("active");
        $("#recalls").hide();
    });
}