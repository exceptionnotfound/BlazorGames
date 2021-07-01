function faceOooh(event) {
    if (event.button === 0) {
        document.getElementById("face").className = "minesweeper-face-oooh";
    }
}

function faceSmile() {
    var face = document.getElementById("face");
    
    if (face !== undefined)
        face.className = "minesweeper-face-smile";
}

function setTime(hundreds, tens, ones) {
    var hundredsElement = document.getElementById("seconds_hundreds");
    var tensElement = document.getElementById("seconds_tens");
    var onesElement = document.getElementById("seconds_ones");

    if (hundredsElement !== null) {
        hundredsElement.className = "minesweeper-time-" + hundreds;
    }
    if (tensElement !== null) {
        tensElement.className = "minesweeper-time-" + tens;
    }
    if (onesElement !== null) {
        onesElement.className = "minesweeper-time-" + ones;
    }
}