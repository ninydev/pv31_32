import { useState } from 'react'
import reactLogo from './assets/logos/react.svg'
import viteLogo from './assets/logos/vite.svg'
import './App.css'
import MyH from "./components/MyH/MyH.jsx";
import MyHook from "./components/MyHook/MyHook.jsx";
import MyKitchen from "./components/KitchenComponents/MyKitchen.jsx";
import {InputOnly} from "./components/MyFirstForms/InputOnly.jsx";
import {InputForms} from "./components/MyFirstForms/InputForms.jsx";
import {InputPassword} from "./components/MyFirstForms/InputPassword.jsx";

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
        <InputPassword/>
    </>
  )
}

export default App
