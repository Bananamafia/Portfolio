$(document).ready(function () {
    $(".scroll-btn-backward").hide();
});

var currentPosition = 0;

$(".project-card-stack").scroll(function () {
    currentPosition = this.scrollLeft;

    switch (this.scrollLeft) {
        case 0: {
            $(this).siblings(".scroll-btn-backward").hide();
            break;
        }
        case this.scrollWidth - this.clientWidth: {
            $(this).siblings(".scroll-btn-forward").hide();
            break;
        }
        default: {
            $(this).siblings(".scroll-btn-backward").show();
            $(this).siblings(".scroll-btn-forward").show();
        }
    }
});

$(".scroll-btn-backward").click(function () {
    var projectCardStack = $(this).siblings(".project-card-stack");
    projectCardStack.scrollLeft(currentPosition - $(this).parent().width());
});

$(".scroll-btn-forward").click(function () {
    var projectCardStack = $(this).siblings(".project-card-stack");
    projectCardStack.scrollLeft(currentPosition + $(this).parent().width());
});

$(window).resize(function () {
    if (currentPosition != 0) {
        $(".project-card-stack").scrollLeft(currentPosition + 1);
    }
});