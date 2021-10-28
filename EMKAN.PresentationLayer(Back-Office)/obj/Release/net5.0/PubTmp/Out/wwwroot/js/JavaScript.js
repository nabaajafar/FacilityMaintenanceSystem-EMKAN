function GetDashboardStatisticsbeneficiary() {
    debugger
    $.ajax({
        type: 'GET', //HTTP GET Method
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        url: mvcBaseUrl + 'Dashboard/GetDashboardStatisticsForBeneficiary',
        success: function (data) {
          
            var y = document.getElementById('done');
            var z = document.getElementById('closed');
            var e = document.getElementById('inprogress');
           
            z.innerHTML = (data.ClosedServicesCount);
          
            y.innerHTML = (data.DoneServicesCount);
            e.innerHTML = (data.InProgressServicesCount);








        }
    });
}


//function GetDashboardStatisticsbeneficiary() {
//    debugger
//    var y = _done;
//    var z = _closed;
//    var e = _inprogress;

//    z.innerHTML = (data.ClosedServicesCount);

//    y.innerHTML = (data.DoneServicesCount);
//    e.innerHTML = (data.InProgressServicesCount);
//}


function GetDashboardStatisticsBuildingManager() {

    $.ajax({
        type: 'GET', //HTTP GET Method
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        url: mvcBaseUrl + 'Dashboard/GetDashboardStatistics',
        success: function (data) {
            var x = document.getElementById('employees');
            var y = document.getElementById('open');
            var z = document.getElementById('closed');
            var e = document.getElementById('inprogress');
            x.innerHTML = (data.AllEmployeesCount);
            z.innerHTML = (data.ClosedServicesCount);
            y.innerHTML = (data.OpenServicesCount);
            e.innerHTML = (data.InProgressServicesCount);
        }
    });
}

function GetDashboardStatisticsAdmin() {
    
    $.ajax({
        type: 'GET', //HTTP GET Method
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        url: mvcBaseUrl + 'Dashboard/GetDashboardStatistics',
        success: function (data) {
            var x = document.getElementById('employees');
            x.innerHTML = (data.AllEmployeesCount);
            var y = document.getElementById('services');
            y.innerHTML = (data.AllServicesCount);
        
        }
    });
}

function GetDashboardStatisticsMaintenanceManager() {
   
    $.ajax({
        type: 'GET', //HTTP GET Method
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        url: mvcBaseUrl + 'Dashboard/GetDashboardStatistics',
        success: function (data) {
            var f = document.getElementById('clients');
            var h = document.getElementById('productive');
            var y = document.getElementById('open');
            var z = document.getElementById('closed');
            z.innerHTML = (data.ClosedServicesCount);
            y.innerHTML = (data.OpenServicesCount);
            f.innerHTML = (data.AllClientsCount);
       /*     h.innerHTML = (data.MostProductiveEmployeeCount);*/

        }
    });
}

function GetDashboardStatisticsMaintenanceWorker() {

    $.ajax({
        type: 'GET', //HTTP GET Method
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        url: mvcBaseUrl + 'Dashboard/GetDashboardStatistics',
        success: function (data) {
            var f = document.getElementById('clients');
            var y = document.getElementById('open');
            var z = document.getElementById('closed');
            var e = document.getElementById('inprogress');
            z.innerHTML = (data.ClosedServicesCount);
            y.innerHTML = (data.OpenServicesCount);
            f.innerHTML = (data.AllClientsCount);
            e.innerHTML = (data.InProgressServicesCount);
        }
    });
}
//const signUpButton = document.getElementById('signUp');
//const signInButton = document.getElementById('signIn');
//const container = document.getElementById('container');


//signUpButton.addEventListener('click', () => {
//    container.classList.add("right-panel-active");
//});


//signInButton.addEventListener('click', () => {
//    container.classList.remove("right-panel-active");
//});

let timeout;

// traversing the DOM and getting the input and span using their IDs

//let password = document.getElementById('PassEntry')
//let strengthBadge = document.getElementById('StrengthDisp')

//// The strong and weak password Regex pattern checker

//let strongPassword = new RegExp('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9])(?=.{8,})')
//let mediumPassword = new RegExp('((?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9])(?=.{6,}))|((?=.*[a-z])(?=.*[A-Z])(?=.*[^A-Za-z0-9])(?=.{8,}))')

//function StrengthChecker(PasswordParameter) {
//    // We then change the badge's color and text based on the password strength

//    if (strongPassword.test(PasswordParameter)) {
//        strengthBadge.style.backgroundColor = "green"
//        strengthBadge.textContent = 'Strong'
//    } else if (mediumPassword.test(PasswordParameter)) {
//        strengthBadge.style.backgroundColor = 'blue'
//        strengthBadge.textContent = 'Medium'
//    } else {
//        strengthBadge.style.backgroundColor = 'red'
//        strengthBadge.textContent = 'Weak'
//    }
//}

//// Adding an input event listener when a user types to the  password input 

//password.addEventListener("input", () => {

//    //The badge is hidden by default, so we show it

//    strengthBadge.style.display = 'block'
//    clearTimeout(timeout);

//    //We then call the StrengChecker function as a callback then pass the typed password to it

//    timeout = setTimeout(() => StrengthChecker(password.value), 500);

//    //Incase a user clears the text, the badge is hidden again

//    if (password.value.length !== 0) {
//        strengthBadge.style.display != 'block'
//    } else {
//        strengthBadge.style.display = 'none'
//    }
//});