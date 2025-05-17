import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import {BadRouter} from "./MyRouter/BadRouter.jsx";
import {GoodRouter} from "./MyRouter/GoodRouter.jsx";
import {MyTreePage} from "./MyChildrens/MyTreePage.jsx";

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
        <GoodRouter />
    </>
  )
}

export default App
