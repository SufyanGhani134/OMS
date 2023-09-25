$(document).ready( function () {
    let totalCost = 0;
    let cartItems = [];
    let checkedItems = [];
    let CartID
    GetCartItems();
    async function GetCartItems() {

        let url = window.location.href
        let userID = url.split("/")[4];
        
        calculateTotal(cartItems);
        $("#checkOutBtn").val("Check out (" + totalCost + ")");
        try {
             CartID = await getCartID(userID);
            $.ajax({
                type: "GET",
                url: "/CartPage.aspx/GetCartItems",
                contentType: "application/json; charset=utf-8",
                data: { cartID: CartID },
                dataType: "json",
                success: function (response) {
                    $("#cartTableBody").html();
                    response.d.forEach((item) => {
                        if (!item.isCheck) {
                            cartItems.push(item)
                        }
                    })
                    
                    for (let i = 0; i < cartItems.length; i++) {
                        $("#cartTableBody").append(displayCart(cartItems[i]));

                        $(`#itemCheck_${cartItems[i].itemId}`).on('change', function () {
                            changeStatus(cartItems[i], this.checked);
                        });

                        $(`#removeBtn_${cartItems[i].itemId}`).click(function () {
                            RemoveFromCart(cartItems[i]);
                        })

                    }

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
                        <input class="form-check-input cartCheck" type="checkbox" id="itemCheck_${item.itemId}" value="" aria-label="...">
                    </div>
                  </td>
                  <td style="width:200px; height: 150px;">
                      <img src="/img/${item.poster}" style="width: 100%; height: 100%; display: block;"/>
                  </td>
                  <td>${item.title}</td>
                  <td>${item.generatedDate}</td>
                  <td>$ ${item.unitCost}</td>
                  <td>
                    <button class="btn btn-warning removeBtn" id="removeBtn_${item.itemId}"> Remove From Cart</button>
                  </td>
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
        $("#checkOutBtn").val("Check out (" + totalCost + ")");

    }
    function changeStatus(item, isChecked) {
        if (isChecked) {
            item.isCheck = true;
            checkedItems.push(item);
        } else {
            let updatedItems = checkedItems.filter(element => element.itemId != item.itemId)
            checkedItems = updatedItems;
        }

        calculateTotal(checkedItems);
    }
    function RemoveFromCart(item) {
        console.log(item);
        let removeId = item.itemId;
        $.ajax({
            type: "POST",
            url: "/CartPage.aspx/RemoveCartItem",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ cartItemID: removeId }),
            dataType: "json",
            success: function (response) {
                console.log(response.d);
            },
            error: function (error) {
                console.log(error, "this is the POST error");
            }
        })
    }


    $("#checkOutBtn").click(() => { CheckOut() })

    function CheckOut() {
        const checkedIDs = checkedItems.map(item => item.itemId);
        if (checkedItems.length > 0) {
            $.ajax({
                type: "POST",
                url: "/CartPage.aspx/UpdateCartItems",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ cartItemIDs: checkedIDs }),
                dataType: "json",
                success: function (response) {
                    //GetCartItems();
                },
                error: function (error) {
                    console.log(error, "this is the POST error");
                }
            })
            $.ajax({
                type: "POST",
                url: "/CartPage.aspx/UpdateCart",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ cartID: CartID, totalCost: totalCost }),
                dataType: "json",
                success: function (response) {
                    console.log(response.d)
                },
                error: function (error) {
                    console.log(error, "this is the POST error");
                }
            })

            checkedItems.forEach((item) => {
                $("#receiptBody").append(DisplayReceipt(item))
            })
            $("#checkOutBtn").attr("data - bs - toggle", "modal")

        } else {
            alert("select check box to buy items!")
        }
        

        function DisplayReceipt(item) {
            let generatedDate = new Date();
            return `
            <div class="card my-2">
                          <div class="card-header">
                            Price: ${item.unitCost}
                          </div>
                          <div class="card-body">
                            <h5 class="card-title">${item.title}</h5>
                            <p>Bought At:</p>
                            <p class="card-text">${generatedDate}</p>
                          </div>
            </div>
            `
        }
    }
    
})
