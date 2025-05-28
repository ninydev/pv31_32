export function AboutPage(props) {
    const {pageChange} = props;
    return (
        <div>
        <h1>About Page</h1>
        <p>This is the about page of my homepage.</p>
            <a onClick={pageChange} id='home'>Home</a>
        </div>
    );

}