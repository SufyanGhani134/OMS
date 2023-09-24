$(document).ready(function () {
    var genres = [];
    $(".genres").change(function() {

        if (this.checked) {
            genres.push(this.value);
            $("#selectedGenres").append(`<li class="mx-2" id="${this.value}">${this.value}</li>`)
        } else {
            $(`#${this.value}`).remove();
            let removeIndex = genres.indexOf(this.value);
            genres.splice(removeIndex, 1);
            
        }
    })

    $("#addGenre").click(function () {
        let newGenre = $("#newGenre").val();
        genres.push(newGenre);
        $("#selectedGenres").append(`<li class="mx-2">${newGenre}</li>`)
        $("#newGenre").val("");
    })

    

    $("#addMovie").click(AddMovie)
    function AddMovie()
    {
        let isValidMovie = true;
        let title = $("#movieTitle").val();
        let ReleaseYear = $("#releaseYear").val();
        let resolutionsEl = $(".resolutionArr")
        let resolutions = [];
        resolutionsEl.each((index,item) => {
            if (item.checked) {
                resolutions.push(item.value)
            }
        })
        let hrs = $("#hrs").val();
        let mins = $("#mins").val();
        let duration;
        if ((!hrs || hrs === "0") && (!mins || mins === "0")) {
            duration = "";
        } else {
             duration = `${hrs}:${mins}`;
        }
        let ratings = $("#rating").val();
        let description = $("#description").val();
        let posterPath = $("#poster").val().split("\\");
        let poster = posterPath[posterPath.length-1]
        let price = $("#price").val();
        let url = window.location.pathname;
        let UserID = parseInt(url.split('/')[2]);

        try {
            if (title == "") { throw "Movie Title Required!" }
            if (isNaN(ReleaseYear) || ReleaseYear == "" ) { throw "Movie Release Year Required or Invalid Input!" }
            if (duration == "") { throw "Movie Duration is Required!" }
            if (isNaN(ratings) || ratings == "") { throw "Movie Ratings Required!" }
            if (description == "") { throw "Movie description is Required!" }
            if (poster == "") { throw "Movie Poster is Required!" }
            if (isNaN(price) || price == "") { throw "Movie Price Required or Invalid Input!" }
            if (genres.length == 0) { throw "Movie Genre(s) Required!" }
            if (resolutions.length == 0) { throw "Movie Resolution(s) Required!" }
        } catch (error) {
            isValidMovie = false;
            $("#Alert").show();
            $("#Alert").text(error)
            setTimeout(() => {
                $("#Alert").hide();
            }, 1500)
        }

        let movie = { UserID, title, ReleaseYear: parseInt(ReleaseYear), description, genres, duration, price: parseFloat(price), ratings: parseFloat(ratings), poster, resolutions }
        console.log(movie)
        if (isValidMovie) {
            $.ajax({
                type: "POST",
                url: "../../AdminPage.aspx/AddMovie",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ movie: JSON.stringify(movie) }),
                success: function (response) {
                    console.log(response.d)
                    if (!response.d) {
                        $("#AddMovieAlert").css("display", "block");
                        $("#AddMovieAlert").text("Error!")
                        setTimeout(() => {
                            $("#AddMovieAlert").css("display", "none");
                        }, 1500)
                        emptyFields();
                    } else {
                        $("#AddMovieAlert").removeClass("alert-danger");
                        $("#AddMovieAlert").addClass("alert-success");
                        $("#AddMovieAlert").css("display", "block");
                        $("#AddMovieAlert").text("Movie Added successfully!");
                        setTimeout(() => {
                            $("#Alert").css("display", "block");
                        }, 1000)
                    }

                },
                error: function (error) {
                    console.log(error, "this is the error");
                }
            });
        }
        

    }

    function emptyFields() {
        $("#movieTitle").val("");
        $("#releaseYear").val("");
        $(".resolutionArr").each((index, item) => {
            item.checked = false;
        })
       $("#hrs").val("");
        $("#mins").val("");
        $("#rating").val("");
        $("#description").val("");
        $("#poster").val("")
        $("#price").val("");
    }


})