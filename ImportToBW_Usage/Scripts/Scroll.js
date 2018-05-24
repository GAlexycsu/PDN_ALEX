alert("thong bao")
$(document).ready(function () {
    $('#<%=GridView1.ClientID %>').Scrollable({
        ScrollHeight: 600,
        IsInUpdatePanel: true
    });
});