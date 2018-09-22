
var HotelBookAjaxCall = (id) => {
    var server = "/api/hotel/book/" + id;
    $.ajax({
        url: server,
        type: 'PUT',
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => {
        alert("Booked");
    });
};

var HotelSaveAjaxCall = (id) => {
    var server = "/api/hotel/save/" + id;
    $.ajax({
        url: server,
        type: 'PUT',
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => {
        alert("saved");
    });
};
var AddDetails = (hotel) => {
    alert(hotel);
    var server = "/post/" + hotel;
    $.ajax({
        url: server,
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => {
        console.log(response);
    });
};
var GetHotelId = (id) => {
    var server = "/get/" + id;
    $.ajax({
        url: server,
        type: 'GET',
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => {
        console.log(response);

        $('#hotels').remove();
        if ($('#hotels').children().length === 0) {

            response.forEach((hotel) => {

                var iDiv = document.createElement('div');
                iDiv.id = 'block';
                iDiv.className = 'hotel-list';
                var imageDiv = document.createElement('div');
                imageDiv.className = 'image-holder';
                var imageTag = document.createElement('img');
                imageTag.className = 'hotel-image';
                imageTag.src = "Images/" + hotel.image + "";
                imageDiv.appendChild(imageTag);
                iDiv.appendChild(imageDiv);

                var descriptionDiv = document.createElement('div');
                descriptionDiv.className = 'description';
                var nameSpan = document.createElement('span');
                nameSpan.className = 'hotel-name';
                nameSpan.innerHTML = "Room Type: " + hotel.roomType;
                descriptionDiv.appendChild(nameSpan);
                var addressSpan = document.createElement('span');
                addressSpan.innerHTML = "Rooms: " + hotel.availableRooms;
                descriptionDiv.appendChild(addressSpan);
                var price = document.createElement('span');
                price.innerHTML = "Rs: " + hotel.price + "/-";
                descriptionDiv.appendChild(price);
                iDiv.appendChild(descriptionDiv);
                var bookDiv = document.createElement('div');
                bookDiv.className = 'book';
                var button = document.createElement('button');
                button.id = hotel.ID;
                button.className = 'book-button';
                button.innerHTML = "Book Now";
                button.addEventListener('click', function () {
                    //alert(hotel.roomType);
                    AddDetails(hotel.roomId);
                });
                bookDiv.appendChild(button);
                iDiv.appendChild(bookDiv);

                $("#rooms").append(iDiv);

            });
        }
    });
};
var GetAllHotels = () => {

    HotelAllAjaxCall();
}
var HotelAllAjaxCall = () => {
    var server = "/get";
    $.ajax({
        url: server,
        type: 'GET',
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => {
        if ($('#hotels').children().length === 0) {

            response.forEach((hotel) => {

                var iDiv = document.createElement('div');
                iDiv.id = 'block';
                iDiv.className = 'hotel-list';
                var imageDiv = document.createElement('div');
                imageDiv.className = 'image-holder';
                var imageTag = document.createElement('img');
                imageTag.className = 'hotel-image';
                imageTag.src = "Images/" + hotel.image + "";
                imageDiv.appendChild(imageTag);
                iDiv.appendChild(imageDiv);

                var descriptionDiv = document.createElement('div');
                descriptionDiv.className = 'description';
                var nameSpan = document.createElement('span');
                nameSpan.className = 'hotel-name';
                nameSpan.innerHTML = hotel.Name;
                descriptionDiv.appendChild(nameSpan);
                var addressSpan = document.createElement('span');
                addressSpan.innerHTML = hotel.Address;
                descriptionDiv.appendChild(addressSpan);
                iDiv.appendChild(descriptionDiv);
                var bookDiv = document.createElement('div');
                bookDiv.className = 'book';
                var button = document.createElement('button');
                button.id = hotel.ID;
                button.className = 'book-button';
                button.innerHTML = "Book Now";
                button.addEventListener('click', function () {
                    // alert(hotel.ID);
                    GetHotelId(hotel.ID);

                });
                bookDiv.appendChild(button);
                iDiv.appendChild(bookDiv);

                $("#hotels").append(iDiv);

            });
        }

    });
};