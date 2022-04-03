// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("li").hover(
    function () {
        $(this).find("span").stop().animate({
            width: "100%",
            opacity: "1",
        }, 400, function () {
        })
    }, function () {
        $(this).find("span").stop().animate({
            width: "0%",
            opacity: "0",
        }, 400, function () {
        })
    }
);