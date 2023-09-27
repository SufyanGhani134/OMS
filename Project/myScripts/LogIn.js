 function logIn()
 {
     console.log("working!")
     $("#logInAlert").show();
     $("#logInAlert").text("InValid Email or Password!");
     setTimeout(() => {
        $("#logInAlert").hide();
     }, 1500)
 }