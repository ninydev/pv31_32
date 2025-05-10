
function addMessage(ulMsg, msg) {
    ulMsg.innerHTML += "<li>" + msg + "</li>";
    console.log(msg);

}

function createCoffee(turk, coffee, setCoffee, ulMsg) {

    if (!turk) {
        addMessage(ulMsg, "Turk is not available");
        return;
    }

    if (coffee < 200) {
        addMessage(ulMsg, "Not enough coffee");
        return;
    }

    setCoffee(coffee - 200);
    addMessage(ulMsg, "Coffee is ready");

}

export {createCoffee}