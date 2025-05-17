import {useEffect, useState} from "react";
import {HomePage} from "../pages/HomePage.jsx";
import {AboutPage} from "../pages/AboutPage.jsx";
import {ContactPage} from "../pages/ContactPage.jsx";
import {Error404Page} from "../pages/Error404Page.jsx";

export function BadRouter() {

    const [currentPage, setCurrentPage] = useState(null)

    const changePage = (page) => {
        setCurrentPage(page);
        if (page === 'home') {
            window.history.pushState({}, '', '/');
        } else {
            window.history.pushState({}, '', `/${page}`);
        }
    }

    const setPageFromLocation = () => {
        const path = window.location.pathname.replace('/', '');

        console.log(path);

        setTimeout(() => {

            if (path === '') {
                setCurrentPage('home');
            }
            else if (['about', 'contact'].includes(path)) {
                setCurrentPage(path);
            } else {
                setCurrentPage('error404');
            }
        }, 40)


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
                            return <Error404Page />;
                    }
                })()
            }

        </>

    )

}