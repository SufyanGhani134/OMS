$(document).ready(function () {
    getSuggestMovies();
    function getSuggestMovies() {

        let url = window.location.href
        let userID = url.split("/")[4];


        $.ajax({
            type: "GET",
            url: "/SuggestionPage.aspx/GetSuggestMovies",
            data: { userID: userID },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(response.d, "Suggested Movies")
                DisplayMovies(response.d);

            },
            error: function (error) {
                console.log(error, "this is the error");

            }
        })
    }
})