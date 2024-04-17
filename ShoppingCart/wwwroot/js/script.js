namespace ShoppingCart.wwwroot.js
{
    document.getElementById('addToCartForm').addEventListener('submit', function (event) {
        event.preventDefault(); // Prevent default form submission
        var formData = new FormData(this); // Get form data
        addToCart(formData); // Call addToCart function with form data
    });

    function addToCart(formData) {
        // Perform AJAX request to add the item to the cart
        //  using Fetch API
        fetch(`/Purchase/AddToCart`, {
            method: 'POST',
            body: formData // Use form data as request body
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Failed to add item to cart');
                }
                
            })
            .catch(error => {
                console.error('Error:', error);
                
            });
    }

}
