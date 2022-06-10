const mainPage = document.getElementById("html");

// Theme Vars
const userTheme = localStorage.getItem("theme");


const themeSwitch = (theme) => {
    switch (theme) {
        case "light":
            mainPage.setAttribute('data-theme', theme);
            localStorage.setItem('theme', theme);
            break;
        case "dark":
            mainPage.setAttribute('data-theme', theme);
            localStorage.setItem('theme', theme);
            break;
        case "dracula":
            mainPage.setAttribute('data-theme', theme);
            localStorage.setItem('theme', theme);
            break;
        case "pastel":
            mainPage.setAttribute('data-theme', theme);
            localStorage.setItem('theme', theme);
            break;
        case "coffee":
            mainPage.setAttribute('data-theme', theme);
            localStorage.setItem('theme', theme);
            break;
        case "business":
            mainPage.setAttribute('data-theme', theme);
            localStorage.setItem('theme', theme);
            break;
        case "luxury":
            mainPage.setAttribute('data-theme', theme);
            localStorage.setItem('theme', theme);
            break;
        case "aqua":
            mainPage.setAttribute('data-theme', theme);
            localStorage.setItem('theme', theme);
            break;
        case "retro":
            mainPage.setAttribute('data-theme', theme);
            localStorage.setItem('theme', theme);
            break;
        case "synthwave":
            mainPage.setAttribute('data-theme', theme);
            localStorage.setItem('theme', theme);
            break;
        case "cupcake":
            mainPage.setAttribute('data-theme', theme);
            localStorage.setItem('theme', theme);
            break;
        case "emerald":
            mainPage.setAttribute('data-theme', theme);
            localStorage.setItem('theme', theme);
            break;
        case "night":
            mainPage.setAttribute('data-theme', theme);
            localStorage.setItem('theme', theme);
            break;
    };
};


// Initial Theme Check
const themeCheck = () => {
    if (!userTheme) {
        mainPage.setAttribute('data-theme', 'night');
        localStorage.setItem('theme', 'night');
        return;
    }

    mainPage.setAttribute('data-theme', userTheme);
};

// Invoke Theme Check on Initial Load
themeCheck();


function loadDetails(x) {
    $("#detailHolder").html('<img src="https://i.stack.imgur.com/PzC1L.gif" width="200px" class="text-center p-4 mx-auto" />');

    $.ajax({
        url: "/Notes/NoteDetails",
        data: { id: x },
        type: "GET",
        success: function (data) {
            $("#detailHolder").html(data);
        }
    });
}

function closeDetails() {
    $("#detailHolder").html('');
}


function loadEdit(x) {
    $("#detailHolder").html('<img src="https://i.stack.imgur.com/PzC1L.gif" width="200px" class="text-center p-4 mx-auto" />');

    $.ajax({
        url: "/Notes/GetEdit",
        data: { id: x },
        type: "GET",
        success: function (data) {
            $("#detailHolder").html(data);
        }
    });
}

function loadDelete(x) {
    $("#detailHolder").html('<img src="https://i.stack.imgur.com/PzC1L.gif" width="200px" class="text-center p-4 mx-auto" />');

    $.ajax({
        url: "/Notes/GetDelete",
        data: { id: x },
        type: "GET",
        success: function (data) {
            $("#detailHolder").html(data);
        }
    });
}

function loadCreate() {
    $("#detailHolder").html('<img src="https://i.stack.imgur.com/PzC1L.gif" width="200px" class="text-center p-4 mx-auto" />');

    $.ajax({
        url: "/Notes/GetCreate",
        type: "GET",
        success: function (data) {
            $("#detailHolder").html(data);
        }
    });
}


