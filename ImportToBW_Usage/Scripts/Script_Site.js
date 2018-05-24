  
$(window).load(function () {    
    $('#loading').hide();
});
function Loaded() {
    $('#loading').hide();
}
function Loading() {   
    $('#loading').show();
}

function StartAction() {
    var Dialog = document.getElementById("divWaiting");
    Dialog.style.visibility = "visible";
    $("#divWaiting").dialog({
        show: 'slide',
        resizable: false,
        width: 500,        
        hide: 'slide',
        stack: false,
        modal: true
    });
}
function ShowPopUp(div, pWidth, pTitle) {
    var Dialog = document.getElementById(div);
    Dialog.style.visibility = "visible";
    $("#" + div).dialog({
        title: pTitle,
        show: 'slide',
        resizable: false,
        width: pWidth,
        hide: 'slide',
        stack: false,
        modal: true
    });
}
function EndAction() {
    ClosePopup("divWaiting")
}
function ClosePopup(div) {
    var Dialog = document.getElementById(div);
    Dialog.style.visibility = "hidden";
    $("#"+div).dialog("close");
}
function SetDatepicker(txt) {
    $("#"+txt).datepicker({ dateFormat: 'dd-mm-yy' });
}
function txtNV_MA_OnChange() {
    var Ma = $("#txtNV_MA")[0].value;
    if (Ma.length == 5) {
        ShowEmployeeName();
    }
    else {
        $("#lblNV_Ten")[0].innerHTML = "";
    }
}
function DangXuat() {
    var xmlHttp = ajaxNow();
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState == 4) {                     
            return;
        }
    }
    xmlHttp.open("POST", "Action_DangXuat.aspx", true);   
    xmlHttp.send();
}
function ShowEmployeeName() {    
    var xmlHttp = ajaxNow();
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState == 4) {
            var responseText = xmlHttp.responseText;
            $("#lblNV_Ten")[0].innerHTML = responseText;
            return;
        }
    }
    xmlHttp.open("POST", "Action_KiemTraNghiPhep.aspx", true);
    xmlHttp.setRequestHeader("Action", "LayTenNhanVien");
    xmlHttp.setRequestHeader("NhanVienMa", $("#txtNV_MA")[0].value);
    xmlHttp.send();
}
function ajaxNow() {
    var xmlHttp;
    try {
        /* Firefox, Opera 8.0+, Safari */
        xmlHttp = new XMLHttpRequest();       
    }
    catch (e) {
        /* newer IE */
        try {
            xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
        }
        catch (e) {
            /* older IE */
            try {
                xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch (e) {
                alert("Your browser is old and does not have AJAX support!");
                return false;
            }
        }
    }   
    return xmlHttp;
}
function SetSelectedItem(slt, val) {
    var ddl = document.getElementById(slt);
    var i = 0; 
    for (i = 0; i < ddl.length; i++) { 
        if (ddl.options[i].value == val) {
            ddl.selectedIndex = i;            
            break;
        }
    }    
}