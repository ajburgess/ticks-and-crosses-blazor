window.getBrowserId = () => {
    return window.localStorage.getItem("BROWSER_ID");
}

window.setBrowserId = (id) => {
    window.localStorage.setItem("BROWSER_ID", id);
}

window.beepAudio = new Audio("audio/beep.wav");
window.beepAudio.load();

window.playBeep = () => {
    window.beepAudio.play();
};
