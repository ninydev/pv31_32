import './App.css'

import { BrowserRouter, Routes, Route, NavLink } from 'react-router-dom'
import { About } from './pages/About'
import Contacts from './pages/Contacts'
import {Home} from "./pages/Home.jsx";


function App() {

  return (
    <>
        <BrowserRouter>
            <nav style={{ display: 'flex', gap: 12, padding: 12 }}>
                <NavLink to="/" end>Home</NavLink>
                <NavLink to="/about">About</NavLink>
                <NavLink to="/contacts">Contacts</NavLink>
            </nav>

            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/about" element={<About />} />
                <Route path="/contacts" element={<Contacts />} />
            </Routes>
        </BrowserRouter>

    </>
  )
}

export default App
