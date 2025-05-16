import {useState} from "react";
import './style.css'

export function RenderBack() {

    let classColor = ['black', 'white', 'red', 'green', 'blue'];

    const [colorSelected, setColorSelected]
        = useState(0);


    return (
        <div className={classColor[colorSelected]}>
            <h1>RenderBack</h1>
            <p>This is the RenderBack component.</p>
            <select value={colorSelected} onChange={(e) => setColorSelected(e.target.value)}>
                {classColor.map((color, index) => (
                    <option key={index} value={index}>
                        {color}
                    </option>
                ))}
            </select>
        </div>
    );

}