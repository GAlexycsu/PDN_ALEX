$(document).ready(function () {
    $(".groupOfTexbox").keypress(function (a) {
        return isNumber(a);
    });
});
function isNumber(a) {
    a = a.which ? a.which : event.keyCode;
    return 45 == a || 46 == a && -1 == $(this).val().indexOf(".") || 188 == a || !(48 > a || 57 < a) ? !0 : !1;
}
;
