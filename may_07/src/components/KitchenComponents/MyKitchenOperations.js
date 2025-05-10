
// function addMessage(ulMsg, msg) {
//     ulMsg.innerHTML += "<li>" + msg + "</li>";
//     console.log(msg);
//
// }

function createCoffee(turk, coffee, setCoffee, addMessage) {

    if (!turk) {
        addMessage("Turk is not available");
        return;
    }

    if (coffee < 200) {
        addMessage("Not enough coffee");
        return;
    }

    setCoffee(coffee - 200);
    addMessage("Coffee is ready");

}

function createEggs(fryingPan, eggs, setEggs, addMessage) {

    if (!fryingPan) {
        addMessage("Frying pan is not available");
        return;
    }

    if (eggs < 2) {
        addMessage( "Not enough eggs");
        return;
    }

    setEggs(eggs - 2);
    addMessage( "Eggs are ready");
}

export {createCoffee, createEggs}