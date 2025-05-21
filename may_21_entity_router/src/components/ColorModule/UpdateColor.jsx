import {Link, useParams} from "react-router";

export function UpdateColor() {

    const { id } = useParams();

    return(<>
        <h2>Update Color {id}</h2>
        <Link to="/colors">Back</Link>
        <hr />
    </>)

}