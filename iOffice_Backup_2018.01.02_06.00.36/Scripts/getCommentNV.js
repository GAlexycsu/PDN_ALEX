function getCommentAuditor(a) {
    a = document.getElementById("TextBox" + a).value;
    var c = document.getElementById("txtSoPhieu").value, b = ajaxNow();
    b.onreadystatechange = function () {
        if (4 == b.readyState && 200 == b.status) {
            var a = b.responseText;
            $("#divShowComment")[0].innerHTML = a;
            OpenDivComment("Comment");
        }
    };
    b.open("Get", "ShowCommentNV.aspx", !0);
    b.setRequestHeader("Action", "HienThiCommentTheoNguoiDuyet");
    b.setRequestHeader("Auditor", a);
    b.setRequestHeader("pdno", c);
    b.send();
}
function ajaxNow() {
    var a;
    try {
        a = new XMLHttpRequest;
    } catch (c) {
        try {
            a = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (b) {
            try {
                a = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (d) {
                return alert("Your browser is old and does not have AJAX support!"), !1;
            }
        }
    }
    return a;
}
function OpenDivComment(a) {
    document.getElementById("divShowComment").style.visibility = "visible";
    $("#divShowComment").dialog({ title: a, show: "slide", resizable: !1, width: 500, hide: "slide", stack: !1, modal: !0 });
}
;
