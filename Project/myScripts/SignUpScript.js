$(document).ready(function () {
    console.log("Entering");

    var currentDate = new Date().toISOString().split("T")[0];
    $("#dob").attr("max", currentDate);
    function validation() {

        var isValid = true;

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
            if (!nameExp.test(fname) || !nameExp.test(lname)) {throw "First and Last Name must contain only alphabets!" }
            if (email.length == 0) { throw "Email required!" };
            if (!emailExp.test(email)) {throw "Email must be of format abc@example.com!" }
            if (password.length < 8) { throw "Password must be atleast 8 characters" }
            if (password != confirmPass) { throw "Password donot match!" }
        } catch (error) {
            isValid= false
            $("#Alert").text(error);
            $("#Alert").css("display", "block");
            setTimeout(() => {
                $("#Alert").css("display", "none");
            }, 1500)
         }
        let user = { firstName, lastName, dob, email, password }
        if (isValid) {
            OnSignUp(user);
        }
    }
    function OnSignUp(user) {
        $.ajax({
            type: "POST",
            url: "SignUpPage.aspx/SignUp",
            data: JSON.stringify({ user: JSON.stringify(user) }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (typeof response.d === 'string') {
                    $("#Alert").css("display", "block");
                    $("#Alert").text(response.d);
                } else {
                    $("#Alert").removeClass("alert-danger");
                    $("#Alert").addClass("alert-success");
                    $("#Alert").css("display", "block");
                    $("#Alert").text("User Sign-Up successfully!");
                }
            },
            error: function (error) {
                $("#Alert").css("display", "block");
                console.log(error, "this is the error");
                $("#Alert").addClass("alert-danger").text("An error occurred during sign-up.");
            }
        });
        
    }
   

    $("#SignUpBtn").click(validation);

    
});