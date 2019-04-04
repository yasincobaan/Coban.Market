
var table = $("#demoGrid").DataTable({
    "scrollX": true,
    "language": {
        "url": "http://localhost:50057/ContentAdmin/Other/DataTable/json/languageTR.json"
    },
    dom: 'Bfrtip',
    buttons: [
        'copy', 'csv', 'excel', 'pdf', 'print',
        {
            extend: 'colvis',
            columns: ':not(.noVis)'
        }
    ],
    "processing": true,
    "serverSide": true,
    "filter": true,
    "orderMulti": false,
    "pageLength": 20,
    "ajax": {
        "url": "/MarketUser/LoadData",
        "type": "POST",
        "datatype": "json"
    },
    "columnDefs":
        [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            }
        ],
    "columns": [
        { "data": "Id", "title": "User Id", "name": "Id", "autoWidth": true },
        {
            "data": "ProfileImageFilename",
            "title": "User Photo",
            "render": function (data) {

                return '<a data-fancybox="gallery" id="' + data + '" href="/Images/MarketUser/' + data + '"><img style="width:70px;" src="/Images/MarketUser/' + data + '"/></a>';

            }
        },
        { "data": "Name", "title": "Name", "name": "Name", "autoWidth": true },
        { "data": "Surname", "title": "Surname", "name": "Surname", "autoWidth": true },
        { "data": "Username", "title": "Username", "name": "Username", "autoWidth": true },
        { "data": "Email", "title": "User Email", "name": "Email", "autoWidth": true },
        {
            "data": "Role",
            "title": "User Role",
            "name": "Role",
            "autoWidth": true,
            render: function (data, type, row) {
                if (data == 100) {
                    return '<div class="dropdown show"><a class="btn btn-primary btn-sm  dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Full Admin</a><div class="dropdown-menu" aria-labelledby="dropdownMenuLink">' +
                        '<a class="dropdown-item role">Admin</a>' +
                        '<a class="dropdown-item role">Editör</a>' +
                        '</div></div>';
                }
                else if (data == 101) {
                    return '<div class="dropdown show"><a class="btn btn-danger btn-sm  dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Admin</a><div class="dropdown-menu" aria-labelledby="dropdownMenuLink">' +
                        '<a class="dropdown-item role">Full Admin</a>' +
                        '<a class="dropdown-item role">Editör</a>' +
                        '</div></div>';
                }
                else if (data == 102) {
                    return '<div class="dropdown show"><a class="btn btn-info btn-sm  dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Editör</a><div class="dropdown-menu" aria-labelledby="dropdownMenuLink">' +
                        '<a class="dropdown-item role">Full Admin</a>' +
                        '<a class="dropdown-item role">Admin</a>' +
                        '</div></div>';
                }
                else {
                    return '<div class="dropdown show"><a class="btn btn-dark btn-sm  dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Null Role</a><div class="dropdown-menu" aria-labelledby="dropdownMenuLink">' +
                        '<a class="dropdown-item role">Full Admin</a>' +
                        '<a class="dropdown-item role">Admin</a>' +
                        '<a class="dropdown-item role">Editör</a>' +
                        '</div></div>';
                }
            }
        },
        {
            "data": "IsActive",
            "title": "is Active",
            "name": "IsActive",
            "autoWidth": true,
            render: function (data, type, row) {
                if (data == true) {
                    return '<div class="custom-control custom-checkbox">' +
                        '<input type="checkbox" class="custom-control-input" id="customCheck" name="example1">' +
                        '<label class="custom-control-label" for="customCheck"></label></div>';
                } else {
                    return '<div class="custom-control custom-checkbox">' +
                        '<input type="checkbox" class="custom-control-input" id="customCheck" name="example1">' +
                        '<label class="custom-control-label" for="customCheck"></label></div>';
                }
            }
        },
        {
            "data": "Id", "title": "Operations",
            "render": function (data) {
                return '<a class="btn btn-danger btn-sm float-right" onclick="DelMarketUser(' + data + ')" style="color:white; cursor:pointer;">Delete</a>';                    
            }
        }
    ]
});

$('type[search]').on('keyup', function () {
    table.search(this.value).draw();
});


$("#SearchMonthYear").on('click', function () {
    var Year = $("#year").val();

    var Month = $("#month").val();

    if (Month == null) {
        table.search("SearchDate" + Year).draw();
    }
    else {
        var YearMonth = Year + Month;
        table.search("SearchDate" + YearMonth).draw();
    }

});

$("#SearchDateRange").on('click', function () {

    var first = $("#first").val();
    var last = $("#last").val();
    var daterange = first + last;
    table.search("SearchDate" + daterange).draw();
});


function DelMarketUser(id) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false,
    })

    swalWithBootstrapButtons.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
    }).then((result) => {
        if (result.value) {
            swalWithBootstrapButtons.fire(
                'Deleted!',
                'Your file has been deleted.',
                'success',
                DelMarketUserAjax(id)
            )
        } else if (
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelled',
                'Your imaginary file is safe :)',
                'error'
            )
        }
        table.draw();
    })
}


function DelMarketUserAjax(id) {
    $.ajax({
        url: '/MarketUser/Delete/' + id,
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            if (data.Result == true) {

            }
            else {
                $("#errorDiv").show();
                $("#errorP").text(data.Response);
            }
        }
    });
}


