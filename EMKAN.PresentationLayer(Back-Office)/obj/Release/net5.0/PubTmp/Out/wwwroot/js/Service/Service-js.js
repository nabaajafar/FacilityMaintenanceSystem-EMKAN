/*$(document).ready(function () {
    

    $(".close, .popup").on("click", function () {
        $(".popup, .popup-content").removeClass("active");
    });

    $(".open").on("click", function () {
        $(".popup, .popup-content").addClass("active");
    });
    $('#Mytable tr').click(function () {
        var href = $(this).attr("id"); alert(href);
        $(".popup, .popup-content").addClass("active");


    });

});*/


var activateBtn = document.getElementById('activate');
var deactivateBtn = document.getElementById('deactivate');
/*var userId = document.getElementById('userId').innerHTML;
var status = document.getElementById('status').innerHTML;
if (activateBtn.style.backgroundColor = "#D8D8D8") {
    Activate
}
else if (deactivateBtn.clicked == true) {
    Deactivate
}*/


function Reject(Id) {
    debugger
    var selectedId = Id;
    $.ajax({
        type: 'POST', //HTTP POST Method
        data: { ID: selectedId, Status: 3 },
        dataType: "json",
        url: mvcBaseUrl + 'BuildingManager/UpdateStatus',
        success: function () {
            location.reload();
        }
    });
}

function Approve(Id) {
    debugger
    var selectedId = Id;
    $.ajax({
        type: 'POST', //HTTP POST Method
        data: { ID: selectedId, Status: 4 },
        dataType: "json",
        url: mvcBaseUrl + 'BuildingManager/UpdateStatus',
        success: function () {
            location.reload();

        }
    });
}
$('.delete-confirm').on('click', function () {
    var postID = $(this).val();
    console.log(postID);
    swal({
        title: "Are you sure?",
        text: "If you delete this post all associated comments also deleted permanently.",
        type: "warning",
        showCancelButton: true,
        closeOnConfirm: false,
        showLoaderOnConfirm: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Yes, delete it!",
    }, function () {
        setTimeout(function () {
            $.post("delete.php", {
                id: postID
            },
                function (data, status) {
                    swal({
                        title: "Deleted!",
                        text: "Your post has been deleted.",
                        type: "success"
                    },
                        function () {
                            location.reload();
                        }
                    );
                }
            );

        }, 50);
    });
});
var selectedId;
$('select').on('change', function () {
    var selectedOption = $(this).val();
    var serviceId = $(this).attr('id');
    
    assignWorker(selectedOption, serviceId);
});

/*onchange = "assignWorker(this.options[this.selectedIndex].value*/

function assignWorker(selectedOption, serviceId) {
  
  
    var selectedValue = parseInt(selectedOption);

    var selectedID = parseInt(serviceId);
   
    $.ajax({
        type: 'POST', //HTTP POST Method
        data: { ResponsibleMaintenanceWorker: selectedValue, ID: selectedID },
        dataType: "json",
        url: mvcBaseUrl + 'MaintenanceManager/AssignWorker',
        success: function () {
            sweetAlert("Done!", "Your Assign a worker to the service number" + selectedID , "success");
            location.reload();
        }

    });
}

function setRequestId(id) {

    $.ajax({
        type: 'GET', //HTTP GET Method
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        url: mvcBaseUrl + 'Request/RequestDetails/' + id,
        success: function (data) {
            var z = document.getElementById('description');
            var y = document.getElementById('servicetype');
            var e = document.getElementById('content');
            z.innerHTML = (data.Description);
            y.innerHTML = (data.ServiceType);
           
            if (data.Content == null) {

                e.innerHTML = ("You don't have replies for this request");
            } else {

                e.innerHTML = (data.Content);
            }
        }

    });
}
