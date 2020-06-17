window.setTitle = (title) => {
    document.title = title + " - BlazorGames";
    document.getElementById("pageTitle").innerHTML = title;
}