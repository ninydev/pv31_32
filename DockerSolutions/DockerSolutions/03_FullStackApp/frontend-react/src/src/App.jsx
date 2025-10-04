import './App.css'

import { BrowserRouter, Routes, Route, NavLink } from 'react-router-dom'
import { About } from './pages/About'
import Contacts from './pages/Contacts'
import {Home} from "./pages/Home.jsx";
import React from "react";


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
                <Route path="/" 
                       element={<React.Suspense 
                           fallback={<>Loading...</>}>{React.createElement(React.lazy(() => import('./pages/Home.jsx')))}</React.Suspense>} />
                <Route path="/about" element={<React.Suspense fallback={<>Loading...</>}>{React.createElement(React.lazy(() => import('./pages/About')))}</React.Suspense>} />
                <Route path="/contacts" element={<React.Suspense fallback={<>Loading...</>}>{React.createElement(React.lazy(() => import('./pages/Contacts')))}</React.Suspense>} />
            </Routes>
        </BrowserRouter>

    </>
  )
}

export default App
