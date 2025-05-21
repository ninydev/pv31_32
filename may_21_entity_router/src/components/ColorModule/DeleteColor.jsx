import {Link, useParams} from "react-router";

export function DeleteColor() {

    const { id } = useParams();

    return(<>
        <h2>Delete Color {id}</h2>
        <Link to="/colors">Back</Link>
        <hr />
        </>)

}