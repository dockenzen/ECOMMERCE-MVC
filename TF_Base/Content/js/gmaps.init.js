$(function () {

    map();

});

/* map */

function map() {

    var styles = [{"featureType": "landscape", "stylers": [{"saturation": -100}, {"lightness": 65}, {"visibility": "on"}]}, {"featureType": "poi", "stylers": [{"saturation": -100}, {"lightness": 51}, {"visibility": "simplified"}]}, {"featureType": "road.highway", "stylers": [{"saturation": -100}, {"visibility": "simplified"}]}, {"featureType": "road.arterial", "stylers": [{"saturation": -100}, {"lightness": 30}, {"visibility": "on"}]}, {"featureType": "road.local", "stylers": [{"saturation": -100}, {"lightness": 40}, {"visibility": "on"}]}, {"featureType": "transit", "stylers": [{"saturation": -100}, {"visibility": "simplified"}]}, {"featureType": "administrative.province", "stylers": [{"visibility": "off"}]}, {"featureType": "water", "elementType": "labels", "stylers": [{"visibility": "on"}, {"lightness": -25}, {"saturation": -100}]}, {"featureType": "water", "elementType": "geometry", "stylers": [{"hue": "#ffff00"}, {"lightness": -25}, {"saturation": -97}]}];
    map = new GMaps({
	el: '#map',
<<<<<<< HEAD
	lat: -34.662387,
	lng: -58.364848,
=======
	lat: -12.043333,
	lng: -77.028333,
>>>>>>> 53a811adbe3d1b014295fc6237d0ee057be70872
	zoomControl: true,
	zoomControlOpt: {
	    style: 'SMALL',
	    position: 'TOP_LEFT'
	},
	panControl: false,
	streetViewControl: false,
	mapTypeControl: false,
	overviewMapControl: false,
	scrollwheel: false,
	draggable: false,
	styles: styles
    });

    var image = 'img/marker.png';

    map.addMarker({
<<<<<<< HEAD
	lat: -34.662387,
	lng: -58.364848,
=======
	lat: -12.043333,
	lng: -77.028333,
>>>>>>> 53a811adbe3d1b014295fc6237d0ee057be70872
	icon: image/* ,
	 title: '',
	 infoWindow: {
	 content: '<p>HTML Content</p>'
	 }*/
    });
}