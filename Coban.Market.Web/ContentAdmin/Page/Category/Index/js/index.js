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
            },
            {
                "targets": [1],
                "visible": true,
                "searchable": false
            },
            {
                "targets": [4],
                "visible": true,
                "searchable": false
            },
            {
                "targets": [5],
                "visible": true,
                "searchable": false
            }
        ],
    "columns": [
        { "data": "Id", "title": "Category Id", "name": "Id", "autoWidth": true },
        {
            "data": "Image", "title": "Category Image", "name": "Image",
            "render": function (data) {
                return '<a data-fancybox="gallery" id="' + data + '" href="/Images/Category/' + data + '"><img style="width:70px;" src="/Images/Category/' + data + '"/></a>';
            }
        },
        { "data": "Title", "title": "Category Title", "name": "Title", "autoWidth": true },
        { "data": "Description", "title": "Category Description", "name": "Description", "autoWidth": true },
        { "data": "Categories[<br/>].Title", "title": "Sub Categories", "name": "Categories.Title", "autoWidth": true },
        {
            "data": "Id", "title": "Operations",
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
$('#demoGrid tbody').on('click', 'button', function () {
    var data = table.row($(this).parents('tr')).data();

    $("#Title").val(data.Title);
    $("#Description").val(data.Description);
    $("#Id").val(data.Id);
    $("#Image").attr("src", "Images/Category/" + data.Image);
    $('#editModal').modal("show");




});
$("#Title").keydown(function () {
    if ($(this).val().length < 3) {
        $(this).css("border", "1px solid crimson");
    }
});
$("#Description").keydown(function () {
    if ($(this).val().length < 3) {
        $(this).css("border", "1px solid crimson");
    }
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
                'Your record has been deleted.',
                'success',
                DelCategoryAjax(id)
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
