$(document).ready(function () {
    gridviewScroll();
});
function gridviewScroll() {
    $('#<%=GridView1.ClientID%>').gridviewScroll({
        width: '100%',
        height: 300
    });
}