(function () {
    let popup = document.getElementById('popup');
    
    let promise = new Promise((resolve, reject) => {
        resolve();
    });
    
    function showPopup() {
        popup.style.display = 'block';
    }
    
    function idleTime() {
        return new Promise((resolve, reject) => {
            setTimeout(function() {
                resolve();
            }, 2000);
        });
    }
    
    function hidePopup() {
        popup.style.display = '';
    }
    
    function redirectToAnotherWebsite() {
        document.location = 'http://www.nooooooooooooooo.com/';
    }
    
    promise
        .then(showPopup)
        .then(idleTime)
        .then(hidePopup)
        .then(redirectToAnotherWebsite);
} ())