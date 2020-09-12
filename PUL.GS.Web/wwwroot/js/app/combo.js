PulAdmin.Combo = function () {
};

PulAdmin.Combo.prototype.init = function () {
    var self = this;
    var controls = PulAdmin.Controls.Combo;
    this.controls = {
        grids: {
            combo: new controls.Grid('grdCombos')
        }
    };
    this.controls.grids.combo.init();
    self.load();
};

PulAdmin.Combo.prototype.load = function () {
    var self = this;
    $.ajax({
        type: 'POST',
        url: '/Combo/GetComboList',
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
                self.controls.grids.combo.loadRows(data);
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