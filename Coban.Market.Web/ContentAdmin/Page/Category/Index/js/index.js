$(document).ready(function () {
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
            { "data": "Id", "title": "Kullanıcı Kimliği", "name": "Id", "autoWidth": true },
            {
                "data": "Image",
                "render": function (data) {

                    return '<img style="width:100px;" src="/Images/Category/' + data + '"/>';

                }
            },
            { "data": "Title", "title": "Başlık", "name": "Title", "autoWidth": true },
            { "data": "Description", "title": "Açıklama", "name": "Description", "autoWidth": true },
            {
                "data": "Id",
                "render": function (data) {

                    return '<a class="btn btn-danger" style="color:white; cursor:pointer;" id="delUser" data-id="' + data + '">Delete</a>';

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
});