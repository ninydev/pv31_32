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
import {CatsPage} from "./components/CatsDb/CatsPage.jsx";
import {FirstAvatarUpload} from "./components/AvatarUpload/FirstAvatarUpload.jsx";
import {CropperExample} from "./components/AvatarUpload/CropperExample.jsx";
import {MyClock} from "./components/IntervalComponents/MyClock.jsx";
import {RenderBack} from "./components/RenderByClass/RenderBack.jsx";

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
        <RenderBack />
    </>
  )
}

export default App
