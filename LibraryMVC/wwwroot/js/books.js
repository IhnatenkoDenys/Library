var BookHandler = function () {
    var root = this;

    root.constructor = function () {

    };

    root.GetAll = async function () {
        const response = await fetch("/api/book", {
            method: "GET",
            headers: { "Accept": "application/json" }
        });

        if (response.ok == true) {
            const books = await response.json();
            let rows = document.querySelector("tbody");
            books.forEach(book => {
                rows.append(rowMethod(book));
            });
        }
    }

    root.SearchBook = async function (title, releaseDate) {
        const response = await fetch("/api/book/search/", {
            method: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "title": title,
                "releaseDate": releaseDate == '' ? null : releaseDate
            })
        });

        if (response.ok == true) {
            $("tbody").children().remove();
            const books = await response.json();
            let rows = document.querySelector("tbody");
            books.forEach(book => {
                rows.append(rowMethod(book));
            });
        }
    }

    root.DeleteBook = async function (id) {
        const response = await fetch("api/book/" + id, {
            method: "DELETE",
            headers: { "Accept": "application/json" }
        });

        if (response.ok == true) {
            const id = await response.json();
            document.querySelector("tr[data-rowid='" + id + "']").remove();
        }
    }

    // private method
    var rowMethod = function (book) {

        const tr = document.createElement("tr");
        tr.setAttribute("data-rowid", book.id);

        const idTd = document.createElement("td");
        idTd.append(book.id);
        tr.append(idTd);

        const titleTd = document.createElement("td");
        titleTd.append(book.title);
        tr.append(titleTd);

        const publisherTd = document.createElement("td");
        if (book.publisher != null) {
            publisherTd.append(book.publisher.name);
        }
        tr.append(publisherTd);

        const releaseDateTd = document.createElement("td");
        if (book.releaseDate != null) {
            releaseDateTd.append(book.releaseDate.substr(0, 10));
        }
        tr.append(releaseDateTd);

        const linksTd = document.createElement("td");

        const editLink = document.createElement("a");
        editLink.setAttribute("data-id", book.id);
        editLink.setAttribute("href", "/BookMvc/AddEdit/" + book.id);
        editLink.setAttribute("style", "cursor:pointer;padding:15px;");
        editLink.append("Edit");
        linksTd.append(editLink);

        const removeLink = document.createElement("a");
        removeLink.setAttribute("data-id", book.id);
        removeLink.setAttribute("style", "cursor:pointer;padding:15px;color:red;");
        removeLink.append("Delete");
        removeLink.addEventListener("click", e => {
            e.preventDefault();
            if (confirm('Are you sure you want to delete this book?')) {
                root.DeleteBook(book.id);
            }
        });

        linksTd.append(removeLink);
        tr.appendChild(linksTd);

        return tr;
    }
}

document.bookForm.search.addEventListener("click", e => {
    e.preventDefault();
    const title = document.bookForm.title.value;
    const releaseDate = document.bookForm.releaseDate.value;
    var bookHandler = new BookHandler();
    bookHandler.SearchBook(title, releaseDate);
});

// reset form
document.bookForm.reset.addEventListener("click", e => {
    e.preventDefault();
    const form = document.bookForm;
    form.id.value = 0;
    form.title.value = "";
    form.releaseDate.value = null;

    $("tbody").children().remove();
    //document.querySelector("tbody").innerHTML = '';

    var bookHandler = new BookHandler();
    bookHandler.GetAll();
});

document.bookForm.addNew.addEventListener("click", e => {
    e.preventDefault();
    $(location).attr('href', '/BookMvc/AddEdit/');
});
