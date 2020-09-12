PulAdmin.Promotion = function () {
};

PulAdmin.Promotion.prototype.init = function () {
    var self = this;
    var controls = PulAdmin.Controls.Promotion;
    this.controls = {
        grids: {
            promotion: new controls.Grid('grdPromotions')
        }
    };
    this.controls.grids.promotion.init();
    self.load();
};

PulAdmin.Promotion.prototype.load = function () {
    var self = this;
    $.ajax({
        type: 'POST',
        url: '/Promotion/GetPromotionList',
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
                self.controls.grids.promotion.loadRows(data);
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