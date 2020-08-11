var prevScrollPos = window.pageYOffset;
window.onscroll = function () {

    var currentScrollPos = window.pageYOffset;
    if (this.prevScrollPos > currentScrollPos) {
        this.document.getElementById("navbar").style.top = "0";
    } else {
        this.document.getElementById("navbar").style.top = "-100px";
    }

    prevScrollPos = currentScrollPos;
}