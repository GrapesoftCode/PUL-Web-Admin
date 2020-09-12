PulAdmin.Drink = function () {
};

PulAdmin.Drink.prototype.init = function () {
    var self = this;
    var controls = PulAdmin.Controls.Drink;
    this.controls = {
        grids: {
            drink: new controls.Grid('grdDrinks')
        }
    };
    this.controls.grids.drink.init();
    self.load();
};

PulAdmin.Drink.prototype.load = function () {
    var self = this;
    $.ajax({
        type: 'POST',
        url: '/Drink/GetDrinkList',
        dataType: 'json',
        data: "",
        beforeSend: function () {
            $.blockUI({
                message: '<span class="spinner-grow text-primary"></span>',
                overlayCSS: {
                    backgroundColor: '#000',
                    opacity: 0.5,
                    cursor: 'wait'
                },
                css: {
                    border: 0,
                    padding: 0,
                    backgroundColor: 'transparent'
                }
            });
        },
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data.success == true) {
                self.controls.grids.drink.loadRows(data);
            } else {
                Swal.fire({
                    title: "Operación incorrecta",
                    text: "",//response.error.message,
                    type: "error",
                    showCancelButton: false,
                    showConfirmButton: true,
                    allowEscapeKey: true,
                    closeOnClickOutside: true
                });
            }
        },
        error: function () {
            Swal.fire({
                title: "Operación incorrecta",
                text: "",//response.error.message,
                type: "error",
                showCancelButton: false,
                showConfirmButton: true,
                allowEscapeKey: true,
                closeOnClickOutside: true
            });
        },
        complete: function () {
            $.unblockUI();
            //self.configureHandlers();
        },
    });
};