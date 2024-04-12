
window.onload = function () {
    console.log(`Loading ... ${window.location.href}`);
    // Login logic
    const logoutDiv = document.getElementById("logout-div");
    if (window.location.href.includes("/login")) {
        const loginEl = document.getElementById("login-form");
        if (loginEl != null && loginEl.onsubmit == null) {
            loginEl.onsubmit = function (event) {
                console.log(event.composedPath());
            }
        }
    } else {
        
        logoutDiv.style.display = "block";
    }
    

    
    
}
