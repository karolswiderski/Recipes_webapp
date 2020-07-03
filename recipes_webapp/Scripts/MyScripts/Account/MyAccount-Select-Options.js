
function selectOption(x) {
    for (var i = 1; i < 6; i++) {
        document.getElementsByClassName('box' + i)[0].style.display = 'none';
        document.getElementsByClassName('box-button-' + i)[0].style.fontWeight = 'normal';
        document.getElementsByClassName('box-button-' + i)[0].style.color = '#bfbfbf';
    }
    document.getElementsByClassName('box' + x)[0].style.display = 'block';
    document.getElementsByClassName('box-button-' + x)[0].style.fontWeight = 'bold';
    document.getElementsByClassName('box-button-' + x)[0].style.color = '#ffffff';
}