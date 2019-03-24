
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
        "url": "/Category/LoadData",
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
        { "data": "Id", "title": "Category Id", "name": "Id", "autoWidth": true },
        {
            "data": "Image",
            "render": function (data) {

                return '<img style="width:70px;" src="/Images/Category/' + data + '"/>';

            }
        },
        { "data": "Title", "title": "Category Title", "name": "Title", "autoWidth": true },
        { "data": "Description", "title": "Category Description", "name": "Description", "autoWidth": true },
        {
            "data": null,
            "title": "Operations",
            "render": function (data) {

                return '<a class="btn btn-danger btn-sm float-right" onclick="DelCat(' + data + ')" style="color:white; cursor:pointer;">Delete</a>' +
                    '<button class="float-right btn btn-warning btn-sm"    style="color:white; cursor:pointer; margin-right:10px;" id="editCat">Edit</button>';

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


function DelCat(id) {
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
                DelCategoryAjax(id)
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


function DelCategoryAjax(id) {
    $.ajax({
        url: '/Category/Delete/' + id,
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

$('#demoGrid tbody').on('click', 'button', function () {
    var data = table.row($(this).parents('tr')).data();

    $("#Title").val(data.Title);
    $("#Description").val(data.Description);

    $("#Image").attr("src", "Images/Category/" + data.Image);
    $('#editModal').modal("show");




});






