
$(function () {

    bookStore.loadAllBooks();

});

var bookStore = {

    loadAllBooks: function () {

        $('#tblBooks').load("/Home/GetAllBooks", function () {
            $('#tblLogs').load("/Home/GetAllLogs");
        });


    },

    insertNewBook: function () {

        var data = $('#frmInsertBook').serialize();

        $.post("/Home/InsertNewBook", data, function (response) {
            console.log(response);
            if (response.Code == 1) {
                bookStore.loadAllBooks();
                $('#insertBookModal').modal('toggle');
            } else {
                alert(response.Message);
            }
        });

    },

    getBookDetail: function (isbn) {

        $('#frmUpdateBook').load("/Home/GetUpdateBookPartial", { 'isbn': isbn });

    },

    updateBook: function () {

        var data = $('#frmUpdateBook').serialize();

        $.post("/Home/UpdateBook", data, function (response) {
            if (response.Code == 1) {
                bookStore.loadAllBooks();
                $('#updateBookModal').modal('toggle');
            } else {
                alert(response.Message);
            }
        });

    },

    deleteBook: function (isbn) {

        $.post("/Home/DeleteBook", { 'isbn': isbn }, function (response) {
            if (response.Code == 1) {
                bookStore.loadAllBooks();
            } else {
                alert(response.Message);
            }
        });

    },

    borrowBookDetail: function (isbn) {

        $('#frmBorrowBook').load("/Home/GetBorrowBookPartial", { 'isbn': isbn });

    },

    borrowBook: function () {
        var data = $('#frmBorrowBook').serialize();

        $.post("/Home/BorrowBook", data, function (response) {
            if (response.Code == 1) {
                bookStore.loadAllBooks();
                $('#borrowBookModal').modal('toggle');
            } else {
                alert(response.Message);
            }
        });
    }
}
