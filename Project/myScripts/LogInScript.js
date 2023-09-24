$(document).ready(function () {

    $("#LoggingBtn").click(logIn)
    function logIn() {
        let email = $("#Email").val();
        let password = $("#Password").val();

        $.ajax({
            type: "POST",
            url: "UserPage.aspx/UserLogIn",
            data: JSON.stringify({ Email: email, Password: password }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.d == 0) {
                    $("#logInAlert").show();
                    $("#logInAlert").text("InValid Email or Password!");
                    setTimeout(() => {
                        $("#logInAlert").hide();
                    }, 1500)
                }
                else {
                    console.log(response.d);
                    getUser(response.d);
                }
            },
            error: function (error) {
                $("#Alert").css("display", "block");
                console.log(error, "this is the error");
                $("#Alert").addClass("alert-danger").text("An error occurred during log-In.");

            }
        });
    }

    function getUser(userID) {
        $.ajax({
            type: "GET",
            url: "UserPage.aspx/GetUser",
            data: { UserID: userID },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(response.d)
               
                
                if (JSON.parse(response.d).Status == "Admin") {
                    window.location.href = `Admin/${userID}/Home`;
                } else {
                    window.location.href = `UserPage/${userID}/Home`;
                }

                
            },
            error: function (error) {
                $("#Alert").css("display", "block");
                console.log(error, "this is the error");
                $("#Alert").addClass("alert-danger").text("An error occurred during get user.");

            }
        });
    }
})