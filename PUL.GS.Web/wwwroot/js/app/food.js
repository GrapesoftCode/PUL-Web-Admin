PulAdmin.Food = function () {
};

PulAdmin.Food.prototype.init = function () {
    var self = this;
    var controls = PulAdmin.Controls.Food;
    this.controls = {
        grids: {
            food: new controls.Grid('grdFoods')
        }
    };
    this.controls.grids.food.init();
    self.load();
};

PulAdmin.Food.prototype.load = function () {
    var self = this;
    $.ajax({
        type: 'POST',
        url: '/Food/GetFoodList',
        dataType: 'json',
        data: "",
        beforeSend: function () {
            //$('#preloader').show();
        },
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data.success == true) {
                self.controls.grids.food.loadRows(data);
            } else {
                //swal({
                //    title: "Operación incorrecta",
                //    text: "Lo sentimos, ha ocurrido un error",
                //    type: "error",
                //    showCancelButton: false,
                //    showConfirmButton: true,
                //    allowEscapeKey: true,
                //    closeOnClickOutside: true
                //});
            }
        },
        error: function () {
            //swal({
            //    title: "Operación incorrecta",
            //    text: "Lo sentimos, ha ocurrido un error",
            //    type: "error",
            //    showCancelButton: false,
            //    showConfirmButton: true,
            //    allowEscapeKey: true,
            //    closeOnClickOutside: true
            //});
        },
        complete: function () {
            //$('#preloader').hide(); self.configureHandlers();
        },
    });
};