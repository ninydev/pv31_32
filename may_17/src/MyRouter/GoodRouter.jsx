import {Link, Route, BrowserRouter, Routes} from "react-router";
import {HomePage} from "../pages/HomePage.jsx";
import {AboutPage} from "../pages/AboutPage.jsx";
import {ContactPage} from "../pages/ContactPage.jsx";
import {Error404Page} from "../pages/Error404Page.jsx";

export function GoodRouter() {
    return (
        <>
            <div>
                <BrowserRouter>

                    <div>
                        <h1> Good Router </h1>
                        <Link to="/">Home</Link> |
                        <Link to="/about">About</Link> |
                        <Link to="/contact">Contact</Link> |
                        <a href="/">Home</a>
                    </div>

                    <Routes>
                        <Route path="/" element={<HomePage/>}/>
                        <Route path="/about" element={<AboutPage/>}/>
                        <Route path="/contact" element={<ContactPage/>}/>
                        <Route path="*" element={<Error404Page/>}/>
                    </Routes>
                </BrowserRouter>
            </div>
        </>
    )
}