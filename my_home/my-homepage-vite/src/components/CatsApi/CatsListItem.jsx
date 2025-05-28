
export function CatsListItem(props) {
    const { cat } = props;

    return (
        <li>
            <img src={cat.url} alt="Cat" style={{ width: '200px', height: 'auto' }} />
            <p>Breed: {cat.breeds.length > 0 ? cat.breeds[0].name : 'Unknown'}</p>
        </li>
    );
}