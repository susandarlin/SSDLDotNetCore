const tblBlog = "blogs";

readBlog();
// createBlog();
// updateBlog("9c36bc87-d724-4c93-9788-f5ab8fea9c96", "dsfgdret", "dwergtrtret", "ryrtyrty");
// deleteBlog("1a873a4a-b65f-4abf-a36f-e12f336249f7");
function readBlog(){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
}

function createBlog(){
    const blogs = localStorage.getItem(tblBlog);    

    let lst = [];
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }

    const requestModel =  {
        id: uuidv4(),
        title: "test title",
        author: "test author",
        content: "test content",
    };
    lst.push(requestModel);

    const jsonStr = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonStr);
}

function updateBlog(id, title, author, content){
    const blogs = localStorage.getItem(tblBlog);

    let lst = [];
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }

    const items = lst.filter(x=>x.id == id);
    console.log(items);
    if(items.length == 0){
        console.log("No data found.");
        return;
    }

    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(x=>x.id === id);
    lst[index] = item;

    const jsonStr = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonStr);
}

function deleteBlog(id){
    const blogs = localStorage.getItem(tblBlog);
    let lst = [];
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }

    const items = lst.filter(x=>x.id === id);
    if(items.length == 0){
        console.log("No data found.");
        return;
    }
    lst = lst.filter(x=>x.id !== id);
    const jsonStr = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonStr);
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
  }