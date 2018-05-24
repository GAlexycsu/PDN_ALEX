
$(function () {
    setInterval(KeepAlive3, 10000);
});

function KeepAlive3() {
    $.post("/KeepAlive3.ashx", null, function () {
        $("#result").append("<p>Session is alive and kicking!<p/>");
    });
}
