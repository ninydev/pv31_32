
export function CatForm(props) {

    return (
        <div className="cat-form">
            <h2>Cat Form</h2>
            <form>
                <label htmlFor="id">Id:</label>
                <input type="text" id="id" name="id" required />

                <label htmlFor="name">Name:</label>
                <input type="text" id="name" name="name" required />

                <label htmlFor="image">Image URL:</label>
                <input type="url" id="image" name="image" required />

                <button type="submit">Add Cat</button>
            </form>
        </div>
    );

}