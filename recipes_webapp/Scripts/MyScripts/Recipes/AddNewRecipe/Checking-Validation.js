function checkingValidation(x) {
    if (document.getElementById("check-text-" + x).value == "") {
        $("#check-icon-" + x).removeClass("far fa-check-circle");
        $("#check-icon-" + x).addClass("far fa-times-circle");
        $("#check-icon-" + x).css("color", "red");
    } else {
        if (x > 5) document.getElementById("check-big-box-" + x).style.display = "block";
        $("#check-box-" + x).fadeIn(300);
        document.getElementById("check-big-box-" + x).style.borderLeft = "1px solid lightgray";
        document.getElementById("check-big-box-" + x).style.borderBottom = "1px solid lightgray";
        $("#check-icon-" + x).removeClass("far fa-times-circle");
        $("#check-icon-" + x).addClass("far fa-check-circle");
        $("#check-icon-" + x).css("color", "green");
    }
}