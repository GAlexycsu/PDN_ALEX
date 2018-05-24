function GetSelectedRow() {
    alert("Thong Bao");
    var a = lnk.parentNode.parentNode.cells[1].getElementsByTagName("input")[0].value, b = ajaxNow();
    document.getElementById("divWaiting").innerHTML = $("#hdnDangQryTinhLuong")[0].value;
    StartAction();
    b = ajaxNow();
    b.onreadystatechange = function () {
        if (4 == b.readyState) {
            var a = b.responseText;
            $("#hdnT_Ma")[0].value = Thang + "-" + Nam;
            $("#divKetQuaLuong")[0].innerHTML = a;
            $("#divThongBao")[0].innerHTML = $("#hdnMessage")[0].value;
            EndAction();
        }
    };
    b.open("GET", "DetailGroup.aspx", !0);
    b.setRequestHeader("Action", "HienThiDanhSachProduct");
    b.setRequestHeader("mavattu", a);
    b.send();
    document.getElementById("btnXacNhanBG").click();
}
function ajaxNow() {
    var a;
    try {
        a = new XMLHttpRequest;
    } catch (b) {
        try {
            a = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (c) {
            try {
                a = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (d) {
                return alert("Your browser is old and does not have AJAX support!"), !1;
            }
        }
    }
    return a;
}
function OpenTableDanhSachProduct(a) {
    document.getElementById("divDanhSachProduct").style.visibility = "visible";
    $("#divDanhSachProduct").dialog({ title: a, show: "slide", resizable: !1, width: 700, hide: "slide", stack: !1, modal: !0 });
}
;
