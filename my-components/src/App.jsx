import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import ByFunctionList from "./componets/ByFunction/ByFunctionList.jsx";
import ByAnonimList from "./componets/ByAnonim/ByAnonimList.jsx";
import ByClassList from "./componets/ByClass/ByClassList.jsx";
import UsersList from "./componets/FakeUsers/UsersList.jsx";

function App() {

  return (
    <>
      <h1> List Users</h1>
        <UsersList />
    </>
  )
}

export default App
