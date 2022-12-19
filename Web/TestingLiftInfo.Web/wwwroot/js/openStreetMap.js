var map;
var layer;

function getMapOption() {
    return mapOption = {
        center: [42.697957, 23.322460],
        zoom: 16
    };
}

function createMap(mapOptions) {

    map = new L.map('map', mapOptions);

    layer = new L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    }).addTo(map);

    L.control.scale({ imperial: false }).addTo(map);
}

function addMarker(lanLng, dragging, address, regNumber, id) {
    var marker;

    if (lanLng && address && regNumber && id) {
        marker = new L.marker(lanLng).addTo(map).bindPopup(`<span class="u-text-bold--800">Рег. № <a href="/Administration/Lifts/Detail/${id}">${regNumber}</a></span><br><p class="u-margin--0"><span class="u-text-bold--800">Адрес: </span>${address}</p>`);
    } else {
        marker = new L.marker(lanLng).addTo(map);
    }

    dragging ? marker.dragging.enable() : marker.dragging.disable();
}

function getLatLog(e) {
    var latLng = marker.getLatLng();
    $('#latitude').val(latLng.lat);
    $('#longitude').val(latLng.lng);
}