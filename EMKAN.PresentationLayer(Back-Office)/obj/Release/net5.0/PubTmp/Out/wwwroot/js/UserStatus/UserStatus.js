
var activateBtn = document.getElementById('activate');
var deactivateBtn = document.getElementById('deactivate');
/*var status = document.getElementById('status').innerHTML;*/


function Deactivate(Id) {

    var selectedId = Id;
    $.ajax({
        type: 'POST', //HTTP POST Method
        data: { ID: selectedId, Status: 0 },
        dataType: "json",
        url: mvcBaseUrl + 'Client/UpdateStatus',
        success: function (data) {
            location.reload();
            activateBtn.style.backgroundColor = "#D8D8D8"
        }
         
    });
    activateBtn.style.backgroundColor = "#D8D8D8"
}

function Activate(Id) {
    var selectedId = Id;
    $.ajax({
        type: 'POST', //HTTP POST Method
        data: { ID: selectedId, Status: 1 },
        dataType: "json",
        url: mvcBaseUrl + 'Client/UpdateStatus',
        success: function (data) {
            location.reload();
            activateBtn.style.backgroundColor = "#89D88C"
        }
         
    });
    activateBtn.style.backgroundColor = "#89D88C"
}

