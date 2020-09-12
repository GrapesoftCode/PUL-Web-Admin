PulAdmin.Controls.Food.Grid.prototype.init = function () {
    var self = this;
}

PulAdmin.Controls.Food.Grid.prototype.loadRows = function (rows) {
    var self = this;
    var grid = document.getElementById('grdFoods');
    grid.innerHTML = "";
    for (var indexRow = 0, len = rows.objectResult.length; indexRow < len; indexRow++) {
        var dataRow = rows.objectResult[indexRow];
        var tr = document.createElement('tr');
        //tr.className = "col-md-6 col-lg-6 col-xlg-4";

        var td =    `<td style="display: table-cell;">
                        <a href="javascript:void(0)"><img src="` + dataRow.logo.uri + `" alt="user" width="50" class="rounded-circle"> ` + dataRow.name + `</a>
                    </td>
                    <td style="display: table-cell;">` + dataRow.category + `</td>
                    <td style="display: table-cell;">` + dataRow.portion + `</td>
                    <td style="display: table-cell;">` + dataRow.grams + `</td>
                    <td style="display: table-cell;"><span class="label label-danger"> $` + dataRow.price + `</span> </td>
                    <td class="footable-last-visible" style="display: table-cell;">` + dataRow.description + `</td>`;

        tr.innerHTML = td;
        grid.appendChild(tr);
    }
}

PulAdmin.Controls.Food.Grid.prototype.getCurrentRow = function (htmlRow) {
    return htmlRow.parent().parent().parent().parent()[0];
};