function DisplayMovies(movies) {
    $("#movieContainer").html("");
    for (let i = 0; i < movies.length; i++) {
        $("#movieContainer").append(DisplayMovieCard(movies[i]));
        movies[i].genres.forEach((genre) => {
            DisplayGenre(genre, movies[i].movieId);
        })
        movies[i].resolutions.forEach((resolution) => {
            DisplayResolutions(resolution, movies[i].movieId);
        })
        $(`#CartBtn_${movies[i].movieId}`).click(function (e) {
            e.preventDefault();
            AddToCart(movies[i])
        })
    }
}
function DisplayGenre(genre, movieId) {
    $(`#genreList_${movieId}`).append(`<li>${genre}</li>`)
}

function DisplayResolutions(resolution, movieId) {
    $(`#resolutions_${movieId}`).append(`<li>${resolution}</li>`)
}
function DisplayMovieCard(movie) {

    let duration = movie.duration.split(":")
    return `
            <div class="card bg-primary text-white my-3" style="width: 30rem;">
                  <img class="card-img-top poster rounded" src="/img/${movie.poster}" alt="Card image cap">
                  <div class="card-body">
                      <div class="d-flex justify-content-between align-items-center mb-4">
                          <h1 class="card-title">${movie.title}<sub>(${movie.ReleaseYear})</sub></h1>
                          <strong>${movie.ratings}</strong>/10
                      </div>
                          <div class="d-flex align-items-center">
                              <strong class="text-dark">Genres:</strong>
                              <ul class="d-flex flex-wrap cardList genreList m-0 align-items-center" id="genreList_${movie.movieId}">
                                    
                              </ul>
                          </div>
                          <div class="d-flex duration my-2 align-items-center">
                            <strong class="text-dark">Duration:</strong>
                            <p class="m-0">${duration[0]}h ${duration[1]}m</p>
                          </div>
                          <div class="d-flex align-items-center">
                              <strong class="text-dark">Resolution:</strong>
                              <ul class="d-flex flex-wrap cardList resolutionsList align-items-center m-0" id="resolutions_${movie.movieId}">
                                  
                              </ul>
                          </div>
                          <div>
                              <strong class="text-dark">Details:</strong>
                                <p class="card-text detail mx-2"> ${movie.description}
                                </p>
                          </div>
                          <div class="d-flex justify-content-between align-items-center mt-2">
                            <button class="btn btn-warning text-light" id="CartBtn_${movie.movieId}" OnClientClick="return false">Add To Cart</button>        
                            <h2 class="text-warning">$ ${movie.price}</h2>
                          </div>
                  </div>
            </div>
        `
}
