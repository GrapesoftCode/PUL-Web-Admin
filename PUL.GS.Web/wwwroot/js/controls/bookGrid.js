PulAdmin.Controls.Book.Grid.prototype.init = function () {
    var self = this;
}

PulAdmin.Controls.Book.Grid.prototype.loadRows = function (rows) {
    var self = this;
    var grid = document.getElementById('grdBooks');
    grid.innerHTML = "";
    for (var indexRow = 0, len = rows.objectResult.length; indexRow < len; indexRow++) {
        var dataRow = rows.objectResult[indexRow];
        var tr = document.createElement('tr');
        //tr.className = "col-md-6 col-lg-6 col-xlg-4";

        var td = `<td style="display: table-cell;"><span class="label label-warning">` + dataRow.bookStateText + `</span></td>
                    <td style="display: table-cell;"><a href="#" data-toggle="modal" data-target="#myModal"><i class="m-r-10 mdi mdi-dots-horizontal"></i></a></td>
                    <td style="display: table-cell;">`
                              + dataRow.locationTable + `<br>
                            ` + dataRow.personNumbers + `<br>
                            ` + dataRow.consumptionText + `
                    </td>
                    <td style="display: table-cell;">` + dataRow.dateHour + `</td>
                    <td style="display: table-cell;">` + dataRow.totalText + `</td>
                    <td style="display: table-cell;">` + dataRow.fullName + `</td>
                    <td style="display: table-cell;">
                        <button type="button" class="btn waves-effect waves-light  btn-success btn-circle" onClick="updateBook('`+dataRow.id +`',2)"><i class="fa fa-check"></i> </button>    
                        <button type="button" class="btn waves-effect waves-light btn-danger btn-circle" onClick="updateBook('`+dataRow.id +`',5)"><i class="fa fa-times"></i> </button>
                    </td>`;


        tr.innerHTML = td;
        grid.appendChild(tr);
    }
}

PulAdmin.Controls.Book.Grid.prototype.getCurrentRow = function (htmlRow) {
    return htmlRow.parent().parent().parent().parent()[0];
};