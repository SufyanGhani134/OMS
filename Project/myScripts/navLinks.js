$(document).ready(function () {
    let url = window.location.href
    let userID = url.split("/")[4];
    let role = url.split("/")[3];
    console.log(url.split("/"))
    $("#CartLink").click(() => {
        if (typeof userID === "undefined" || userID.trim() === "") {
            console.log("here")
            $("#CartAlert").css("display", "block");
            $("#CartAlert").text("Please Log In First!");
            setTimeout(() => {
                $("#CartAlert").css("display", "none");
            }, 1500)
            return;
        } else if (role == "Admin") {
            window.location.href = `/Admin/${userID}/Cart`
        }else {
            window.location.href = `/UserPage/${userID}/Cart`
        }
    })
    $("#homeLink").click(() => {
        if (typeof userID === "undefined" || userID.trim() === "") {
            window.location.href = "Home"
        } else if (role == "Admin") {
            window.location.href = `/Admin/${userID}/Home`
        }
        else {
            window.location.href = `/UserPage/${userID}/Home`
        }
    })
    $("#historyTab").click(() => {
        if (typeof userID === "undefined" || userID.trim() === "") {
            window.location.href = "Home"
        } else if (role == "Admin") {
            window.location.href = `/Admin/${userID}/History`
        } else {
            window.location.href = `/UserPage/${userID}/History`
        }
    })
})