var index = 1;


function showSlides(x, flag) {

    document.getElementById("photo_" + index).style.display = "none";

    if (flag == true) {
        if (index > 0 && index < 5) {
            index++;
        } else if (index == 5) {
            index = 1;
        }
    } else {
        if (index > 1 && index < 6) {
            index--;
        } else if (index == 1) {
            index = 5;
        }
    }

    document.getElementById("photo_" + index).style.display = "table-cell";
}