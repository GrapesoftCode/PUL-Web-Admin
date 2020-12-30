PulAdmin.Controls.Drink.Grid.prototype.init = function () {
    var self = this;
}

PulAdmin.Controls.Drink.Grid.prototype.loadRows = function (rows) {
    var self = this;
    var grid = document.getElementById('grdDrinks');
    grid.className = "row el-element-overlay";
    grid.innerHTML = "";
    for (var indexRow = 0, len = rows.objectResult.length; indexRow < len; indexRow++) {
        var dataRow = rows.objectResult[indexRow];
        var div = document.createElement('div');
        div.className = "col-lg-3 col-md-6";

        var card = `<div class="card">
                        <div id="` + dataRow.id + `" class="el-card-item">
                            <div class="el-card-avatar el-overlay-1"> <img src="`+ dataRow.logo.uri +`" alt="user">
                                <div class="el-overlay">
                                    <ul class="list-style-none el-info">
                                        <li class="el-item"><button class="btn default btn-outline el-link btnDetailsDrink"><i class="fas fa-edit"></i></button></li>
                                        <li class="el-item"><button class="btn default btn-outline el-link btnDeleteDrink"><i class="fas fa-trash"></i></button></li>
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
}

PulAdmin.Controls.Drink.Grid.prototype.getCurrentRow = function (htmlRow) {
    return htmlRow.parent().parent().parent().parent().parent()[0];
};