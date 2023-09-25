$(document).ready(function () {
    let url = window.location.href
    let userID = url.split("/")[4];
    let role = url.split("/")[3];
    $("#CartLink").click(() => {
        if (typeof userID === "undefined" || userID.trim() === "") {
            $("#Alert").text("Please Log In First!");
            $("#Alert").show();
            setTimeout(() => {
                $("#Alert").hide();
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
            window.location.href = "Home";
        } else if (role == "Admin") {
            window.location.href = `/Admin/${userID}/Home`
        }
        else {
            window.location.href = `/UserPage/${userID}/Home`
        }
    })
    $("#suggestTab").click(() => {
        if (typeof userID === "undefined" || userID.trim() === "") {
            $("#Alert").text("Please Log In First!");
            $("#Alert").show();
            setTimeout(() => {
                $("#Alert").hide();
            }, 1500)
            return;
        } else if (role == "Admin") {
            window.location.href = `/Admin/${userID}/Suggestions`
        } else {
            window.location.href = `/UserPage/${userID}/Suggestions`
        }
    })
    $("#historyTab").click(() => {
        if (typeof userID === "undefined" || userID.trim() === "") {
            $("#Alert").text("Please Log In First!");
            $("#Alert").show();
            setTimeout(() => {
                $("#Alert").hide();
            }, 1500)
            return;
        } else if (role == "Admin") {
            window.location.href = `/Admin/${userID}/History`
        } else {
            window.location.href = `/UserPage/${userID}/History`
        }
    })
})