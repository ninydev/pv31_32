import {useEffect, useState} from "react";
import {HomePage} from "../pages/HomePage.jsx";
import {AboutPage} from "../pages/AboutPage.jsx";
import {ContactPage} from "../pages/ContactPage.jsx";

export function BadRouter() {

    const [currentPage, setCurrentPage] = useState(null)

    const changePage = (page) => {
        setCurrentPage(page);
        window.history.pushState({}, '', `/${page}`);
    }

    const setPageFromLocation = () => {
        const path = window.location.pathname.replace('/', '');
        if (['home', 'about', 'contact'].includes(path)) {
            setCurrentPage(path);
        } else {
            setCurrentPage('home');
        }
    };

    useEffect(() => {
        setPageFromLocation();
    }, []);

    if(!currentPage) {
        return <h1>Loading...</h1>
    }


    return(<>
        <div>
            <h1>Bad Router</h1>
            <button onClick={() => changePage('home')}>Home</button>
            <button onClick={() => changePage('about')}>About</button>
            <button onClick={() => changePage('contact')}>Contact</button>
        </div>

            {
                (() => {
                    switch(currentPage) {
                        case 'home':
                            return <HomePage />;
                        case 'about':
                            return <AboutPage />;
                        case 'contact':
                            return <ContactPage />;
                        default:
                            return <h1>404 Not Found</h1>;
                    }
                })()
            }

        </>

    )

}