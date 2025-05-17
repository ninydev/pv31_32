export function MyParent({children}) {

    return(
        <div>
            <h1>My Parent</h1>
            <p>My Parent</p>
            <ul>
            {children}
            </ul>
        </div>
    )

}