async function AddToCart(movie) {
    let url = window.location.href
    let userID = url.split("/")[4];
    console.log(userID)
    if (typeof userID === "undefined" || userID.trim() === "") {
        console.log("here")
        $("#CartAlert").css("display", "block");
        $("#CartAlert").text("Please Log In First!");
        setTimeout(() => {
            $("#CartAlert").css("display", "none");
        }, 1500)
        return;
    }

    try {
        let CartID = await getCartID(userID);
        console.log(CartID, "CartID")
        let itemId = movie.movieId;
        let title = movie.title;
        let poster = movie.poster;
        let generatedDate = new Date();
        let unitCost = movie.price;
        let cartItem = { itemId, CartID, title, poster, generatedDate, unitCost };

        $.ajax({
            type: "POST",
            url: "/UserPage.aspx/AddCartItem",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ cartItem }),
            dataType: "json",
            success: function (response) {
                console.log(response.d)
                $("#CartAlert").removeClass("alert-danger");
                $("#CartAlert").addClass("alert-success");
                $("#CartAlert").css("display", "block");
                $("#CartAlert").text(response.d);
                setTimeout(() => {
                    $("#CartAlert").css("display", "none");
                }, 1500)
            },
            error: function (error) {
                console.log(error, "this is the POST error");
                $("#CartAlert").css("display", "block");
                $("#CartAlert").text("Error while Adding To Cart!");
                setTimeout(() => {
                    $("#CartAlert").css("display", "none");
                }, 1500)
            }
        });
    } catch (error) {
        console.error("Error while getting CartID:", error);
        $("#CartAlert").css("display", "block");
        $("#CartAlert").text("Error while Adding To Cart!");
        setTimeout(() => {
            $("#CartAlert").css("display", "none");
        }, 1500)
    }
}


