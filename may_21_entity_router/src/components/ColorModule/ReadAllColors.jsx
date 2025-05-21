import {Link} from "react-router";
import {readAll} from "./ColorSimpleDb.js";
import {useState} from "react";

export function ReadAllColors() {

    // const [colors, setColors] = useState([]);
    //
    // setColors(readAll())

    const colors = readAll();

    return(<>
        <h2>Read All Color</h2>
        <Link to="/colors/create">Create Color</Link>
        <hr/>
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>RGB</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {colors.map((color) => (
                    <tr key={color.id}>
                        <td>{color.id}</td>
                        <td>{color.name}</td>
                        <td>{color.rgb}</td>
                        <td>
                            <Link to={`/colors/read/${color.id}`}>Read</Link> |
                            <Link to={`/colors/update/${color.id}`}>Update</Link> |
                            <Link to={`/colors/delete/${color.id}`}>Delete</Link>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>

    </>)

}