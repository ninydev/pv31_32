import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import {MyRouteSystem} from "./MyRouteSystem.jsx";
import {RectRouteSystem} from "./RectRouteSystem.jsx";

function App() {

  return (
    <>
        <MyRouteSystem />
        <hr />
        <RectRouteSystem />
    </>
  )
}

export default App
