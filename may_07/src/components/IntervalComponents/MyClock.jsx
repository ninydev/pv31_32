import React, {useState} from "react";

export function MyClock() {

    const [currentTime, setCurrentTime] = useState(new Date().toLocaleTimeString());
    const [intervalId, setIntervalId] = useState(null);

    const setCurrentTimeFun = () => {
        setCurrentTime(new Date().toLocaleTimeString());
    }

    const doStop = () => {
        if (intervalId === null) return;
        clearInterval(intervalId);
        setIntervalId(null);
    }

    const doStart = () => {
        if (intervalId !== null) return;
        let i = setInterval(setCurrentTimeFun, 1000);
        setIntervalId(i);
    }

    React.useEffect(() => {
        return () => {
            if (intervalId !== null) {
                console.log("Cleaning up");
                clearInterval(intervalId);
            }
        };
    }, [intervalId]);


    return(
        <div>
            <h1>My Clock</h1>
            <h2>{currentTime}</h2>
            <button onClick={doStop} disabled={intervalId===null}>Stop</button>
            <button onClick={doStart}  disabled={intervalId!==null}>Start</button>
        </div>
    )

}