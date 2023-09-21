async function getCartID(userID) {
    $("#CartLink").attr("href", `UserPage/${userID}/Cart`);
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "GET",
            url: "/UserPage.aspx/GetCartId",
            contentType: "application/json; charset=utf-8",
            data: { userID: userID },
            dataType: "json",
            success: function (response) {
                console.log(response.d, "this is cartID")
                resolve(response.d);
            },
            error: function (error) {
                console.log(error, "this is the error");
                reject(error);
            }
        });
    });
}