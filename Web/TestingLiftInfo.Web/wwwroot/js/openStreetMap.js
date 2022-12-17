const mapOption = {
    center: [42.697957, 23.322460],
    zoom: 14
}

var marker;

let map = new L.map('map', mapOption);

let layer = new L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
}).addTo(map);

L.control.scale({ imperial: false }).addTo(map);

function addMarker(lanLng, address, regNumber, id) {

    if (lanLng) {
        marker = new L.marker(lanLng).addTo(map).bindPopup(`<span class="u-text-bold--800">Рег. № <a href="/Administration/Lifts/Detail/${id}">${regNumber}</a></span><br><p class="u-margin--0"><span class="text-bold--800">Адрес: </span>${address}</p>`);
    } else {
        marker = new L.marker(mapOption.center).addTo(map);
        marker.dragging.enable();
    }
}

function getLatLog(e) {
    var latLng = marker.getLatLng();
    $('#latitude').val(latLng.lat);
    $('#longitude').val(latLng.lng);
}