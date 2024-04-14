const logoutDiv = document.getElementById("logout-div");
const logioresult = document.getElementById("result");
window.onload = function () {
    
    // Login logic
    if (window.location.href.includes("/login")) {
        const loginEl = document.getElementById("login-form");
        
        if (loginEl != null && loginEl.onsubmit == null) {
            //loginEl.onsubmit = function (event) {
                //event.preventDefault();
                //console.log(`Event response: ${event.responseText}`);
                //var xhr = new XMLHttpRequest();
                //xhr.open("POST", "/Login/Login");
                //xhr.setRequestHeader("content-type", "application/json; charset=utf-8");
                //xhr.onreadystatechange = function () {
                //    if (this.readyState == XMLHttpRequest.DONE) {
                //        if (this.status != 200) {
                //            logioresult.innerHTML = "Log in failed.";
                //            return;
                //        }
                //        let data = JSON.parse(this.responseText);
                //        console.log(`data ${data.result}`);
                //        logioresult.innerHTML = data.result;
                //        return;
                //    }
                //}
                //let data = {
                //    "username": event.target.username.value,
                //    "password": event.target.password.value
                //};
                
                //xhr.send(JSON.stringify(data));

            //}
        }
    } else {
        
        logoutDiv.style.display = "block";
    }

}

function resetLogIOResult() {
    logioresult.innerHTML = "";
}
