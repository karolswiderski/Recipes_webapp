var index = 1;
showSlides();

function showSlides() {

    $("#photo" + index).fadeOut(800);
   // var dot1 = document.getElementById("#dot" + index);
    //dot1.classList.add("active");

    if (index == 1) $("#d5").removeClass("active");
    else $("#d" + (index - 1)).removeClass("active");


    $("#d" + index).addClass("active");

    console.log("asdasd");
        if (index > 0 && index < 5) {
            index++;
        } else if (index == 5) {
            index = 1;
        }
    

    setTimeout(function () {
        $("#photo" + index).fadeIn(1000);
       // var dot2 = document.getElementById("#dot" + index);
        //dot2.classList.remove("active");
    }, 800);

    setTimeout(showSlides, 8000);
}