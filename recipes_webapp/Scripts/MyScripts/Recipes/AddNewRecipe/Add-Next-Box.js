function addNextBox(x) {
    checkingValidation(x);
    if (x != 20)
    {
        $("#check-text-" + (x + 1)).fadeIn(300);
    }
}