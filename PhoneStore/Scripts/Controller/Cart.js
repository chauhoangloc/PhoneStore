var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
      
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/Cart/Payment";
        });
       
    }
}
cart.init();