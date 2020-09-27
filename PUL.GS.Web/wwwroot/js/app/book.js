PulAdmin.Book = function () {
};

PulAdmin.Book.prototype.init = function () {
    var self = this;
    var controls = PulAdmin.Controls.Book;
    this.controls = {
        grids: {
            book: new controls.Grid('grdBooks')
        }
    };
    this.controls.grids.book.init();
    self.load();
};

PulAdmin.Book.prototype.load = function () {
    var self = this;

    //var generalReportsStatusBooks = function () {
        $.ajax({
            type: 'POST',
            url: '/Book/GeneralReportStatusBooks',
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
                    //self.controls.grids.combo.loadRows(data);

                    var booksStates = data.objectResult;

                    $("#bookPending").text(booksStates[0].count);
                    $("#bookAccept").text(booksStates[1].count);
                    $("#bookInProcess").text(booksStates[2].count);
                    $("#bookFinished").text(booksStates[3].count);

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

    //}

    //var getListBooksByBookState = function () {

        $.ajax({
            type: 'POST',
            url: '/Book/GetListBooksByBookState',
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
                    self.controls.grids.book.loadRows(data);
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
    //}

    //$("#subCategory\\.id").change(function () {
    //    getListBooksByBookState();
    //});
};


var updateBook = function (Id, statusBook) {
    var book = JSON.stringify({
        "id": Id,
        "BookStatus": statusBook
    });

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '/Book/UpdateBook',
        dataType: "json",
        data: book,
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
       
        success: function (data) {
            if (data.success == true) {
                //self.controls.grids.book.loadRows(data);
                window.location.href = "/book/index";
            } else {
                var error = data.error;
                Swal.fire({
                    title: error.message,
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
}