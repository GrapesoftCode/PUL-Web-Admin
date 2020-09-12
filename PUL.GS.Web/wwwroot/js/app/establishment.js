
var form = $(".validation-wizard").show();


var block_ele = $(this).closest('.card');

$(".validation-wizard").steps({
    headerTag: "h6",
    bodyTag: "section",
    transitionEffect: "fade",
    titleTemplate: '<span class="step">#index#</span> #title#',
    labels: {
        finish: "Terminar",
        next: "Siguiente",
        previous: "Anterior",
        loading: "Cargando ..."
    },
    onStepChanging: function (event, currentIndex, newIndex) {
        return currentIndex > newIndex || !(3 === newIndex && Number($("#age-2").val()) < 18) && (currentIndex < newIndex && (form.find(".body:eq(" + newIndex + ") label.error").remove(), form.find(".body:eq(" + newIndex + ") .error").removeClass("error")), form.validate().settings.ignore = ":disabled,:hidden", form.valid())
    },
    onFinishing: function (event, currentIndex) {
        return form.validate().settings.ignore = ":disabled", form.valid()
    },
    onFinished: function (event, currentIndex) {
        //Swal.fire("Form Submitted!", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed lorem erat eleifend ex semper, lobortis purus sed.");
        var form = $(this);
        form.submit();
    }
}), $(".validation-wizard").validate({
    ignore: "input[type=hidden]",
    errorClass: "text-danger",
    successClass: "text-success",
    highlight: function (element, errorClass) {
        $(element).removeClass(errorClass)
    },
    unhighlight: function (element, errorClass) {
        $(element).removeClass(errorClass)
    },
    errorPlacement: function (error, element) {
        error.insertAfter(element)
    },
    rules: {
        name: {
            required: true
        },
        type: {
            required: true
        },
        musicalGenre: {
            required: true
        },
        costLevel: {
            required: true
        },
        rfc: {
            required: true
        },
        email: {
            email: !0
        },
        phoneNumber: {
            required: true
        },
        //cover: {
        //    required: true
        //},
        "address.country": {
            required: true
        },
        "address.cp": {
            required: true
        },
        "address.state": {
            required: true
        },
        "address.municipality": {
            required: true
        },
        "address.neighborhood": {
            required: true
        },
        "address.street": {
            required: true
        },
        "address.outdoorNumber": {
            required: true
        },
        "address.interiorNumber": {
            required: true
        },
        "fiscalAddress.country": {
            required: true
        },
        "fiscalAddress.cp": {
            required: true
        },
        "fiscalAddress.state": {
            required: true
        },
        "fiscalAddress.municipality": {
            required: true
        },
        "fiscalAddress.neighborhood": {
            required: true
        },
        "fiscalAddress.street": {
            required: true
        },
        "fiscalAddress.outdoorNumber": {
            required: true
        },
        "fiscalAddress.interiorNumber": {
            required: true
        },
        logo: {
            required: true
        }

    },
    messages: {
        name: {
            required: "Establecimiento requerido"
        },
        type: {
            required: "Establecimiento requerido"
        },
        musicalGenre: {
            required: "Establecimiento requerido"
        },
        costLevel: {
            required: "Establecimiento requerido"
        },
        rfc: {
            required: "RFC requerido"
        },
        email: {
            email: "Email no valido",
            required: "Email requerido"
        },
        phoneNumber: {
            required: "Teléfono requerido"
        },
        //cover: {
        //    required: "Cover requerido"
        //},
        "address.country": {
            required: "País requerido"
        },
        "address.cp" : {
            required: "Código Postal requerido"
        },
        "address.state" : {
            required: "Eatado requerido"
        },
        "address.municipality" : {
            required: "Municipio/Delegación requerido"
        },
        "address.neighborhood": {
            required: "Colonia requerido"
        },
        "address.street": {
            required: "Calle requerido"
        },
        "address.outdoorNumber": {
            required: "Número Estarior requerido"
        },
        "address.interiorNumber": {
            required: "Número Interior requerido"
        },
        "fiscalAddress.country": {
            required: "País requerido"
        },
        "fiscalAddress.cp": {
            required: "Código Postal requerido"
        },
        "fiscalAddress.state": {
            required: "Eatado requerido"
        },
        "fiscalAddress.municipality": {
            required: "Municipio/Delegación requerido"
        },
        "fiscalAddress.neighborhood": {
            required: "Colonia requerido"
        },
        "fiscalAddress.street": {
            required: "Calle requerido"
        },
        "fiscalAddress.outdoorNumber": {
            required: "Número Estarior requerido"
        },
        "fiscalAddress.interiorNumber": {
            required: "Número Interior requerido"
        },
        logo: {
            required: "Logo requerido"
        }
    },
    submitHandler: function (form) {
        var formData = new FormData($(form)[0]);
        $.ajax({
            url: form.action,
            type: form.method,
            data: formData,
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
            async: false,
            cache: false,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.success) {
                    var url = "/Establishment/Profile";
                    Swal.fire({
                        title: "Operación exitosa",
                        text: "Se ha creado el establecimiento exitosamente",
                        type: "success",
                        showCancelButton: false,
                        showConfirmButton: true,
                        allowEscapeKey: false,
                        closeOnClickOutside: false
                    }).then(function () {
                        // Redirect the user
                        window.location.href = url;
                    });

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
            error: (jqXHR, textStatus, errorThrown) => {
                Swal.fire({
                    title: "Operación incorrecta",
                    text: "",
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
        return false;
    }
});