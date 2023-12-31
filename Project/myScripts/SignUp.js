﻿$(document).ready(function () {
    var currentDate = new Date().toISOString().split("T")[0];
    $("#dob").attr("max", currentDate);


    $("#fname").on('keyup', function () {
        ValidatorValidate($('#fnameValidator')[0]);
    })
    $("#lname").on('keyup', function () {
        ValidatorValidate($('#lnameValidator')[0]);
    })

    $("#email").on('keyup', function () {
        ValidatorValidate($('#emailValidator')[0]);
    })
    $("#password").on('keyup', function () {
        ValidatorValidate($('#passwordValidator')[0]);
    })

    $("#confirmPassword").on('keyup', function () {
        ValidatorValidate($('#cmpPassword')[0]);
    })

    $("#SignUpBtn").click(validation);

    function validation() {
        let isValid = true;

        let firstName = $("#fname").val();
        let lastName = $("#lname").val();
        let dob = $("#dob").val();
        let email = $("#email").val();
        let password = $("#password").val();
        let confirmPass = $("#confirmPassword").val();
        let emailExp = /^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$/;
        let nameExp = /[A-Za-z]+/;

        try {
            if (firstName.length == 0) { throw "First Name required!" }
            if (lastName.length == 0) { throw "Last Name required!" };
            if (!nameExp.test(fname) || !nameExp.test(lname)) { throw "First and Last Name must contain only alphabets!" }
            if (dob == "") { throw "Date of birth is required!" }
            if (email.length == 0) { throw "Email required!" };
            if (!emailExp.test(email)) { throw "Email must be of format abc@example.com!" }
            if (password.length < 8) { throw "Password must be atleast 8 characters" }
            if (password != confirmPass) { throw "Password donot match!" }
        } catch (error) {
            isValid = false
            $("#Alert").text(error);
            $("#Alert").show();
            setTimeout(() => {
                $("#Alert").hide();
            }, 1500);
        }
        return isValid;
    }
})





function ShowAlert(isValid) {
    if (isValid === "False") {
        $("#Alert").text("User Already Exists!");
        $("#Alert").show();
        setTimeout(() => {
            $("#Alert").hide();
        }, 1500);
       
    } else if (isValid === "True") {
        window.onload = function () {
            $("#logInModal").modal('show');
        };
    }
}