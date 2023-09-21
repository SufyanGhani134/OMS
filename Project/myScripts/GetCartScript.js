$(document).ready(async function () {
    let url = window.location.href
    let userID = url.split("/")[4];
    console.log(userID);
    let totalCost = 0;
    let cartItems = [];
    let checkedItems = [];
    calculateTotal(cartItems);
    $("#checkOutBtn").html("Check out (" + totalCost + ")");

    try {
        let CartID = await getCartID(userID) ;
        console.log(CartID, "CartID")
        $.ajax({
            type: "GET",
            url: "/CartPage.aspx/GetCartItems",
            contentType: "application/json; charset=utf-8",
            data: { cartID: 4 },
            dataType: "json",
            success: function (response) {
                console.log(response.d)
                cartItems = response.d;
                for (let i = 0; i < cartItems.length; i++) {
                    $("#cartTableBody").append(displayCart(cartItems[i]));

                    $(`#itemCheck_${cartItems[i].itemId}`).on('change', function () {
                        changeStatus(cartItems[i], this.checked); 
                    });

                }
                
            },
            error: function (error) {
                console.log(error, "this is the GET error");
            }
        });
    } catch (error) {
        console.error("Error while getting CartID:", error);
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
    function changeStatus(item, isChecked) {
        console.log(item);
        if (isChecked) {
            console.log(`Checkbox for item ${item.itemId} is checked.`);
            item.isCheck = true;
            checkedItems.push(item);
            console.log(checkedItems)
        } else {
            console.log(`Checkbox for item ${item.itemId} is unchecked.`);
            let updatedItems = checkedItems.filter(element => element.itemId != item.itemId)
            checkedItems = updatedItems;
            console.log(checkedItems)

        }

        calculateTotal(checkedItems);
        console.log(totalCost, "Total")
    }


    
})
