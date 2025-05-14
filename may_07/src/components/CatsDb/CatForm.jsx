export function CatForm(props) {

    const { addCat } = props;

    const handleSubmit = (event) => {
        event.preventDefault();

        // const form = event.target;
        // const id = form.id.value;
        // const name = form.name.value;
        // const image = form.image.value;
        //
        // const newCat = {
        //     id,
        //     name,
        //     image
        // };

        const formData = new FormData(event.target);
        const formObject = Object.fromEntries(formData.entries());

        addCat(formObject);
        event.target.reset();
    }

    return (
        <div className="cat-form">
            <h2>Cat Form</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="id">Id:</label>
                    <input type="text" id="id" name="id" required/>
                </div>
                <div>
                    <label htmlFor="name">Name:</label>
                    <input type="text" id="name" name="name" required/>
                </div>
                <div>
                    <label htmlFor="image">Image URL:</label>
                    <input type="url" id="image" name="image" required/>
                </div>
                <div>
                    <button type="submit">Add Cat</button>
                </div>
            </form>
        </div>
    );

}