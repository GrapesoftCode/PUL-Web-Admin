PulAdmin.Controls.Book.Grid.prototype.init = function () {
    var self = this;
}

PulAdmin.Controls.Book.Grid.prototype.loadRows = function (rows) {
    var self = this;
    var grid = document.getElementById('grdBooks');
    grid.innerHTML = "";
    for (var indexRow = 0, len = rows.objectResult.length; indexRow < len; indexRow++) {
        var dataRow = rows.objectResult[indexRow];
        var div = document.createElement('div');
        div.className = "col-md-6 col-lg-6 col-xlg-4";

        var card = `<div id="` + dataRow.id + `"  class="card card-body">
                        <div class="row">
                            <div class="col-md-4 col-lg-3 text-center">
                                <a href="/details/` + dataRow.id + `"><img src="` + dataRow.logo + `" alt="user" class="img-circle img-responsive"></a>
                            </div>
                            <div class="col-md-8 col-lg-9">
                                <h3 class="box-title m-b-0">` + dataRow.name + `</h3><br />
                                <p><b>Contacto</b></p>
                                <address>
                                    <p class="p-b-10">` + dataRow.contact.fullName + `</p>
                                    <span>Mobile:&nbsp;</span>` + dataRow.contact.mobile + `<br />
                                    <span>Email:&nbsp;</span>` + dataRow.contact.email + `
                                </address>
                                <div class="p-t-10">
                                    <button type="button" class="btn btn-warning btnDetails">Ver detalles</button>
                                    <button type="button" class="btn btn-danger btnDeleteTeam">Eliminar</button>
                                </div>
                            </div>
                        </div>
                    </div>`;

        div.innerHTML = card;
        grid.appendChild(div);
    }
}

PulAdmin.Controls.Book.Grid.prototype.getCurrentRow = function (htmlRow) {
    return htmlRow.parent().parent().parent().parent()[0];
};