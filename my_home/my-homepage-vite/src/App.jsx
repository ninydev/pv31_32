import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import {MyRouteSystem} from "./MyRouteSystem.jsx";
import {RectRouteSystem} from "./RectRouteSystem.jsx";
import {CatsPage} from "./pages/CatsPage.jsx";

function App() {

  return (
    <>
        <CatsPage />
    </>
  )
}

export default App
