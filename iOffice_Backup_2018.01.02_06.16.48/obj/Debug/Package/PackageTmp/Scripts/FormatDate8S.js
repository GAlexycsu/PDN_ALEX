$(function () {
    $(("input[id$='txtFromDate']")).datepicker({
        dateFormat: 'yy/mm/dd'
    });
    $(("input[id$='txtToDate']")).datepicker({
        dateFormat: 'yy/mm/dd'
    });
    $(("input[id$='txtDate']")).datepicker({
        dateFormat: 'yy/mm/dd'
    });
});