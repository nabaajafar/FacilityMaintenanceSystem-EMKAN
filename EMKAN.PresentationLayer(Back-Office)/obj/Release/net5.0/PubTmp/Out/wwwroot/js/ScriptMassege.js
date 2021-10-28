function MessageResponseAddEmp() {
    debugger;
    var num = 0;

    if ($("#firstname").val().length === 0) num = 1;
    if ($("#lastname").val().length === 0) num = 1;
    if ($("#email").val().length === 0) num = 1;
    if ($("#phone").val().length === 0) num = 1;
    if ($("#password").val().length === 0) num = 1;
    if ($("#re-password").val().length === 0) num = 1;

    if (num == 0) {

        $.ajax({
            type: "POST",
            url: '/Employee/CheckUser?username=' + $("#email").val(),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {

                if (!data) {

                    sweetAlert("Done!", "Employee added  successfuly ", "success");
                    setTimeout(function () { }, 3000);
                    window.location.href = '/Employee/ViewEmployee/';

                }
                else {
                    swal("Oops", "This email is used :)", "error");
                }


            },

            error: function (error) {
                swal("Oops", "Somthing went wrong  :)", "error");

            }

        });

    }
}
function MessageResponseBuil() {
    debugger;
    var num = 0;
    if ($("#name").val().length === 0) num = 1;
    if ($("#location").val().length === 0) num = 1;
    if ($("#floor").val().length === 0) num = 1;
    if ($("#room").val().length === 0) num = 1;
    if ($("#manager").val().length === 0) num = 1;
    if (num == 0) {
        sweetAlert("Done!", "Building added successfuly ", "success");
        setTimeout(function () { }, 3000);
    }
}


function MessageResponseEditEmployee() {
    debugger;
    var num = 0;
    if ($("#userRole").val().length === 0) num = 1;
    if (num == 0) {
        sweetAlert("Done!", "Employee role updated successfuly ", "success");
        setTimeout(function () { }, 3000);
    }
}

function MessageResponseCreateService() {
    debugger;
    var num = 0;

    if ($("#descreption").val().length === 0 || $("#descreption").val().length === 1 ) num = 1;
    if ($("#floor").val().length === 0 ) num = 1;
    if ($("#room").val().length === 0 ) num = 1;

    if (num == 0) {
        sweetAlert("Done!", "Service added successfuly ", "success");
        setTimeout(function () { }, 3000);
    }
}
