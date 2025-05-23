import {Link} from "react-router";
import {create} from "./ColorSimpleDb.js";
import { useNavigate } from "react-router";


export function CreateColor() {

    const navigate = useNavigate();
    const handlerSubmit = (event) => {
        event.preventDefault();
        const formData = new FormData(event.target);
        const data = Object.fromEntries(formData.entries());
        console.log(data);
        create(data);
        event.target.reset();
        navigate("/colors");// <Link to="/colors">Back</Link>
    }

    return(<>
        <h2>Create Color</h2>
        <Link to="/colors">Back</Link>
        <hr/>
        <form onSubmit={handlerSubmit}>
            <label>
                Name:
                <input type="text" name="name" />
            </label>
            <br />
            <label>
                RGB:
                <input type="text" name="rgb" />
            </label>
            <br />
            <button type="submit">Create</button>
        </form>
    </>)

}