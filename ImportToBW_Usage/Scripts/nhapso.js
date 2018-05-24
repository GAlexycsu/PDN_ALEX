$(document).ready(function () {
    $(".groupOfTexbox").keypress(function (event) { return isNumber(event) });
});


function isNumber(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode != 45 && (charCode != 46 || $(this).val().indexOf('.') != -1) && charCode != 188  &&
                (charCode < 48 || charCode > 57 ) )
        return false;

    return true;
}   
//function isNumber(evt) {
//    var charCode = (evt.which) ? evt.which : evt.keyCode;
//    var char = evt.charCode;
//    if (charCode != 45 && charCode > 31 && (charCode != 46 || $(this).val().indexOf('.') != -1) && charCode != 188
//            && (charCode < 48 || charCode > 57))
//        return false;
//    if (char == ',') {
//        return true;
//    }
//    return true;
//}