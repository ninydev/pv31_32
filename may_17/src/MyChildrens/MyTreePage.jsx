import {MyChild} from "./MyChild.jsx";
import {MyParent} from "./MyParent.jsx";
import {MyDataProvider} from "./MyDataProvider.jsx";

export function MyTreePage() {

    return(
        <div>
            <h1>My Tree Page</h1>
            <p>My Tree Page</p>
            <MyDataProvider>
                <MyParent>
                    <MyChild />
                    <MyChild />
                    <MyChild />
                </MyParent>
            </MyDataProvider>

        </div>
    )

}