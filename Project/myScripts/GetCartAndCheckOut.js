$(document).ready( function () {
    let totalCost = 0;
    let cartItems = [];
    let checkedItems = [];
    let CartID
    GetCartItems();
    var loggedUser = JSON.parse(localStorage.getItem("user"));
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

                    $("#totalItems").html(`(${cartItems.length})`)
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

        let date = item.generatedDate.split("T")[0];
        let time = item.generatedDate.split("T")[1].split(".")[0];

        return `
              <tr>
                  <td scope="row">
                      <div>
                        <input class="form-check-input cartCheck" type="checkbox" id="itemCheck_${item.itemId}" value="" aria-label="...">
                    </div>
                  </td>
                  </td>
                  <td style="width:200px; height: 150px;">
                      <img src="/img/${item.poster}" style="width: 100%; height: 100%; display: block;"/>
                  </td>
                  <td>${item.title}</td>
                  <td>${date}   ${time}</td>
                  <td>$ ${item.unitCost} </td>
                  <td>
                    <button class="btn btn-warning removeBtn" id="removeBtn_${item.itemId}"> Remove From Cart</button>
                  </td>
            </tr>
        `
    }

    $("#checkAll").click(function () {
        console.log(cartItems)
        if ($("#checkAll").prop("checked")) {
            $(".cartCheck").each(function () {
                $(this).prop("checked", true);
            });
        } else {
            $(".cartCheck").each(function () {
                $(this).prop("checked", false);
            });
        }

        cartItems.forEach((item) => {
            changeStatus(item, $("#checkAll").prop("checked"));
        })
    });


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
        $("#removeItemID").val(removeId);
        //$.ajax({
        //    type: "POST",
        //    url: "/CartPage.aspx/RemoveCartItem",
        //    contentType: "application/json; charset=utf-8",
        //    data: JSON.stringify({ cartItemID: removeId }),
        //    dataType: "json",
        //    success: function (response) {
        //        console.log(response.d);
        //    },
        //    error: function (error) {
        //        console.log(error, "this is the POST error");
        //    }
        //})
    }

    $("#checkOutBtn").click(() => {
        return CheckOut();
    })
    function CheckOut() {
        const checkedIDs = checkedItems.map(item => item.itemId);
        console.log(checkedItems, "***********");
        
        if (checkedItems.length > 0) {
            $("#checkedItems").val(JSON.stringify(checkedIDs));
            $("#updatedCartID").val(CartID);
            $("#updatedTotalCost").val(totalCost);
            $("#reciptArr").val(JSON.stringify(checkedItems));
            checkedItems.forEach((item, index) => {
                $("#receiptBody").append(
                    `<tr>
                        <td class="p-2">${index + 1}</td>
                        <td class="p-2">${item.title}</td>
                        <td class="p-2">${item.unitCost}</td>
                </tr>
            `);
            })
            return true;           
        } else {
            alert("select check box to buy items!")
            return false;
        }
       
    }
    

  
})

function DisplayReceipt() {
    console.log(JSON.parse($("#reciptArr").val()), "***********");
    let checkedItems = JSON.parse($("#reciptArr").val());
    checkedItems.forEach((item, index) => {
        $("#receiptBody").append(
            `<tr>
                        <td class="p-2">${index + 1}</td>
                        <td class="p-2">${item.title}</td>
                        <td class="p-2">${item.unitCost}</td>
                </tr>
            `);
    })
    let date = new Date();
    $("#boughtAt").html(date.getDate() + "/" + date.getMonth() + "/" + date.getFullYear())
    window.onload = function () {
        $("#receiptBtn").modal('show');
    };
}
