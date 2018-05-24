function XacNhan() {
    var hiden = document.getElementById('HiddenField1');
    var traLoi = confirm('Are you sure ?');
    if (traLoi) {
        hiden.value = 'yes';
    }
    else {
        hiden.value = 'no';
    }

    return hiden.value;

}