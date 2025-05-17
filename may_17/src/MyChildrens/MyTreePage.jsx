import {MyChild} from "./MyChild.jsx";
import {MyParent} from "./MyParent.jsx";

export function MyTreePage() {

    return(
        <div>
            <h1>My Tree Page</h1>
            <p>My Tree Page</p>
            <MyParent>
                <MyChild />
                <MyChild />
                <MyChild />
            </MyParent>
        </div>
    )

}