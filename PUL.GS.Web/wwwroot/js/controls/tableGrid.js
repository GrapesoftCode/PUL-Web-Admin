PulAdmin.Controls.Table.Grid.prototype.init = function () {
    var self = this;
}

PulAdmin.Controls.Table.Grid.prototype.loadRows = function (rows) {
    var self = this;
    var grid = document.getElementById('grdTables');
    grid.innerHTML = "";
    for (var indexRow = 0, len = rows.objectResult.length; indexRow < len; indexRow++) {
        var dataRow = rows.objectResult[indexRow];
        var div = document.createElement('div');
        var smokingArea = dataRow.smokingArea == true ? "Si" : "No";
        div.className = "col-md-4 col-lg-4 col-xlg-4";
        //<img class="card-img-top img-responsive" src="`+ dataRow.logo +`" alt="Card image cap">
        var card = `<div id="` + dataRow.id + `"  class="card">
                        
                        <div class="card-body">
                            <div class="d-flex no-block align-items-center m-b-15">
                                <span><i class="fas fa-map-marker-alt"></i>  `+ dataRow.location +`</span>
                                <div class="ml-auto">
                                    <a href="javascript:void(0)" class="link"><i></i>`+ dataRow.number +`  #</a>
                                </div>
                            </div>
                            <h4 class="font-normal"> Mesa ` + dataRow.selectType + ` con capacidad para ` + dataRow.quantity + ` personas</h4>
                            <p class="m-b-0 m-t-10"> Area para fumar: ` + smokingArea + `</p>
                            <p class="m-b-0 m-t-10"> Costo mínimo por persona: ` + dataRow.minimumConsumption + ` pesos </p>
                            <div class="m-b-0 m-t-20">
                                <div class="bt-switch">
                                    <input type="checkbox" checked data-on-color="success" data-off-color="danger" data-on-text="Disponible" data-off-text="Ocupada">
                                </div>
                            </div>
                        </div>
                    </div>`;

        div.innerHTML = card;
        grid.appendChild(div);
        $(".bt-switch input[type='checkbox'], .bt-switch input[type='radio']").bootstrapSwitch();
    }
}

PulAdmin.Controls.Table.Grid.prototype.getCurrentRow = function (htmlRow) {
    return htmlRow.parent().parent().parent().parent()[0];
};