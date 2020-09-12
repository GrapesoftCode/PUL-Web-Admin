PulAdmin.Controls.Combo.Grid.prototype.init = function () {
    var self = this;
}

PulAdmin.Controls.Combo.Grid.prototype.loadRows = function (rows) {
    var self = this;
    var grid = document.getElementById('grdCombos');
    grid.innerHTML = "";
    for (var indexRow = 0, len = rows.objectResult.length; indexRow < len; indexRow++) {
        var dataRow = rows.objectResult[indexRow];
        var div = document.createElement('div');
        div.className = "col-md-4 col-lg-4 col-xlg-4";

        var card = `<div id="` + dataRow.id + `"  class="card">
                        <img class="card-img-top img-responsive" src="`+ dataRow.logo.uri +`" alt="Card image cap">
                        <div class="card-body">
                            <div class="d-flex no-block align-items-center m-b-15">
                                <span><i class="ti-calendar"></i> 20 May 2018</span>
                                <div class="ml-auto">
                                    <a href="javascript:void(0)" class="link"><i class="fas fa-money-bill-alt"></i>  ` + dataRow.price + `</a>
                                </div>
                            </div>
                            <h3 class="box-title m-b-0">` + dataRow.name + `</h3><br />
                            <p><b>` + dataRow.description + `</b></p>
                            <button class="btn btn-success btn-rounded waves-effect waves-light m-t-20">Read more</button>
                        </div>
                    </div>`;

        div.innerHTML = card;
        grid.appendChild(div);
    }
}

PulAdmin.Controls.Combo.Grid.prototype.getCurrentRow = function (htmlRow) {
    return htmlRow.parent().parent().parent().parent()[0];
};