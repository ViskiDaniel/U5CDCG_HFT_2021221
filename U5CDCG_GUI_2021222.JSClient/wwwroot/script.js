let books = [];
let connection=null;
getdata();
setupsignalr();

let bookidtoupdate = -1;

async function getdata() {
    await fetch('http://localhost:64653/book').then(x => x.json()).then(y => {
        books = y;        
        display();
    });
}

function setupsignalr() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:64653/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on
        (
            "BookCreated", (user, message) => {
                getdata();
        });


    connection.on
        (
            "BookDeleted", (user, message) => {
                getdata();
        });

    connection.on
        (
            "BookUpdated", (user, message) => {
                getdata();
            });

    connection.onclose
        (async () => {
            await start();
        });
    start();

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

function showupdate(id) {
    document.getElementById('bookauthortoupdate').value = books.find(x => x['bookId'] == id)['author'];
    document.getElementById('booktitletoupdate').value = books.find(x => x['bookId'] == id)['title'];
    document.getElementById('updateformdiv').style.display = 'flex';
    bookidtoupdate = id;
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    books.forEach(x => {
        document.getElementById('resultarea').innerHTML += "<tr><td>" + x.author + "</td><td>" + x.title + "</td><td>" + `<button type="button" onclick="remove(${x.bookId})">Delete</button>` + `<button type="button" onclick="showupdate(${x.bookId})">Update</button>` + "</td></tr>"
        console.log(x.title);
    });
}

function remove(id){
    fetch('http://localhost:64653/book/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body:null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function create() {
    let aauthor = document.getElementById("bookauthor").value;
    let ttitle = document.getElementById("booktitle").value;

    fetch('http://localhost:64653/book', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                author:aauthor,
                title:ttitle
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

    
}

function update() {
    document.getElementById('updateformdiv').style = 'none';
    let aauthor = document.getElementById("bookauthortoupdate").value;
    let ttitle = document.getElementById("booktitletoupdate").value;

    fetch('http://localhost:64653/book', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                author: aauthor,
                title: ttitle,
                bookId: bookidtoupdate
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });


}