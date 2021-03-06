﻿// Write your Javascript code.
window.onload = function () {
    $("#menu_button").on("click", function () {
        menuShowHide();
    });
    $("#login_button").on("click", function () {
        showLoginWindow();
    });
    $("#logout_button").on("click", function () {
        logout();
    });
    $("#register_button").on("click", function () {
        showRegisterWindow();
    });

    $("#product_link").on("click", function () {
        $("#product_list").collapse('toggle');
    });
    $("#about_link").on("click", function () {
        $("#about_list").collapse('toggle');

    });
    $("#register").on("click", function () {

    });

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

function menuShowHide() {
    if ($("header").css("display") == "none") {
        $("header, footer").fadeToggle("slow");
        $("#side_container").css("width", "20%");
        $("#menu_button").css("margin-right", "5%");
        $("#menu_button span").removeClass("glyphicon-chevron-right");
        $("#menu_button span").addClass("glyphicon-chevron-left");
        $(".body-content").css("width", "75%");
    }
    else {
        $("header, footer").hide();
        $("#side_container").css("width", "4%");
        $("#menu_button").css("margin-right", "43%");
        $("#menu_button span").removeClass("glyphicon-chevron-left");
        $("#menu_button span").addClass("glyphicon-chevron-right");
        $(".body-content").css("width", "95%");
    }
}

function showLoginWindow() {
    $('#login_window').modal('show');
    $("body").css('padding-right', '10%');   
}

function showRegisterWindow() {
    $('#register_window').modal('show');
    $("body").css('padding-right', '10%');
}

function login() {
    
}

function logout() {
    
}