


$(function () {
    $('#Mytable').on('click', '.deleteBtnBuilding', function (e) {
        debugger;
        var buildingId = this.id;


        swal({
            title: "Are you sure?",
            text: "You will not still be able to retrieve this building.",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, archive it!",
            cancelButtonText: "No, cancel please!",
            closeOnConfirm: false,
            closeOnCancel: false
        },
            function (isConfirm) {
                if (isConfirm) {
                    debugger;
                    //$("#deleteEmployeeFrom").unbind('click').click();
                    //$("#deleteEmployeeFrom").submit();
                    //$(".deleteBtn").unbind('click').click();

                    $.ajax({
                        type: "Delete",
                        url: '/Employee/DeleteBuilding?id=' + buildingId,
                        contentType: 'application/json; charset=utf-8',
                        success: function (data) {

                            debugger;


                            sweetAlert(
                                'Deleted!',
                                'Building Deleted',
                                'success'
                            )

                            location.reload();

                        },
                        error: function (error) {
                            swal("Oops", "Something went wrong! :)", "error");

                        }

                    });



                    // submitting the form when user press yes
                } else {
                    swal("Cancelled", "Your imaginary building is safe :)", "error");
                }
            });

    });
});




$(function () {
    $('#Mytable').on('click', '.deleteBtn', function (e) {
        debugger;
        var userId = this.id;


        swal({
            title: "Are you sure?",
            text: "You will not still be able to retrieve this user.",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, archive it!",
            cancelButtonText: "No, cancel please!",
            closeOnConfirm: false,
            closeOnCancel: false
        },
            function (isConfirm) {
                if (isConfirm) {
                    debugger;
                    //$("#deleteEmployeeFrom").unbind('click').click();
                    //$("#deleteEmployeeFrom").submit();
                    //$(".deleteBtn").unbind('click').click();

                    $.ajax({
                        type: "Delete",
                        url: '/Employee/Delete?id=' + userId,
                        contentType: 'application/json; charset=utf-8',
                        success: function (data) {

                            debugger;


                            sweetAlert(
                                'Deleted!',
                                'User Deleted',
                                'success'
                            )

                            location.reload();

                        },
                        error: function (error) {
                            swal("Oops", "Something went wrong! :)", "error");

                        }

                    });



                   
                } else {
                    swal("Cancelled", "Your imaginary user is safe :)", "error");
                }
            });

    });
});