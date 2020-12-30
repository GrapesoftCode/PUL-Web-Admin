PulAdmin.Controls.Food.Grid.prototype.init = function () {
    var self = this;

    var createTable = function (cssClass) {
        var table = document.createElement('table');
        table.className = cssClass;
        return table;
    };

    this.selectedRow = -1;

    this.card = document.createElement('div');
    this.card.className = "card";

    this.cardBody = document.createElement('div');
    this.cardBody.className = "card-body";


    this.content = document.createElement('div');
    this.content.className = "table-responsive";

    var contentHead = document.createElement('thead');
    var contentRowLayoutHead = document.createElement('tr');
    contentRowLayoutHead.className = "footable-header";

    contentHead.appendChild(contentRowLayoutHead);
    contentRowLayoutHead.innerHTML = `<th style="display: table-cell;">Nombre</th>
                                        <th style="display: table-cell;">Categoria</th>
                                        <th style="display: table-cell;">Porción</th>
                                        <th style="display: table-cell;">Cantidad</th>
                                        <th style="display: table-cell;">Precio</th>
                                        <th style="display: table-cell;">Descripción</th>
                                        <th style="display: table-cell;"></th>`;
    var contentBody = document.createElement('tbody');
    var contentRowLayout = document.createElement('tr');
    contentBody.appendChild(contentRowLayout);


    this.tcontent = createTable('table table-bordered m-t-30 table-hover contact-list footable footable-5 footable-paging footable-paging-center breakpoint-lg');
    this.tcontent.appendChild(contentHead);
    this.tcontent.appendChild(contentBody);
    this.content.appendChild(this.tcontent);

    this.cardBody.appendChild(this.content);
    this.card.appendChild(this.cardBody);

    this.grid.appendChild(this.card);
}

PulAdmin.Controls.Food.Grid.prototype.loadRows = function (rows) {
    var self = this;
    var grid = document.getElementById('grdFoods');


    grid.className = "row el-element-overlay";
    grid.innerHTML = "";
    for (var indexRow = 0, len = rows.objectResult.length; indexRow < len; indexRow++) {
        var dataRow = rows.objectResult[indexRow];
        var div = document.createElement('div');
        div.className = "col-lg-3 col-md-6";

        var card = `<div class="card">
                        <div id="` + dataRow.id + `" class="el-card-item">
                            <div class="el-card-avatar el-overlay-1"> <img src="`+ dataRow.logo.uri + `" alt="user">
                                <div class="el-overlay">
                                    <ul class="list-style-none el-info">
                                        <li class="el-item"><button class="btn default btn-outline el-link btnDetailsFood"><i class="fas fa-edit"></i></button></li>
                                        <li class="el-item"><button class="btn default btn-outline el-link btnDeleteFood"><i class="fas fa-trash"></i></button></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="d-flex no-block align-items-center">
                                <div class="m-l-15">
                                    <h4 class="m-b-0">` + dataRow.name + `</h4>
                                    <span class="text-muted">` + dataRow.description + `</span>
                                </div>
                                <div class="ml-auto m-r-15">
                                    <h2 class="m-t-0">$` + dataRow.price + `</h2>
                                </div>
                            </div>
                        </div>
                    </div>`;

        div.innerHTML = card;
        grid.appendChild(div);
    }






    //var tbody = this.tcontent.lastChild;
    //tbody.innerHTML = "";

    //for (var indexRow = 0, len = rows.objectResult.length; indexRow < len; indexRow++) {
    //    var dataRow = rows.objectResult[indexRow];
    //    var trow = document.createElement('tr');
    //    trow.setAttribute("id", dataRow.id);
    //    var $trow = $(trow);
    //    //tr.className = "col-md-6 col-lg-6 col-xlg-4";
    //    //var td = document.createElement('td');
    //    //td.setAttribute("id", dataRow.id);
    //    $trow.data('dataRow', dataRow);

    //    var cell = `  <td style="display: table-cell;">
    //                    <a href="javascript:void(0)"><img src="` + dataRow.logo.uri + `" alt="user" width="50" class="rounded-circle"> ` + dataRow.name + `</a>
    //                </td>
    //                <td style="display: table-cell;">` + dataRow.category + `</td>
    //                <td style="display: table-cell;">` + dataRow.portion + `</td>
    //                <td style="display: table-cell;">` + dataRow.grams + `</td>
    //                <td style="display: table-cell;"><span class="label label-danger"> $` + dataRow.price + `</span> </td>
    //                <td style="display: table-cell;">` + dataRow.description + `</td>
    //                <td class="text-center" style="display: table-cell;">
    //                    <button id='` + dataRow.id + `' type="button" class="btn btn-success btn-circle btnDetailsFood"><i class="far fa-edit"></i></button>
    //                    <button id='` + dataRow.id + `' type="button" class="btn btn-danger btn-circle btnDeleteFood"><i class="ti-trash"></i></button>
    //                </td>`;

    //    trow.innerHTML = cell;
    //    tbody.appendChild(trow);
    //}
    //this.selectedRow = -1;
};

PulAdmin.Controls.Food.Grid.prototype.getCurrentRow = function (htmlRow) {
    //return htmlRow[0];
    return htmlRow.parent().parent().parent().parent().parent()[0];
};