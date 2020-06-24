function openCategories() {
    $("#categories-box").fadeIn(300);
    $(".cat").css("color", "RGB(136, 176, 75)");
    $("#caticonid").removeClass("fas fa-caret-down");
    $("#caticonid").addClass("fas fa-caret-up");
}

function closeCategories() {
    $("#categories-box").fadeOut(300);
    $(".cat").css("color", "white");
    $("#caticonid").removeClass("fas fa-caret-up");
    $("#caticonid").addClass("fas fa-caret-down");
}