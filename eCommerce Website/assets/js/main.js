function changeImage(element) {
    var main_prodcut_image = document.getElementById('main_product_image');
    main_prodcut_image.src = element.src;
}

$(document).ready(function () {
    $(".toggle_dropdown").click(function () {
        $(".toggle").fadeToggle();
    });
    // show the alert
    setTimeout(function () {
        $(".alert").alert('close');
    }, 2000);
    // Link to cart
    //$("#btnCart").click(function () {
    //    window.location.href = "/cart.aspx";
    //})
    
   
});

