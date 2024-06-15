const tblBlog = "blogs";
let blogId = null;

getBlogTable();
// testConfirmMessage();
// readBlog();
// createBlog();
// updateBlog("9c36bc87-d724-4c93-9788-f5ab8fea9c96", "dsfgdret", "dwergtrtret", "ryrtyrty");
// deleteBlog("1a873a4a-b65f-4abf-a36f-e12f336249f7");

function testConfirmMessage() {
    let confirmMessage = new Promise(function (success, error) {
        // "Producing Code" (May take some time)
        Swal.fire({
            title: "Confirm",
            text: "Are you sure to delete?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes"
        }).then((result) => {
            if (result.isConfirmed) {
                success(); // when successful
            } else {
                error();  // when error
            }
        });
    });

    // "Consuming Code" (Must wait for a fulfilled Promise)
    confirmMessage.then(
        function (value) {
            /* code if successful */
            successMessage("Success")
        },
        function (error) {
            /* code if some error */
            errorMessage("Error")
        }
    );
}

function testConfirmMessage2() {
    let confirmMessage = new Promise(function (success, error) {
        // "Producing Code" (May take some time)

        const result = confirm("Are you sure!");
        if (result) {
            success(); // when successful
        } else {
            error();  // when error
        }
    });

    // "Consuming Code" (Must wait for a fulfilled Promise)
    confirmMessage.then(
        function (value) {
            /* code if successful */
            successMessage("Success")
        },
        function (error) {
            /* code if some error */
            errorMessage("Error")
        }
    );
}
function readBlog() {
    let lst = getBlogs();
    console.log(lst);
}

function editBlog(id) {
    let lst = getBlogs();
    const items = lst.filter(x => x.id === id);

    if (items.length == 0) {
        errorMessage("No data found.");
        return;
    }

    const item = items[0];
    blogId = item.id;
    $('#txtTitle').val(item.title);
    $('#txtAuthor').val(item.author);
    $('#txtContent').val(item.content);
    $('#txtTitle').focus();
}

function createBlog(title, author, content) {
    let lst = getBlogs();

    const requestModel = {
        id: uuidv4(),
        title: title,
        author: author,
        content: content,
    };
    lst.push(requestModel);

    const jsonStr = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonStr);

    successMessage("Saving Successful.")
    clearControls();
}

function updateBlog(id, title, author, content) {
    let lst = getBlogs();

    const items = lst.filter(x => x.id == id);
    console.log(items);
    if (items.length == 0) {
        console.log("No data found.");
        return;
    }

    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(x => x.id === id);
    lst[index] = item;

    const jsonStr = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonStr);

    successMessage('Updating Successful.');
}

function deleteBlog2(id) {
    const result = confirm('Are you sure to delete?')
    if (!result) return;

    let lst = getBlogs();

    const items = lst.filter(x => x.id === id);
    if (items.length == 0) {
        console.log("No data found.");
        return;
    }
    lst = lst.filter(x => x.id !== id);
    const jsonStr = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonStr);

    successMessage('Deleting Successful.');

    getBlogTable();
}

function deleteBlog3(id) {
    Swal.fire({
        title: "Confirm",
        text: "Are you sure to delete?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes"
    }).then((result) => {
        if (!result.isConfirmed) return;
        let lst = getBlogs();

        const items = lst.filter(x => x.id === id);
        if (items.length == 0) {
            console.log("No data found.");
            return;
        }
        lst = lst.filter(x => x.id !== id);
        const jsonStr = JSON.stringify(lst);
        localStorage.setItem(tblBlog, jsonStr);
        successMessage('Deleting Successful.');

        getBlogTable();
    });
}

function deleteBlog(id) {
    confirmMessage("Are you sure want to delete?").then(
        function (value) {
            /* code if successful */
            let lst = getBlogs();

            const items = lst.filter(x => x.id === id);
            if (items.length == 0) {
                console.log("No data found.");
                return;
            }
            lst = lst.filter(x => x.id !== id);
            const jsonStr = JSON.stringify(lst);
            localStorage.setItem(tblBlog, jsonStr);
            successMessage('Deleting Successful.');

            getBlogTable();
        }
    );

}

function getBlogs() {
    const blogs = localStorage.getItem(tblBlog);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    return lst;
}

$('#btnSave').click(function () {
    const title = $('#txtTitle').val();
    const author = $('#txtAuthor').val();
    const content = $('#txtContent').val();

    if (blogId === null) {
        createBlog(title, author, content);
    }
    else {
        updateBlog(blogId, title, author, content);
        blogId = null;
    }
    getBlogTable();
})

function clearControls() {
    $('#txtTitle').val('');
    $('#txtAuthor').val('');
    $('#txtContent').val('');
    $('#txtTitle').focus();
}

function getBlogTable() {
    const lst = getBlogs();
    let count = 0;
    let htmlRows = '';
    lst.forEach(item => {
        const htmlRow = `
        <tr>
            <td>
                <button type="button" class="btn btn-warning" onClick="editBlog('${item.id}')">Edit</button>
                <button type="button" class="btn btn-danger" onClick="deleteBlog('${item.id}')">Delete</button>
            </td>
            <td>${++count}</td>
            <td>${item.title}</td>
            <td>${item.author}</td>
            <td>${item.content}</td>
        </tr>
        `;
        htmlRows += htmlRow;
    });

    $('#tbody').html(htmlRows);
}