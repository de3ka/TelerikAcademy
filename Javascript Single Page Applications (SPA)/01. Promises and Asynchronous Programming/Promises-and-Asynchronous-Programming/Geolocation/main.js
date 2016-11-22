(function () {
    let locationMap=document.getElementById("map");

    let promise = new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition((pos) => {
            resolve(pos);
        }, (err) => {
            reject(err);
        });
    });

    function extractPosition(pos) {
        return {
            lat: pos.coords.latitude,
            long: pos.coords.longitude
        };
    }

    function errorWithParsing(err) {
        locationMap.innerText = err.message;
    }

    function showMap(coordinates) {
        let mapSrc = "https://maps.googleapis.com/maps/api/staticmap?center=" + coordinates.lat + "," + coordinates.long + "&zoom=13&size=300x300&sensor=false";
        locationMap.setAttribute('src',mapSrc);
    }

    promise
        .then(extractPosition)
        .then(showMap)
        .catch(errorWithParsing);
} ())