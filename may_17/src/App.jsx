import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import {BadRouter} from "./BadRouter/BadRouter.jsx";

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
        <BadRouter />
    </>
  )
}

export default App
