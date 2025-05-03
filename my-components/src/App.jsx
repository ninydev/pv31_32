import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import ByFunctionList from "./componets/ByFunction/ByFunctionList.jsx";
import ByAnonimList from "./componets/ByAnonim/ByAnonimList.jsx";
import ByClassList from "./componets/ByClass/ByClassList.jsx";

function App() {

  return (
    <>
      <h1> List ByClass</h1>
      <ByClassList />
      <h1> List ByAnonim </h1>
        <ByAnonimList />
      <h1> List ByFunction </h1>
      <ByFunctionList />
    </>
  )
}

export default App
