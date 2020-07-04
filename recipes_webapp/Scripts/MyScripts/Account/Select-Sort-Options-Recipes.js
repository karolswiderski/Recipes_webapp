function selectRecipesSortOption(x) {
    for (var i = 1; i < 4; i++) {
        $(".recipes-sort-" + i).fadeOut("500");
        document.getElementsByClassName('recipes-sort-button-' + i)[0].style.fontWeight = 'normal';
        document.getElementsByClassName('recipes-sort-button-' + i)[0].style.color = '#bfbfbf';
    }
    $(".recipes-sort-" + x).fadeIn("800");
    document.getElementsByClassName('recipes-sort-button-' + x)[0].style.fontWeight = 'bold';
    document.getElementsByClassName('recipes-sort-button-' + x)[0].style.color = 'RGB(136, 176, 75)';
}

function selectFollowingRecipesSortOption(x) {
    for (var i = 1; i < 3; i++) {
        $(".following-recipes-sort-" + i).fadeOut("500");
        document.getElementsByClassName('following-recipes-sort-button-' + i)[0].style.fontWeight = 'normal';
        document.getElementsByClassName('following-recipes-sort-button-' + i)[0].style.color = '#bfbfbf';
    }
    $(".following-recipes-sort-" + x).fadeIn("800");
    document.getElementsByClassName('following-recipes-sort-button-' + x)[0].style.fontWeight = 'bold';
    document.getElementsByClassName('following-recipes-sort-button-' + x)[0].style.color = 'RGB(136, 176, 75)';
}