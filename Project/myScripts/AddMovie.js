$(document).ready(function () {
    
    $.ajax({
        type: "GET",
        url: "/AdminPage.aspx/GetAllGenres",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response.d)
            let allGenres = response.d;
            allGenres.forEach((genre) => {
               $("#genreContainer").append(DisplayGenre(genre))
            })
        },
        error: function (error) {
            console.log(error, "this is the GET all genres error");
        }
    });

    function DisplayGenre(genre) {
        return `
        <div class="form-check">
                        <input type="checkbox" class="form-check-input genres" value="${genre}">
                        <label class="form-check-label" for="exampleCheck1">${genre}</label>
                </div>
        `
    }


   

    
})


var genres = [];
$(document).on("change", ".genres", function () {
    console.log("enter")
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
function AddMovie() {
    let isValidMovie = true;
    let title = $("#movieTitle").val();
    let ReleaseYear = $("#releaseYear").val();
    let resolutionsEl = $(".resolutionArr")
    let resolutions = [];
    resolutionsEl.each((index, item) => {
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
    let poster = posterPath[posterPath.length - 1]
    let price = $("#price").val();

    try {
        if (title == "") { throw "Movie Title Required!" }
        if (isNaN(ReleaseYear) || ReleaseYear == "" || ReleaseYear <= 0) { throw "Movie Release Year Required or Invalid Input!" }
        if (duration == "") { throw "Movie Duration is Required!" }
        if (isNaN(ratings) || ratings == "" || ReleaseYear <= 0) { throw "Movie Ratings Required!" }
        if (description == "") { throw "Movie description is Required!" }
        if (poster == "") { throw "Movie Poster is Required!" }
        if (isNaN(price) || price == "" || price <= 0) { throw "Movie Price Required or Invalid Input!" }
        if (genres.length == 0) { throw "Movie Genre(s) Required!" }
    } catch (error) {
        isValidMovie = false;
        $("#Alert").show();
        $("#Alert").text(error)
        setTimeout(() => {
            $("#Alert").hide();
        }, 1500)
    }

    $("#arrayData").val(JSON.stringify(genres))
        console.log($("#arrayData").val(), typeof ($("#arrayData").val()))

    return isValidMovie;
    
}