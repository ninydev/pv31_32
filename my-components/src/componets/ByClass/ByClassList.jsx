import React from "react";
import ByClassItem from "./ByClassItem.jsx";


class ByClassList extends React.Component{

    constructor() {
        super();
        this.state = {
            items: ['Audi', 'BMW', 'Mercedes', 'Porsche', 'Volkswagen', 'Ford', 'Chevrolet', 'Toyota', 'Honda', 'Nissan']
        }
    }


    render() {
        return (
            <ul>
                {this.state.items.map((item, index) => (
                    <ByClassItem key={index} index={index} item={item} />
                ))}
            </ul>
        );
    }

}

export default ByClassList;