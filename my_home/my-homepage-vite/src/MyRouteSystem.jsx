import {useState} from "react";
import {HomePage} from "./pages/HomePage.jsx";
import {AboutPage} from "./pages/AboutPage.jsx";
import {ContactPage} from "./pages/ContactPage.jsx";

export function MyRouteSystem() {
    // 1 State to keep track of the current page
    const [currentPage, setCurrentPage] = useState('home');

    // 2 Function to handle page change
    const handlePageChange = (e) => {
        e.preventDefault();
        const page = e.target.id;
        console.log(page);
        setCurrentPage(page);
        return false;
    }
    // <!-- 3 Using onClick to change the page -->
    // <!-- 4 Render the current page based on the state -->

    return (<><div>
            <h1>My Route System</h1>
            <nav><ul>
                <li><a onClick={handlePageChange} id='home'>Home</a></li>
                <li><a onClick={handlePageChange} id='about'>About</a></li>
                <li><a onClick={handlePageChange} id='contact'>Contact</a></li>
            </ul></nav>
            <hr />
        </div>
        <main>
            {currentPage === 'home' && <HomePage />}
            {currentPage === 'about' && <AboutPage pageChange={handlePageChange} />}
            {currentPage === 'contact' && <ContactPage />}
            {currentPage !== 'home' && currentPage !== 'about' && currentPage !== 'contact' && <p>Page not found!</p>}
        </main></>);
}