var scrollSection = this.document.getElementById("project-overview-list");

var maxScrollPos = (scrollSection.scrollWidth - 360);
var prevPosScrollSection;

window.onload = function () {
    document.getElementById("prevProjects").style.opacity = 0;
    currentPosScrollSection = 0;
    prevPosScrollSection = 0;
}

scrollSection.onscroll = function () {
    //alert(scrollSection.scrollWidth);

    var currentPosScrollSection = scrollSection.scrollLeft;

    prevPosScrollSection = currentPosScrollSection;

    if (prevPosScrollSection <= 30) {
        document.getElementById("prevProjects").style.opacity = 0;
    }
    else {
        document.getElementById("prevProjects").style.opacity = 1;
    }

    if (prevPosScrollSection >= maxScrollPos - 80) {
        document.getElementById("nextProjects").style.opacity = 0;
    }
    else {
        document.getElementById("nextProjects").style.opacity = 1;
    }
}


function scrollToNextProjects() {
    currentPosScrollSection = prevPosScrollSection + 180;
    scrollSection.scroll(currentPosScrollSection, 0);
    prevPosScrollSection = currentPosScrollSection;
}

function scrollToPrevProjects() {
    currentPosScrollSection = prevPosScrollSection - 180;
    scrollSection.scroll(currentPosScrollSection, 0);
    prevPosScrollSection = currentPosScrollSection;
}