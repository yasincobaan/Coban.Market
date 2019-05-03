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
        "url": "/Cargo/LoadData",
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
        {
            "data": "Id",
            "title": "CargoId",
            "name": "Id",
            "autoWidth": true
        },
        
        {
            "data": "CargoName",
            "title": "Cargo Name",
            "name": "Cargo Name",
            "autoWidth": true
        },
        {
            "data": "CargoDescription",
            "title": "Cargo Description",
            "name": "Description",
            "autoWidth": true
        },
        {
            "data": "CargoPhone",
            "title": "CargoPhone",
            "name": "Cargo Phone",
            "autoWidth": true
        },
        {
            "data": "Id",
            "title": "Operations",
            "render": function (data) {
                return '<a class="btn btn-danger btn-sm float-right" onclick="DelCargo(' + data + ')" style="color:white; cursor:pointer;">Delete</a>' +
                    '<button class="float-right btn btn-warning btn-sm" style="color:white; cursor:pointer; margin-right:10px;" id="editCargo">Edit</button>';
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
$('#demoGrid tbody').on('click', 'button', function () {
    var data = table.row($(this).parents('tr')).data();

    $("#Name").val(data.CargoName);
    $("#Phone").val(data.CargoPhone);
    $("#Description").val(data.CargoDescription);
    $("#Id").val(data.Id);  
    $('#editModal').modal("show");




});


function DelCargo(id) {
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
                'Your record has been deleted.',
                'success',
                DelCargoAjax(id)
            )
        } else if (
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelled',
                'Your record is safe :)',
                'error'
            )
        }
        table.draw();
    })
}
function DelCategoryAjax(id) {
    $.ajax({
        url: '/Cargo/Delete/' + id,
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            if (data.Result == true) {

            }
            else {
                Swal.fire({
                    position: 'top-end',
                    type: 'warning',
                    title: data.Response,
                    showConfirmButton: false,
                    timer: 1000
                })
            }
        }
    });
}
