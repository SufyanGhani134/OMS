$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "AdminPage.aspx/GetAllGenres",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response.d.split(",")) 
            $("#genre").val(response.d.split(","));
            console.log(typeof($("#genre").val()))
            //$("#MovieForm").load("~/UserControls/AddMovieUS.ascx?data="+ response.d)

        },
        error: function (error) {
            console.log(error, "this is the error");
        }
    });
})