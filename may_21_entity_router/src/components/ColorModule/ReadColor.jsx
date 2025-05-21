import {Link, useParams} from "react-router";
import {readById} from "./ColorSimpleDb.js";

export function ReadColor() {

    const { id } = useParams();

    const color = readById(id);

    return(<>
        <h2>Read Color: {id}</h2>
        <Link to="/colors">Back</Link>
        <hr />
        <ul>
            <li>ID: {color.id}</li>
            <li>Name: {color.name}</li>
            <li>RGB: {color.rgb}</li>
        </ul>
    </>)

}