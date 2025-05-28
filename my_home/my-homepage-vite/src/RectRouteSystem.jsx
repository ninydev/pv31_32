import {BrowserRouter, Link, Route, Routes} from "react-router";
import {HomePage} from "./pages/HomePage.jsx";
import {AboutPage} from "./pages/AboutPage.jsx";
import {ContactPage} from "./pages/ContactPage.jsx";

export function RectRouteSystem() {

    return(<>
        <BrowserRouter>
            <div>
                <h1>Rect Route System</h1>
                <nav>
                    <ul>
                        <li><Link to='/'>Home</Link></li>
                        <li><Link to='/about'>About</Link></li>
                        <li><Link to='/contact'>Contact</Link></li>
                    </ul>
                </nav>
                <hr />
            </div>
            <main>
                <Routes>
                    <Route path='/' element={<HomePage />} />
                    <Route path='/about' element={<AboutPage />} />
                    <Route path='/contact' element={<ContactPage />} />
                    <Route path='*' element={<p>Page not found!</p>} />
                </Routes>
            </main>




        </BrowserRouter>
    </>)
}