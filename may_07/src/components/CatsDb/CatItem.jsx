
export function CatItem(props) {
    const { cat } = props;

    return (
        <li className="cat-item" id={cat.id}>
            <img src={cat.image} alt={cat.name} width={100}/>
            <h3>{cat.name}</h3>
            <p>id: {cat.id}</p>
        </li>
    );

}