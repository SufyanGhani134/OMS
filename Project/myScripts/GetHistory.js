$(document).ready(function () {

    let totalCost = 0;
    let cartItems = [];
    let CartID
    GetCartItems();
    async function GetCartItems() {

        let url = window.location.href
        let userID = url.split("/")[4];
        console.log(userID);

        try {
            CartID = await getCartID(userID);
            console.log(CartID, "CartID")
            $.ajax({
                type: "GET",
                url: "/CartPage.aspx/GetCartItems",
                contentType: "application/json; charset=utf-8",
                data: { cartID: CartID },
                dataType: "json",
                success: function (response) {
                    console.log(response.d)
                    response.d.forEach((item) => {
                        if (item.isCheck) {
                            cartItems.push(item)
                        }
                    })

                    for (let i = 0; i < cartItems.length; i++) {
                        $("#cartTableBody").append(displayCart(cartItems[i]));
                    }
                    calculateTotal(cartItems);

                },
                error: function (error) {
                    console.log(error, "this is the GET error");
                }
            });
        } catch (error) {
            console.error("Error while getting CartID:", error);
        }
    }
    function displayCart(item) {

        return `
              <tr>
                  <td scope="row">
                      <div>
                        <input class="form-check-input cartCheck" checked disabled type="checkbox" id="itemCheck_${item.itemId}" value="" aria-label="...">
                    </div>
                  </td>
                  <td style="width:200px; height: 150px;">
                      <img src="/img/${item.poster}" style="width: 100%; height: 100%; display: block;"/>
                  </td>
                  <td>${item.title}</td>
                  <td>${item.generatedDate}</td>
                  <td>$ ${item.unitCost}</td>
            </tr>
        `
    }

    function calculateTotal(cartItems) {
        totalCost = 0
        if (cartItems) {
            cartItems.forEach((item) => {
                totalCost += item.unitCost;
            })
        }
        $("#checkOutBtn").html("Check out (" + totalCost + ")");


    }

    
})
