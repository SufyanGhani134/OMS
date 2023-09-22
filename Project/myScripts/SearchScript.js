let searchGenres = [];
$(document).ready(function () {
    $("#searchBtn").click(() => {
        console.log("clicking!!")
        let searchTitle = $("#SearchInput").val();

        console.log(searchTitle);
        $.ajax({
            type: "GET",
            url: "/Default.aspx/GetSearchMovies",
            data: { title: JSON.stringify(searchTitle) },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(response.d, "searchResponse")
                let searchMovies = response.d;
                if (searchMovies.length > 0) {
                    DisplayMovies(searchMovies);
                    let url = window.location.href
                    let userID = url.split("/")[4];
                    console.log(userID)
                    if (typeof userID !== "undefined") {
                        searchMovies.forEach((movie) => {
                            movie.genres.forEach((genre) => {
                                searchGenres.push(genre);
                            })
                        })
                        console.log(searchGenres)
                        AddSeacrhHistory(userID, searchGenres);
                    }
                } else {
                    $("#movieContainer").html('<h1 class="text-light">No Results Found!!</h1>');
                }
                
            },
            error: function (error) {
                console.log(error, "this is the error");

            }
        });
    })


    function AddSeacrhHistory(userID, searchGenres) {

        $.ajax({
            type: "POST",
            url: "/UserPage.aspx/AddSearchHistory",
            data: JSON.stringify({ userID: userID, genres: searchGenres }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(response.d)
                
            },
            error: function (error) {
                console.log(error, "this is the error");

            }
        });

    }

    $("#suggestTab").click(() => {
        getSuggestMovies();
    })
    function getSuggestMovies() {

        let url = window.location.href
        let userID = url.split("/")[4];
        console.log(userID)
        if (typeof userID === "undefined") {
            console.log("here")
            $("#CartAlert").css("display", "block");
            $("#CartAlert").text("Please Log In First!");
            setTimeout(() => {
                $("#CartAlert").css("display", "none");
            }, 1500)
            return;
        }


            $.ajax({
                type: "GET",
                url: "/UserPage.aspx/GetSuggestMovies",
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