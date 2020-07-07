function addIngedientBox(x) {
    checkIcon(x);
    if (x != 20)
    {
        $("#check-text-" + (x + 1)).fadeIn(300);
    }
}