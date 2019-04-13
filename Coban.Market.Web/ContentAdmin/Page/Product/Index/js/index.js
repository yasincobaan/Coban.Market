
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
            "render": function(data, type, full, meta) {
                return '<a data-fancybox="gallery" id="' + full.Image1 + '" href="/Images/Product/' + full.Image1 + '"><img style="width:70px;" src="/Images/Product/' + full.Image1 + '"/></a>' +
                    '<a data-fancybox="gallery" id="' + full.Image2 + '" href="/Images/Product/' + full.Image2 + '"><img style="width:70px;" src="/Images/Product/' + full.Image2 + '"/></a>' +
                    '<a data-fancybox="gallery" id="' + full.Image3 + '" href="/Images/Product/' + full.Image3 + '"><img style="width:70px;" src="/Images/Product/' + full.Image3 + '"/></a>' +
                    '<a data-fancybox="gallery" id="' + full.Image4 + '" href="/Images/Product/' + full.Image4 + '"><img style="width:70px;" src="/Images/Product/' + full.Image4 + '"/></a>';
            }
        },
        { "data": "ProductName", "title": "ProductName", "name": "ProductName", "autoWidth": true },
        { "data": "ProductBrand", "title": "ProductBrand", "name": "ProductBrand", "autoWidth": true },
        { "data": "ExchangeRate", "title": "ExchangeRate", "name": "ExchangeRate", "autoWidth": true },
        { "data": "Price", "title": "Price", "name": "Price", "autoWidth": true },
        { "data": "DiscountedPrice", "title": "DiscountedPrice", "name": "DiscountedPrice", "autoWidth": true },
        { "data": "KdvPercent", "title": "KdvPercent", "name": "KdvPercent", "autoWidth": true },
        { "data": "Description", "title": "Description", "name": "Description", "autoWidth": true },
        { "data": "LittleDescription", "title": "LittleDescription", "name": "LittleDescription", "autoWidth": true },
        { "data": "IsSale", "title": "IsSale", "name": "IsSale", "autoWidth": true },
        { "data": "BarCode", "title": "BarCode", "name": "BarCode", "autoWidth": true },
        { "data": "StockCode", "title": "StockCode", "name": "StockCode", "autoWidth": true },
        { "data": "Stock", "title": "Stock", "name": "Stock", "autoWidth": true },
        { "data": "Category", "title": "Category", "name": "Category", "autoWidth": true },




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



