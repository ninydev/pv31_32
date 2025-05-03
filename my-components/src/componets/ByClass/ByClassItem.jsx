import React from "react";


class ByClassItem extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            item: props.item,
            index: props.index
        }
    }

    render() {
        const { item, index } = this.state;
        return <li>{index} {item}</li>
    }
}

export default ByClassItem;