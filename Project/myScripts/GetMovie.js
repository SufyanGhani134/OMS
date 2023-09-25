$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/UserPage.aspx/GetAllMovies",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            let movies = response.d;
            DisplayMovies(movies);
            
        },
        error: function (error) {
            console.log(error, "this is the error");

        }
    });

    
   

    
})

