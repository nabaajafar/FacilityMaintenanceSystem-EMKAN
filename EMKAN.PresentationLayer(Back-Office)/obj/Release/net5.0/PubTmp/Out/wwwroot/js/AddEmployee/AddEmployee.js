
function checkPasswordStrength() {

    /*debugger;*/
    var val = document.getElementById("password").value;
    var meter = document.getElementById("meter");
    var no = 0;
    if (val != "") {

        //if (val != val2) {
        //    $("#meter").animate({ width: '40px' }, 300);
        //    meter.style.backgroundColor = "red";
        //    document.getElementById("pass_type").innerHTML = "Not Match";
        //}
        // If the password length is less than or equal to 6
        if (val.length <= 6) no = 1;

        // If the password length is greater than 6 and contain any lowercase alphabet or any number or any special character
        if (val.length > 6 && (val.match(/[a-z]/) || val.match(/\d+/) || val.match(/.[!,@@,#,$,%,^,&,*,?,_,~,-,(,)]/))) no = 2;

        // If the password length is greater than 6 and contain alphabet,number,special character respectively
        if (val.length > 6 && ((val.match(/[a-z]/) && val.match(/\d+/)) || (val.match(/\d+/) && val.match(/.[!,@@,#,$,%,^,&,*,?,_,~,-,(,)]/)) || (val.match(/[a-z]/) && val.match(/.[!,@@,#,$,%,^,&,*,?,_,~,-,(,)]/)))) no = 3;

        // If the password length is greater than 6 and must contain alphabets,numbers and special characters
        if (val.length > 6 && val.match(/[a-z]/) && val.match(/\d+/) && val.match(/.[!,@@,#,$,%,^,&,*,?,_,~,-,(,)]/)) no = 4;

        if (no == 1) {
            $("#meter").animate({ width: '40px' }, 300);
            meter.style.backgroundColor = "red";
            document.getElementById("pass_type").innerHTML = "Very Weak";
        }

        if (no == 2) {
            $("#meter").animate({ width: '80px' }, 300);
            meter.style.backgroundColor = "#F5BCA9";
            document.getElementById("pass_type").innerHTML = "Weak";
        }

        if (no == 3) {
            $("#meter").animate({ width: '120px' }, 300);
            meter.style.backgroundColor = "#FF8000";
            document.getElementById("pass_type").innerHTML = "Good";
        }

        if (no == 4) {
            $("#meter").animate({ width: '160px' }, 300);
            meter.style.backgroundColor = "#00FF40";
            document.getElementById("pass_type").innerHTML = "Strong";
        }
    }

    else {
        meter.style.backgroundColor = "white";
        document.getElementById("pass_type").innerHTML = "";
    }
}

$(document).ready(function () {
    
    $("#re-password").keyup(function () {
        MatchPassword();
    });
    $("#password").keyup(function () {
        checkPasswordStrength();
    });
    $("#form").submit(function (e) {
        var isFormValid = MatchPassword();
     
        if (!isFormValid)
            e.preventDefault();
    });
    //$('#form').on('submit', function (e) {
    //    var isFormValid = MatchPassword();
    //    debugger;
    //    if (!isFormValid)
    //        e.preventDefault();
    //});
});

function MatchPassword() {

    var val = document.getElementById("password").value;
    var val2 = document.getElementById("re-password").value;

    if (val !== val2) {
        document.getElementById("pass_type").innerHTML = "Password not match";
        return false;
    }
    else {
        document.getElementById("pass_type").innerHTML = "";
        return true;
    }
}
