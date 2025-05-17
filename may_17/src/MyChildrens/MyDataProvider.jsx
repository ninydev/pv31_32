import React, {useState} from "react";

export function MyDataProvider( {children} ) {

    const [data, setData] = useState(null);

    const changeData = (data) => {
        console.log("Change Data called");
    }

    console.log("Typeof children", typeof children);
    return (
        <>
            <>
                {typeof children === 'function'
                    ? children(changeData)
                    : React.Children.map(children, child =>
                        React.isValidElement(child)
                            ? React.cloneElement(child, { changeData })
                            : child
                    )
                }
            </>
        </>
    )

}