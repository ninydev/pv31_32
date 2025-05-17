export function MyParent({children, changeData}) {

    return(
        <div>
            <h1>My Parent</h1>
            <button onClick={changeData}>Change Data</button>
            <ul>
            {children}
            </ul>
        </div>
    )

}