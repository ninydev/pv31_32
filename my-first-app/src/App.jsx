import { useState } from 'react'

import MyNavigation from "./components/MyNavigation.jsx";
import MyHeader from "./components/MyHeader.jsx";
import MyServices from "./components/MyServices.jsx";

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
        <MyNavigation />
        <MyHeader />
        <MyServices />
    </>
  )
}

export default App
