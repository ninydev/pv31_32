import ByFunctionItem from "./ByFunctionItem.jsx";


function ByFunctionList() {

    const items = ['Audi', 'BMW', 'Mercedes', 'Porsche', 'Volkswagen', 'Ford', 'Chevrolet', 'Toyota', 'Honda', 'Nissan'];

    return(
        <>
            <ul>
                {items.map((item, index) => (
                    <ByFunctionItem key={index} index={index} item={item} />
                ))}
            </ul>
        </>)
}

export default ByFunctionList;