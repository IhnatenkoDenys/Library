var BookAddEditHandler = function () {
    var root = this;

    root.construct = function () {

    };

    root.GetBook = async function (id) {
        const response = await fetch("/api/book/" + id, {
            method: "GET",
            headers: {"Accept": "application/json"}
        });
        if (response.ok == true) {
            const book = await response.json();
            $("#title").val(book.title);
            $("#releaseDate").val(book.releaseDate.substr(0, 10));
        }
    }

    root.AddUpdateBook = async function () {
        var idVal = $("#idtxt").attr("value");
        var publisherId = $("#publisherId").val();
        var actionMethod = idVal == 0 ? "POST" : "PUT";

        const response = await fetch("/api/book/", {
            method: actionMethod,
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "id": parseInt(idVal),
                "title": $("#title").val(),
                "releaseDate": $("#releaseDate").val(),
                "publisherId": parseInt(publisherId),
                "copiesNumber" : 100
            })
        });

        if (response.ok == true) {
            alert("The book was saved successfully!");
            $(location).attr('href', '/book.html');
        }
    }
}

document.bookForm.save.addEventListener("click", e => {
    e.preventDefault();
    var bookAddEditHandler = new BookAddEditHandler();
    bookAddEditHandler.AddUpdateBook();
});