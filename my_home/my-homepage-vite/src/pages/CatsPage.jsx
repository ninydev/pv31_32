import {CatsList} from "../components/CatsApi/CatsList.jsx";
import {CatsProvider} from "../components/CatsApi/CatsContext.jsx";

export function CatsPage() {
    return (
        <div>
            <h1>Cats Page</h1>
            <p>Welcome to the Cats Page!</p>
            <CatsProvider>
                <CatsList />
            </CatsProvider>
        </div>
    );

}