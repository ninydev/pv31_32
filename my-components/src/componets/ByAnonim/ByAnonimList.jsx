
import ByAnonimItem from "./ByAnonimItem.jsx";

export default function ByAnonimList ()  {
    const items = ['Audi', 'BMW', 'Mercedes', 'Porsche', 'Volkswagen', 'Ford', 'Chevrolet', 'Toyota', 'Honda', 'Nissan'];

    return(
        <>
            <ul>
                {items.map((item, index) => (
                    <ByAnonimItem key={index} index={index} item={item} />
                ))}
            </ul>
        </>
    )
}