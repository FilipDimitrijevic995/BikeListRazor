var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/bike",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "30%" },
            { "data": "brand", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/BikeList/Edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            Edit
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Delete('/api/bike?id='+${data})>
                            Delete
                        </a>
                        </div>`;
                }, "width": "100%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}
