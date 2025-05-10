import {useState} from "react";
import {createCoffee} from "./MyKitchenOperations.js";


export default function MyKitchen() {

    const [fryingPan, setFryingPan] = useState(false);
    const [turk, setTurk] = useState(false);
    const [eggs, setEggs] = useState(0);
    const [coffee, setCoffee] = useState(0);

    const ulMsg = document.getElementById("msg");

    function onClickCreateCoffee() {
        createCoffee(turk, coffee, setCoffee, ulMsg);
    }


    return (
        <div className="kitchen">
            <h1>My Kitchen</h1>
            <div id="buttons">
                <button onClick={onClickCreateCoffee}>Create Coffee</button>

            </div>

            <h3> State </h3>
            <ul>
                <li>FryingPan {fryingPan}</li>
                <li>turk {turk}</li>
                <li>eggs {eggs}</li>
                <li>coffee {coffee}</li>
            </ul>
            <h3> Messages </h3>
            <ul id="msg">

            </ul>

        </div>
    )

}