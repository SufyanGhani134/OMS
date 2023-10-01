 function AlertMsg(msg)
 {
     $("#Alert").removeClass("alert-danger");
     $("#Alert").addClass("alert-success");
     $("#Alert").show();
     $("#Alert").text(msg);
     setTimeout(() => {
        $("#Alert").hide();
     }, 1500)
}

function logInAlert() {
    alert("dcbec")
    console.log("Invalid")
    $("#logInAlert").show();
    $("#logInAlert").text(msg);
    setTimeout(() => {
        $("#logInAlert").hide();
    }, 1500)

    return false;
}