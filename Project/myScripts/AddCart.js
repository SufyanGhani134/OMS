var cartItem;
function AddToCart(movie) {
    let url = window.location.href
    let userID = url.split("/")[4];
    if (typeof userID === "undefined" || userID.trim() === "") {
        $("#Alert").show();
        $("#Alert").text("Please Log In First!");
        setTimeout(() => {
            $("#Alert").hide();
        }, 1500)
        return;
    }
    let itemId = movie.movieId;
    let title = movie.title;
    let poster = movie.poster;
    let generatedDate = new Date();
    let unitCost = movie.price;
    let cartID = 0;
    cartItem = { itemId, cartID, title, poster, generatedDate, unitCost };
    console.log(cartItem, "cartItem")
    $("#cartItems").val(JSON.stringify(cartItem))
    console.log($("#cartItems").val())
}



