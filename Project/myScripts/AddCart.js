var cartItem;
async function AddToCart(movie) {
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

    let CartID = await getCartID(userID);
    let itemId = movie.movieId;
    let title = movie.title;
    let poster = movie.poster;
    let generatedDate = new Date();
    let unitCost = movie.price;
    cartItem = { itemId, CartID, title, poster, generatedDate, unitCost };
    
   
}

$(document).ready(function () {
    console.log(cartItem, "cartItem")
    $("#cartItems").val("hello")
    console.log($("#cartItems").val())
})


