import {useParams} from "react-router";

export function ReadColor() {

    const { id } = useParams();

    return(<>
        <h1>Read Color: {id}</h1>
    </>)

}