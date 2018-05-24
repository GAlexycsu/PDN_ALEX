function GetSelectedRow(a) {
    a = document.getElementById("DropDownGroupName");
    a = a.options[a.selectedIndex].value;
    var b = ajaxNow();
    b.onreadystatechange = function () {
        if (4 == b.readyState && 200 == b.status) {
            var a = b.responseText;
            $("#divDanhSachProduct")[0].innerHTML = a;
            OpenTableDanhSachProduct();
        }
    };
    b.open("GET", "DetailGroup.aspx", !0);
    b.setRequestHeader("Action", "HienThiDanhSachProduct");
    b.setRequestHeader("valueGroup", a);
    b.send();
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
function ShowPopUp(a, b, c) {
    document.getElementById(a).style.visibility = "visible";
    $("#" + a).dialog({ title: c, show: "slide", resizable: !1, width: b, hide: "slide", stack: !1, modal: !0 });
}
function OpenTableDanhSachProduct() {
    document.getElementById("divDanhSachProduct").style.visibility = "visible";
    $("#divDanhSachProduct").dialog({ show: "slide", resizable: !1, width: 700, hide: "slide", stack: !1, modal: !0 });
}
;
