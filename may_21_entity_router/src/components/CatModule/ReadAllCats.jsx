import {useCats} from "./CatsContext.jsx";

export const ReadAllCats = () => {

    const cats = useCats();

    const newOrder = (e) => {
        e.preventDefault();
        const order = e.target.value;
        cats.setOrder(order);
    }

    const newSort = (e) => {
        e.preventDefault();
        const sortBy = e.target.value;
        cats.setSortBy(sortBy);
    }




    return(
        <div>
            <h1>Read All Cats</h1>
            <p>This component will display all cats.</p>
            <div><label>Sort By:
                <select onChange={newSort}>
                    <option value="id">ID</option>
                    <option value="name">Name</option>
                    <option value="breed">Breed</option>
                </select>
            </label></div>

            <div><label>Order:
                <select onChange={newOrder}>
                    <option value="asc">Ascending</option>
                    <option value="desc">Descending</option>
                </select>
            </label></div>

            <div>
                <label>Page: {cats.page}</label> |
                <label>Limit: {cats.limit}</label>
            </div>

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