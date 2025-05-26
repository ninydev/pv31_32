import {useCats} from "./CatsContext.jsx";

export const ReadAllCats = () => {

    const cats = useCats();



    return(
        <div>
            <h1>Read All Cats</h1>
            <p>This component will display all cats.</p>
            <table width={"100%"} style={ {borderCollapse: "collapse"}}>
                <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Breed</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                {cats.cats.map(cat => (
                    <tr key={cat.id}>
                        <td>{cat.id}</td>
                        <td>{cat.name}</td>
                        <td>{cat.breed}</td>
                        <td>
                            <button onClick={() => cats.deleteCat(cat.id)}>Delete</button>
                        </td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
}