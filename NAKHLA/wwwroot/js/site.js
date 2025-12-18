// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('.close , .showmore').on('click', function () {
    $('.card').toggleClass('flipped');
    $('.close').toggleClass('visible');
});

//Gallery
var galleryWidth = parseInt($('ul').css('width'), 10);
var currentLeft = parseInt($('ul').css('left'), 10);

// NEXT button
$('#next').on('click', function (e) {
    e.preventDefault();
    if (Math.abs(currentLeft) < (galleryWidth - 300)) {
        $('.gallery').css('left', (currentLeft - 300) + 'px');
        currentLeft -= 300;
    } else {
        $('.gallery').css('left', 0 + 'px');
        currentLeft = 0;
    }
});

// PREV button
$('#prev').on('click', function (e) {
    e.preventDefault();
    if (Math.abs(currentLeft) >= (galleryWidth - 300)) {
        $('.gallery').css('left', (currentLeft + 300) + 'px');
        currentLeft += 300;
    } else {
        $('.gallery').css('left', 0 + 'px');
        currentLeft = -900;
    }
});