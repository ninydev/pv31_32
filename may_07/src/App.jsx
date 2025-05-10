import { useState } from 'react'
import reactLogo from './assets/logos/react.svg'
import viteLogo from './assets/logos/vite.svg'
import './App.css'
import MyH from "./components/MyH/MyH.jsx";
import MyHook from "./components/MyHook/MyHook.jsx";
import MyKitchen from "./components/KitchenComponents/MyKitchen.jsx";

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
        <MyKitchen />
    </>
  )
}

export default App
