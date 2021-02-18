window.setTitle = (title) => {
    document.title = title + " - BlazorGames";
}

window.SetFocusToElement = (element) => {
    element.focus();
};

window.PlayAudio = (elementName) => {
    document.getElementById(elementName).play();
}