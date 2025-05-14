import {CatsList} from "./CatsList.jsx";
import {CatForm} from "./CatForm.jsx";
import {useState} from "react";


export function CatsPage() {

    const [cats, setCats] = useState([])

    const addCat = (cat) => {
        setCats((prevCats) => [...prevCats, cat]);
    }

    return(
        <div className="cats-page">
            <h1>Cats Database</h1>
            <CatsList cats={cats} />
            <CatForm addCat={addCat} />
        </div>
    )

}