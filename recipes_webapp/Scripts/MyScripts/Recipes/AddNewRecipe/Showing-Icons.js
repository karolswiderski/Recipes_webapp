function checkIcon(x) {
    if (document.getElementById("check-text-" + x).value == "") {
        $("#check-icon-" + x).removeClass("far fa-check-circle");
        $("#check-icon-" + x).addClass("far fa-times-circle");
        $("#check-icon-" + x).css("color", "red");
    } else {
        //document.getElementById("check-box-" + x).style.display = "";
        $("#check-box-" + x).fadeIn(300);
        document.getElementById("check-big-box-" + x).style.borderLeft = "1px solid lightgray";
        document.getElementById("check-big-box-" + x).style.borderBottom = "1px solid lightgray";
        $("#check-icon-" + x).removeClass("far fa-times-circle");
        $("#check-icon-" + x).addClass("far fa-check-circle");
        $("#check-icon-" + x).css("color", "green");
    }
}

// 1 - 5 INFORMACJE PODSTAWOWE
// 6 - 20 SKŁADNIKI