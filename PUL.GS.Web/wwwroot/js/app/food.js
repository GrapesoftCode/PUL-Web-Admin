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
            //$('#preloader').hide(); 
            self.configureHandlers();
        },
    });
};


PulAdmin.Food.prototype.configureHandlers = function () {
    var self = this;

    $(".btnDetailsFood").click(function (e) {

        var row = self.controls.grids.food.getCurrentRow($(this));

        $.ajax({
            type: 'GET',
            url: '/Food/GetFoodDetails/' + row.id,
            dataType: '',
            data: "",
            async: true,
            beforeSend: function () { $('#preloader').show(); },
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                if (response.success === true) {
                    var food = response.objectResult;

                    $("#logo").val = "";
                    $("#imgFood").attr("src", "");
                    $("#id").innerHTML = "";
                    $("#category").innerHTML = "";
                    $("#name").innerHTML = "";
                    $("#portion").innerHTML = "";
                    $("#grams").innerHTML = "";
                    $("#price").innerHTML = "";
                    $("#description").innerHTML = "";

                    $("#logo").attr("val", food.logo.name);
                    $("#imgFood").attr("src", food.logo.uri);
                    $("#id").val(food.id);
                    $("#category").val(food.category);
                    $("#name").val(food.name);
                    $("#portion").val(food.portion);
                    $("#grams").val(food.grams);
                    $("#price").val(food.price);
                    $("#description").val(food.description);

                    $("#detailsFoodModal").modal('show');
                } else {
                    swal({
                        title: "Operación incorrecta",
                        text: "Lo sentimos, ha ocurrido un error",
                        type: "error",
                        showCancelButton: false,
                        showConfirmButton: true,
                        allowEscapeKey: true,
                        closeOnClickOutside: true
                    });
                }
            },
            error: function () {
                swal({
                    title: "Operación incorrecta",
                    text: "Lo sentimos, ha ocurrido un error",
                    type: "error",
                    showCancelButton: false,
                    showConfirmButton: true,
                    allowEscapeKey: true,
                    closeOnClickOutside: true
                });
            },
            complete: function () { $('#preloader').hide(); },
        });
    });

    $(".btnDeleteFood").click(function (e) {

        var row = self.controls.grids.food.getCurrentRow($(this));

        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'mr-2 btn btn-danger'
            },
            buttonsStyling: false,
        })

        swalWithBootstrapButtons.fire({
            title: '¿Esta seguro?',
            text: "¡No podrás revertir esto!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Si, bórralo!',
            cancelButtonText: 'No, cancelar!',
            reverseButtons: true
        }).then((result) => {
            if (result.value) {

                $.ajax({
                    type: 'DELETE',
                    url: '/Food/DeleteItem/' + row.id,
                    dataType: '',
                    data: "",
                    async: true,
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
                    success: function (response) {
                        if (response.success == true) {
                            swalWithBootstrapButtons.fire(
                                'Eliminado!',
                                response.objectResult,
                                'success'
                            )

                            self.load();
                        } else {
                            Swal.fire({
                                title: "Operación incorrecta",
                                text: response.error.message,
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
                            text: "Lo sentimos, ha ocurrido un error",
                            type: "error",
                            showCancelButton: false,
                            showConfirmButton: true,
                            allowEscapeKey: true,
                            closeOnClickOutside: true
                        });
                    },
                    complete: function () {
                        $.unblockUI();
                    },
                });
            } else if (
                // Read more about handling dismissals
                result.dismiss === Swal.DismissReason.cancel
            ) {
                swalWithBootstrapButtons.fire(
                    'Cancelado',
                    'Tu plato esta seguro :)',
                    'error'
                )
            }
        })
    });

    $(".btnUpdateFood").click(function (e) {
        $('#updateFoodForm').validate({
            messages: {
                logo: {
                    required: "Campo obligatorio"
                },
                category: {
                    required: "Campo obligatorio"
                },
                name: {
                    required: "Campo obligatorio"
                },
                portion: {
                    required: "Campo obligatorio"
                },
                grams: {
                    required: "Campo obligatorio"
                },
                price: {
                    required: "Campo obligatorio"
                },
                description: {
                    required: "Campo obligatorio"
                },
            },
            submitHandler: function (form, event) {
                event.preventDefault();
                var formData = new FormData($(form)[0]);
                $.ajax({
                    url: form.action,
                    type: form.method,
                    data: formData,
                    async: false,
                    cache: false,
                    contentType: false,
                    processData: false,
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
                    success: function (response) {
                        if (response.success) {
                            var url = '/Food';
                            Swal.fire({
                                title: "Operación exitosa",
                                text: "Se actualizo el platillo exitosamente",
                                type: "success",
                                showCancelButton: false,
                                showConfirmButton: true,
                                allowEscapeKey: false,
                                closeOnClickOutside: false
                            }).then(function () {
                                // Redirect the user
                                window.location.href = url;
                            });

                            $("#detailsFoodModal").modal("hide");
                            //self.load();
                        }
                        else {
                            Swal.fire({
                                title: "Operación incorrecta",
                                text: response.error.message,
                                type: "error",
                                showCancelButton: false,
                                showConfirmButton: true,
                                allowEscapeKey: true,
                                closeOnClickOutside: true
                            });

                            $("#detailsFoodModal").modal("hide");
                            self.load();
                        }
                    },
                    error: function () {
                        Swal.fire({
                            title: "Operación incorrecta",
                            text: "Lo sentimos, ha ocurrido un error",
                            type: "error",
                            showCancelButton: false,
                            showConfirmButton: true,
                            allowEscapeKey: true,
                            closeOnClickOutside: true
                        });
                    },
                    complete: function () {
                        $.unblockUI();
                    },
                });
                //return false;
            }
        });
    });

};

PulAdmin.Food.prototype.addFoodHandlers = function () {

    var self = this;

    $('#createFoodForm').validate({
        messages: {
            logo: {
                required: "Campo obligatorio"
            },
            category: {
                required: "Campo obligatorio"
            },
            name: {
                required: "Campo obligatorio"
            },
            portion: {
                required: "Campo obligatorio"
            },
            grams: {
                required: "Campo obligatorio"
            },
            price: {
                required: "Campo obligatorio"
            },
            description: {
                required: "Campo obligatorio"
            },
        },
        submitHandler: function (form, event) {

            var formData = new FormData($(form)[0]);

            $.ajax({
                url: form.action,
                type: form.method,
                data: formData,
                async: false,
                cache: false,
                contentType: false,
                processData: false,
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
                success: function (response) {
                    if (response.success) {
                        var url = '/Food';

                        Swal.fire({
                            title: "Operación exitosa",
                            text: "Se ha creado el platillo exitosamente",
                            type: "success",
                            showCancelButton: false,
                            showConfirmButton: true,
                            allowEscapeKey: false,
                            closeOnClickOutside: false
                        }).then(function () {
                            // Redirect the user
                            window.location.href = url;
                        });
                    }
                    else {

                        Swal.fire({
                            title: "Operación incorrecta",
                            text: response.error.message,
                            type: "error",
                            showCancelButton: false,
                            showConfirmButton: true,
                            allowEscapeKey: true,
                            closeOnClickOutside: true
                        });
                    }
                },
                error: function (e) {
                    Swal.fire({
                        title: "Operación incorrecta",
                        text: "Lo sentimos, ha ocurrido un error",
                        type: "error",
                        showCancelButton: false,
                        showConfirmButton: true,
                        allowEscapeKey: true,
                        closeOnClickOutside: true
                    });
                },
                complete: function () {
                    $.unblockUI();
                },
            });
            return false;
        }
    });
};
