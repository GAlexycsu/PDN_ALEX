function KeepAlive() {
    $.post("KeepAlive.ashx", function (b) {
        var a = $("#result");
        a.html();
        a.append(b + "</br>");
    });
}
setInterval(KeepAlive, 5E3);

