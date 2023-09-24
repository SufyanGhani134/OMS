$(document).ready(function () {
    console.log("running!")

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
            $("#SignUpAlert").text(error);
            $("#Alert").show();
            setTimeout(() => {
                $("#Alert").hide();
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
                if (response.d === "User Already Exits!") {
                    $("#Alert").show();
                    $("#Alert").text(response.d);
                    setTimeout(() => {
                        $("#Alert").hide();
                    }, 1500)
                } else {
                    $("#logInModal").modal('show')
                    $("#Alert").removeClass("alert-danger");
                    $("#Alert").addClass("alert-success");
                    $("#Alert").show();
                    $("#Alert").text("User Sign-Up successfully! Please Log In Now!");
                    setTimeout(() => {
                        $("#Alert").hide();
                    }, 1000)
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