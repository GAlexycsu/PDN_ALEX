$(function () {
    $(("input[id$='txtPoDateFrom']")).datepicker({
        dateFormat: 'yy/mm/dd'
    });
    $(("input[id$='txtPoDateTo']")).datepicker({
        dateFormat: 'yy/mm/dd'
    });
});