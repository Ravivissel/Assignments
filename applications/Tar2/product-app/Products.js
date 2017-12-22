CategoryInfo = new Object();
ProductInfo = new Object();

$(document).on('pagebeforeshow', '#searchCategories', function () {
    getCategory(renderCategory);
});


function renderCategory(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    $("#categoryList").empty();
    $.each(results, function (i, row) {
        dynamicLi = '<li> <a href="#showProducts" data-id="' + row.Id + '"><h3>' + row.Name + '</h3> <span class="ui-li-count">' + row.ProductAmount + '</span></a></li>';
        $('#categoryList').append(dynamicLi);
        $('#categoryList').listview('refresh');
    });
}


$(document).on('vclick', '#categoryList li a', function () {
    CategoryInfo.id = $(this).attr('data-id');
    $.mobile.changePage("#categoryDetails", { transition: "slide", changeHash: false });
    getProductsByCat(CategoryInfo, renderProducts);
});


function renderProducts(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    $("#productList").empty();
    $.each(results, function (i, row) {
        dynamicLi = '<li> <a href="#showProductsPage" data-id="' + row.Id + '">  <img src="' + row.ImagePath + '"/><h3>' + row.Title + '</h3> <p> Price: ' + row.Price + '</p> <p>Inventory: ' + row.Inventory + '</p></a></li>';
        $('#productList').append(dynamicLi);
        $('#productList').listview('refresh');
    });
}


$(document).on('vclick', '#showProducts li a', function () {
    ProductInfo.id = $(this).attr('data-id');
    $.mobile.changePage("#productDetails", { transition: "slide", changeHash: false });
    getProduct(ProductInfo, renderFullProduct);
});


function renderFullProduct(results) {
    //this is the callBackFunc 
    results = $.parseJSON(results.d);
    $('#prodPic').empty();
    $("#prodDetails").empty();
    detailsStr = "<h3>" + results.Title + "</h3><img src='" + results.ImagePath + "'><br/>Inventory: " + results.Inventory + "<br/>";
    $('#prodPic').append(detailsStr);
    if (jQuery.isEmptyObject(results.Attributes)) { 
        attributesStr = "<h3>No Attributes for this product!</h3>";
    }
    else {
        attributesStr = "<div data-role='collapsibleset' id=attList>";
        $.each(results.Attributes, function (key, value) {
            attributesStr += "<div data-role='collapsible'><h3> " + key + "</h3><p>" + value + "</p></div>";
        });
    }
    attributesStr += "</div>";
    $('#prodDetails').append(attributesStr);
    $('#attList').collapsibleset().trigger('create');
    $('#attList').collapsibleset('refresh');
}

