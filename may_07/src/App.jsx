import { useState } from 'react'
import reactLogo from './assets/logos/react.svg'
import viteLogo from './assets/logos/vite.svg'
import './App.css'
import MyH from "./components/MyH/MyH.jsx";
import MyHook from "./components/MyHook/MyHook.jsx";

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
        <MyHook />
    </>
  )
}

export default App
