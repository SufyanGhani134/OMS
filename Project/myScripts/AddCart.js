﻿async function AddToCart(movie) {
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

    try {
        let CartID = await getCartID(userID);
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
                $("#Alert").removeClass("alert-danger");
                $("#Alert").addClass("alert-success");
                $("#Alert").show();
                $("#Alert").text(response.d);
                setTimeout(() => {
                    $("#Alert").hide();
                }, 1500)
            },
            error: function (error) {
                console.log(error, "this is the POST cart error");
                $("#Alert").show();
                $("#Alert").text("Error while Adding To Cart!");
                setTimeout(() => {
                    $("#Alert").hide();
                }, 1500)
            }
        });
    } catch (error) {
        console.error("Error while getting CartID:", error);
        $("#Alert").show();
        $("#Alert").text("Error while Adding To Cart!");
        setTimeout(() => {
            $("#Alert").hide();
        }, 1500)
    }
}

