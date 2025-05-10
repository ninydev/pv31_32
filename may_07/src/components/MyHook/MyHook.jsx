import {useEffect, useState} from "react";


export default function MyHook() {
    console.log("MyHook - start function");

    const authorName = "John Doe";

    let a = 1;
    // console.log(`start a = ${a}`);

    let [b, setB] = useState(1)
    // console.log(`start b = ${b}`);

    let [c, setC] = useState(1)

    useEffect(() => {
        console.log("MyHook - useEffect");
        if (b > 10) {
            console.log("MyHook - useEffect - b > 10");
            setB(b - 1);
        }
    }, [c])


    const increment = () => {
      a++;
      //console.log(`inc a = ${a}`);

      setB(b + 1);
      if (b % 2 === 0) {
        setC(c + 1);
      }
      //console.log(`inc b = ${b}`);
    }

    return (<>
            <h1>MyHook</h1>
        <p>{authorName}</p>
        <ul>
            <li>a = {a}</li>
            <li>b = {b}</li>
        </ul>
        <button onClick={increment}> Increment </button>
        </>)
}