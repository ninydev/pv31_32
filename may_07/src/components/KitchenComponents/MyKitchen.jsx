import {useEffect, useState} from "react";
import {createCoffee, createEggs} from "./MyKitchenOperations.js";


export default function MyKitchen() {

    const [fryingPan, setFryingPan] = useState(true);
    const [turk, setTurk] = useState(true);
    const [eggs, setEggs] = useState(0);
    const [coffee, setCoffee] = useState(0);

    const [messages, setMessages] = useState([]);
    const addMessage = (msg) => {

        const now = new Date();
        msg = `${now.getHours()}:${now.getMinutes()}:${now.getSeconds()}` + " | " + msg;
        setMessages((prevMessages) => [...prevMessages, msg]);
        console.log(msg);
    }
    // const ulMsg = document.getElementById("msg");

    function onClickCreateCoffee() {
        createCoffee(turk, coffee, setCoffee, addMessage);
    }

    function onClickCreateEggs() {
        createEggs(fryingPan, eggs, setEggs, addMessage);
    }

    useEffect( () => {
        if( coffee < 200) {
            addMessage( "Not enough coffee - lest than 200 - go to shop");
        }
    }, [coffee]);

    useEffect( () => {
        if( eggs < 2) {
            addMessage( "Not enough eggs - lest than 2 - go to shop");
        }
    }, [eggs]);

    useEffect( () => {
        if( fryingPan) {
            addMessage( "Frying pan is available");
        } else {
            addMessage( "Frying pan is not available");
        }
        if( turk) {
            addMessage( "Turk is available");
        } else {
            addMessage( "Turk is not available");
        }
    }, [fryingPan, turk]);

/*
    // Bad practice
    const addMessage = (msg) => {
        ulMsg.innerHTML += "<li>" + msg + "</li>";
        console.log(msg);
    }

    const makeCoffee = () => {
        if (!turk) {
            addMessage( "Turk is not available");
            return;
        }

        if (coffee < 200) {
            addMessage( "Not enough coffee");
            return;
        }

        setCoffee(coffee - 200);
        addMessage( "Coffee is ready");
    }
*/

    return (
        <div className="kitchen">
            <h1>My Kitchen</h1>
            <div id="buttons">
                <button onClick={onClickCreateCoffee} disabled={!turk || coffee < 200}>Create Coffee</button>
                <button onClick={onClickCreateEggs} disabled={!fryingPan || eggs < 2}>Create Eggs</button>
                <br />
                <button onClick={() => setFryingPan(!fryingPan)}>Toggle Frying Pan</button>
                <button onClick={() => setTurk(!turk)}>Toggle Turk</button>
                <br />
                <button onClick={() => setEggs(eggs + 1)}>Add Egg</button>
                <button onClick={() => setCoffee(coffee + 100)}>Add Coffee</button>

            </div>

            <h3> State </h3>
            <ul>
                <li>FryingPan {fryingPan ? "есть" : "нету"}</li>
                <li>turk {turk ? "есть" : "нету"}</li>
                <li>eggs {eggs}</li>
                <li>coffee {coffee}</li>
            </ul>
            <h3> Messages </h3>
            <ul id="msg">
                {messages.map((msg, index) => (
                    <li key={index}>{msg}</li>
                ))}
            </ul>

        </div>
    )

}