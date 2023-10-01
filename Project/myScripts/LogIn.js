async function logIn() {
    let email = $("#Email").val();
    let password = $("#Password").val();

    try {
        let response = await $.ajax({
            type: "POST",
            url: "UserPage.aspx/UserLogIn",
            data: JSON.stringify({ Email: email, Password: password }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        });

        if (response.d == 0) {
            $("#logInAlert").show();
            $("#logInAlert").text("Invalid Email or Password!");
            setTimeout(() => {
                $("#logInAlert").hide();
            }, 1500);
            return false;
        } else {
            return true;
        }
    } catch (error) {
        $("#Alert").css("display", "block");
        console.log(error, "this is the error");
        $("#Alert").addClass("alert-danger").text("An error occurred during log-In.");
        setTimeout(() => {
            $("#Alert").hide();
        }, 1500);
        return false;
    }
}

function logInAndSubmit() {
    logIn().then(function (loginResult) {
        console.log(loginResult, "******");
        if (loginResult === true) {
            __doPostBack('LogBtn', '');
        }
    });
}
