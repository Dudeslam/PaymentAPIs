document.addEventListener('DOMContentLoaded', function () {
    const urlParams = new URLSearchParams(window.location.search);
    const paymentId = urlParams.get('paymentId');
    if (paymentId) {
        const checkoutOptions = {
            checkoutKey: 'test-checkout-key-1f02ba7204c6411995b9a6b8772ce3fa', // Replace!
            paymentId: paymentId,
            containerId: "checkout-container-div",
        };
        const checkout = new Dibs.Checkout(checkoutOptions);
        checkout.on('payment-completed', function (response) {
            window.location = 'Completed.cshtml';
        });
    } else {
        console.log("Expected a paymentId");   // No paymentId provided, 
        window.location = 'Node.cshtml';         // go back to cart.html
    }
});