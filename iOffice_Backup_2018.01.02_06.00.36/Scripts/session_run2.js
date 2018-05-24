
$(function () {
    setInterval(KeepAlive1, 10000);
});

function KeepAlive1() {
    $.post("/KeepAlive1.ashx", null, function () {
        $("#result").append("<p>Session is alive and kicking!<p/>");
    });
}
