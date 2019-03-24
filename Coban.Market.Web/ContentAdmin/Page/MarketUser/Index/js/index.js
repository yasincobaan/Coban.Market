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

                    return '<img style="width:100px;" src="/Images/MarketUser/' + data + '"/>';

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
                        return 'Full Admin';
                    }
                    else if (data == 101) {
                        return 'Admin';
                    }
                    else if (data == 102) {
                        return 'Editör';
                    }
                    else {
                        return 'Null';
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
                        return 'Active';
                    } else {
                        return 'Passive';
                    }
                }
            }
        ]
    });

    
});