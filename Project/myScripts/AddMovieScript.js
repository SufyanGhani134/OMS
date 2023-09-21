$(document).ready(function () {
    var genres = [];
    $(".genres").change(function() {

        if (this.checked) {
            genres.push(this.value);
            $("#selectedGenres").append(`<li class="mx-2" id="${this.value}">${this.value}</li>`)
        } else {
            let removeIndex = selectedGenres.indexOf(this.value);
            genres.splice(removeIndex, 1);
            $(`#${this.value}`).remove();
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
        let title = $("#movieTitle").val();
        let ReleaseYear = parseInt($("#releaseYear").val());
        let resolutionsEl = $(".resolutionArr")
        let resolutions = [];
        resolutionsEl.each((index,item) => {
            if (item.checked) {
                resolutions.push(item.value)
            }
        })
        let hrs = $("#hrs").val();
        let mins = $("#mins").val();
        let duration = `${hrs}:${mins}`;
        let ratings = parseFloat($("#rating").val());
        let description = $("#description").val();
        let posterPath = $("#poster").val().split("\\");
        let poster = posterPath[posterPath.length-1]
        let price = parseFloat($("#price").val());
        let url = window.location.pathname;
        let UserID = parseInt(url.split('/')[2]);
        let movie = { UserID, title, ReleaseYear, description, genres, duration, price, ratings, poster, resolutions }
        console.log(poster)

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



})