const cookieName = 'cart-items';



function addToCart(id, name, price, picture) {
    let products = $.cookie(cookieName);
    if (products === undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }
    const count = $('#productcount').val();
    const currentproduct = products.find(x => x.id === id);
    if (currentproduct !== undefined) {
        products.find(x => x.id === id).count = parseInt(currentproduct.count) + parseInt(count);
    } else {
        const product = {
            id,
            name,
            unitPrice:price,
            picture,
            count
        };
        products.push(product);
    }
    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    UpdateCart();
}


function UpdateCart() {
    debugger;
    let products = $.cookie(cookieName);
    products = JSON.parse(products);
    $("#cart_items_count").text(products.length);
    const cartitemswrapper = $("#cart_items_wrapper");
    cartitemswrapper.html('');
    products.forEach(product => {
        let p = `<div class="single-cart-item">
                                                    <a href="javascript:void(0)" class="remove-icon"onclick="removeCartItem('${product.id}')">
                                                        <i class="ion-android-close"></i>
                                                    </a>
                                                    <div class="image">
                                                        <a href="single-product.html">
                                                            <img src="/ProductPicture/${product.picture}"
                                                                class="img-fluid" alt="">
                                                        </a>
                                                    </div>
                                                    <div class="content">
                                                        <p class="product-title">
                                                            <a href="single-product.html">محصول : ${product.name}</a>
                                                        </p>
                                                        <p class="count">تعداد : ${product.count}</p>
                                                        <p class="count">قیمت : ${product.unitPrice}</p>
                                                    </div>
                                                </div>`;
        cartitemswrapper.append(p);
    })

}


function removeCartItem(id) {
    let products = $.cookie(cookieName);
    products = JSON.parse(products);
    const itemToRemoves = products.findIndex(s => s.id === id);
    products.splice(itemToRemoves, 1);
    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    UpdateCart();
}



function changeCartItems(id, totalId, count) {
    var products = $.cookie(cookieName);
    products = JSON.parse(products);
    const productindex = products.findIndex(s => s.id == id); debugger;
    products[productindex].count = count;
    const product = products[productindex];
    const newprice = parseInt(product.unitPrice) * parseInt(count);
    $(`#${totalId}`).text(newprice);

    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    UpdateCart();
}