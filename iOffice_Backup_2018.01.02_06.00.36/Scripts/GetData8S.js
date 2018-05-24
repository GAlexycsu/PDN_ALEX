function UpdateData(index) {
   
    var row = index.parentNode.parentNode;
   
    var rowIndex = row.rowIndex - 1;
   
    var idvattu = row.cells[2].getElementsByTagName("input")[0].value;
    alert(idvattu);
    var idvattu1 = row.cells[3].getElementsByTagName("input")[0].value;
    alert(idvattu1);
}