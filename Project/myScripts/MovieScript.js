$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "../../AdminPage.aspx/GetAllGenres",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response.d)
            let genersArr = response.d.slice(1, -1).split(",")
            console.log(genersArr)
            genersArr.forEach((item) => {
                console.log(item)

            })
        },
        error: function (xhr, error) {
            console.log(xhr.statusText, "this is the xhr");
            console.log(error, "this is the error");
        }
    });

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
        let poster = $("#poster").val();
        let price = parseFloat($("#price").val());
        let url = window.location.pathname;
        let UserID = parseInt(url.split('/')[2]);
        let movie = { UserID, title, ReleaseYear, description, genres, duration, price, ratings, poster, resolutions }
        console.log(movie)

        $.ajax({
            type: "POST",
            url: "../../AdminPage.aspx/AddMovie",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ movie: JSON.stringify(movie) }),
            success: function (response) {
                console.log(response.d)

            },
            error: function (error) {
                console.log(error, "this is the error");
            }
        });
    }



})