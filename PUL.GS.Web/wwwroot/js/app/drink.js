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
            self.configureHandlers();
        },
    });
};


PulAdmin.Drink.prototype.configureHandlers = function () {
    var self = this;

    $(".btnDetailsDrink").click(function (e) {

        var row = self.controls.grids.drink.getCurrentRow($(this));

        $.ajax({
            type: 'GET',
            url: '/Drink/GetDrinkDetails/' + row.id,
            dataType: '',
            data: "",
            async: true,
            beforeSend: function () { $('#preloader').show(); },
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                if (response.success === true) {
                    var food = response.objectResult;

                    $("#logo").val = "";
                    $("#imgDrink").attr("src", "");
                    $("#id").innerHTML = "";
                    $("#category").innerHTML = "";
                    $("#name").innerHTML = "";
                    $("#milliliters").innerHTML = "";
                    $("#grades").innerHTML = "";
                    $("#price").innerHTML = "";
                    $("#description").innerHTML = "";

                    $("#logo").attr("val", food.logo.name);
                    $("#imgDrink").attr("src", food.logo.uri);
                    $("#id").val(food.id);
                    $("#category").val(food.category);
                    $("#name").val(food.name);
                    $("#milliliters").val(food.milliliters);
                    $("#grades").val(food.grades);
                    $("#price").val(food.price);
                    $("#description").val(food.description);

                    $("#detailsDrinkModal").modal('show');
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

    $(".btnDeleteDrink").click(function (e) {

        var row = self.controls.grids.drink.getCurrentRow($(this));

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
                    url: '/Drink/DeleteItem/' + row.id,
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
                    'Tu bebida esta segura :)',
                    'error'
                )
            }
        })
    });

    $(".btnUpdateDrink").click(function (e) {
        $('#updateDrinkForm').validate({
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
                milliliters: {
                    required: "Campo obligatorio"
                },
                grades: {
                    required: "Campo obligatorio"
                },
                price: {
                    required: "Campo obligatorio"
                },
                stock: {
                    required: "Campo obligatorio"
                },
                description: {
                    requerid: "Campo obligatorio"
                }
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
                            var url = '/Drink';
                            Swal.fire({
                                title: "Operación exitosa",
                                text: "Se actualizo la bebida exitosamente",
                                type: "success",
                                showCancelButton: false,
                                showConfirmButton: true,
                                allowEscapeKey: false,
                                closeOnClickOutside: false
                            }).then(function () {
                                // Redirect the user
                                window.location.href = url;
                            });

                            $("#detailsDrinkModal").modal("hide");
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

                            $("#detailsDrinkModal").modal("hide");
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

PulAdmin.Drink.prototype.addDrinkHandlers = function () {

    var self = this;

    $('#createDrinkForm').validate({
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
            milliliters: {
                required: "Campo obligatorio"
            },
            grades: {
                required: "Campo obligatorio"
            },
            price: {
                required: "Campo obligatorio"
            },
            stock: {
                required: "Campo obligatorio"
            },
            description: {
                requerid: "Campo obligatorio"
            }
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
                        var url = '/Drink';

                        Swal.fire({
                            title: "Operación exitosa",
                            text: "Se ha creado la bebida exitosamente",
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