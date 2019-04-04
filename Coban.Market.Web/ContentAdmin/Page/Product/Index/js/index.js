
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
        "url": "/Product/LoadData",
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
            "data": "Image1", "title": "Product Image 1", "name": "Image1",
            "render": function (data) {
                return '<a data-fancybox="gallery" id="' + data + '" href="/Images/Product/' + data + '"><img style="width:70px;" src="/Images/Product/' + data + '"/></a>';
            }
        },
        {
            "data": "Image2", "title": "Product Image 2", "name": "Image2",
            "render": function (data) {
                return '<a data-fancybox="gallery" id="' + data + '" href="/Images/Product/' + data + '"><img style="width:70px;" src="/Images/Product/' + data + '"/></a>';
            }
        },
        {
            "data": "Image3", "title": "Product Image 3 ", "name": "Image3",
            "render": function (data) {
                return '<a data-fancybox="gallery" id="' + data + '" href="/Images/Product/' + data + '"><img style="width:70px;" src="/Images/Product/' + data + '"/></a>';
            }
        },
        {
            "data": "Image4", "title": "Product Image 4", "name": "Image4",
            "render": function (data) {
                return '<a data-fancybox="gallery" id="' + data + '" href="/Images/Product/' + data + '"><img style="width:70px;" src="/Images/Product/' + data + '"/></a>';
            }
        },



        { "data": "Brand", "title": "Brand", "name": "Brand", "autoWidth": true },
        { "data": "Price", "title": "Price", "name": "Price", "autoWidth": true },
        { "data": "DiscountedPrice", "title": "Brand", "name": "Brand", "autoWidth": true },
        { "data": "LittleDescription", "title": "Brand", "name": "Brand", "autoWidth": true },
        { "data": "Description", "title": "Brand", "name": "Brand", "autoWidth": true },
        { "data": "isSale", "title": "Brand", "name": "Brand", "autoWidth": true },
        { "data": "isStock", "title": "Brand", "name": "Brand", "autoWidth": true },
        { "data": "StockAdet", "title": "Brand", "name": "Brand", "autoWidth": true },
        { "data": "LikeCount", "title": "Brand", "name": "Brand", "autoWidth": true },
        { "data": "CategoryId", "title": "Brand", "name": "Brand", "autoWidth": true },
        { "data": "Comments[]", "title": "Brand", "name": "Brand", "autoWidth": true },

        {
            "data": "Id", "title": "Operations",
            "render": function (data) {
                return '<a class="btn btn-danger btn-sm float-right" onclick="DelProduct(' + data + ')" style="color:white; cursor:pointer;">Delete</a>' +
                    '<button class="float-right btn btn-warning btn-sm"    style="color:white; cursor:pointer; margin-right:10px;" id="editPrd">Edit</button>';
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


function DelProduct(id) {
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
                'Product has been deleted.',
                'success',
                DelProductAjax(id)
            )
        } else if (
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelled',
                'Product is safe :)',
                'error'
            )
        }
        table.draw();
    })
}


function DelProductAjax(id) {
    $.ajax({
        url: '/Product/Delete/' + id,
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
    $("#Id").val(data.Id);
    $("#Image").attr("src", "Images/Product/" + data.Image);
    $('#editModal').modal("show");




});



