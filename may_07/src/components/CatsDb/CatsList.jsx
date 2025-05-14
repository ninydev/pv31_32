import {CatItem} from "./CatItem.jsx";

export function CatsList(props) {

    const { cats } = props;

    return(
        <div className="cats-list">
            <h2>Cat List</h2>
            <ul>
                {cats.map((cat) => (
                    <CatItem key={cat.id} cat={cat} />
                ))}
            </ul>
        </div>
    )
}