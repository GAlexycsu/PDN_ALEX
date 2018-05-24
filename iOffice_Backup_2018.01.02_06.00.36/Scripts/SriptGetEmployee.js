function txtsLeaderid_OnChange() {
    ShowEmployeeName();
}
function ShowEmployeeName() {
    var a = ajaxNow();
    a.onreadystatechange = function () {
        if (4 == a.readyState) {
            var b = a.responseText;
            $("#lblFulName")[0].innerHTML = b;
        }
    };
    a.open("POST", "Action_NhanVien.aspx", !0);
    a.setRequestHeader("Action", "LayTenNhanVien");
    a.setRequestHeader("NhanVienMa", $("#txtNV_MA")[0].value);
    a.send();
}
function EndAction() {
    ClosePopup("divWaiting");
}
function ClosePopup(a) {
    document.getElementById(a).style.visibility = "hidden";
    $("#" + a).dialog("close");
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
;
