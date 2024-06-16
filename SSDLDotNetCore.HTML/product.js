const tblProduct = "products";
const tblProductCart = "productCart";

getProductTable();
getProductCartTable();

function readProducts() {
    const productList = getProducts();
    return productList;
}

function getProducts() {
    const products = localStorage.getItem(tblProduct);

    let productList = [];
    if (products !== null) {
        productList = JSON.parse(products);
    }
    return productList;
}

function getProductCart() {
    const productCart = sessionStorage.getItem(tblProductCart);

    let productCartList = [];
    if (productCart !== null) {
        productCartList = JSON.parse(productCart);
    }
    return productCartList;
}

function createProduct(product, description, price) {
    let productList = getProducts();

    const requestModel = {
        id: uuidv4(),
        product: product,
        description: description,        
        price: price
    }

    productList.push(requestModel);
    const jsonProductList = JSON.stringify(productList);
    localStorage.setItem(tblProduct, jsonProductList);

    successMessage("Saving Successful.");
    clearControl()
    getProductTable()
}

$('#btnSave').click(function () {
    const product = $('#product').val();
    const desc = $('#description').val();
    const price = $('#price').val();

    createProduct(product, desc, price);
})

function clearControl() {
    $('#product').val('');
    $('#description').val('');
    $('#price').val('');
}

function getProductTable() {
    const productList = getProducts();
    let count = 0;
    let htmlRows = '';
    productList.forEach(item => {
        const htmlRow = `
        <tr>
            <td>
                <button type="button" class="btn btn-success" onClick="addToCart('${item.id}')">+</button>
            </td>
            <td>${++count}</td>
            <td>${item.product}</td>
            <td>${item.description}</td>
            <td>${item.price}</td>
        </tr>
        `;
        htmlRows += htmlRow;
    })

    $('#productTbody').html(htmlRows);
}

function createProductCart(productId, product, description, qty, price) {
    let productCartList = getProductCart();

    const requestModel = {
        id: productId,
        product: product,
        description: description,
        qty: qty,
        price: price
    }

    productCartList.push(requestModel);
    const jsonProductList = JSON.stringify(productCartList);
    sessionStorage.setItem(tblProductCart, jsonProductList);

    successMessage("Saving Successful.");
    getProductCartTable()
}

function getProductCartTable(id) {
    const productCartList = getProductCart();

    let count = 0;
    let htmlRows = ''
    productCartList.forEach(item => {
        const htmlRow = `
        <tr>
            <td>${++count}</td>
            <td>${item.product}</td>
            <td>${item.description}</td>
            <td>${item.qty}</td>
            <td>${item.price}</td>
        </tr>
        `;
        htmlRows += htmlRow;
    })
    $('#productCartTbody').html(htmlRows);
}

function addToCart(id) {
    const productList = getProducts();
    const products = productList.filter(x => x.id == id);
    if (products.length == 0) {
        errorMessage("No data found.");
        return;
    }
    const product = products[0];

    const productCartList = getProductCart();
    const productCart = productCartList.filter(x => x.id == id);
    if (productCart.length == 0) {
        createProductCart(product.id, product.product, product.description, 1, product.price);
    } else if (productCart.length == 1) {
        updateProductCart(product);
    }
}

function updateProductCart(product) {
    const productCartList = getProductCart();
    const productCart = productCartList.filter(x=>x.id==product.id);
    if (productCart.length == 0) {
        errorMessage("No data found.");
        return;
    }
    const productCartIndex = productCart[0];
    let price = productCartIndex.price;
    let qty = productCartIndex.qty;
    let oldPrice = parseInt(price);
    let oldQty = parseInt(qty);    

    const index = productCartList.findIndex(x => x.id == product.id);
    let newPrice = parseInt(product.price);
    oldPrice += newPrice;
    product.price = oldPrice;
    product.qty = ++oldQty;
    productCartList[index] = product;
    const jsonProductList = JSON.stringify(productCartList);
    sessionStorage.setItem(tblProductCart ,jsonProductList);
    successMessage("Updating Successful.");
    getProductCartTable()
}