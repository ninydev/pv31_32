import {BrowserRouter, Link, Route, Routes} from "react-router";
import {HomePage} from "./pages/HomePage.jsx";
import {Error404Page} from "./pages/Error404Page.jsx";

import './App.css'
import {ReadAllColors} from "./components/ColorModule/ReadAllColors.jsx";
import {CreateColor} from "./components/ColorModule/CreateColor.jsx";
import {ReadColor} from "./components/ColorModule/ReadColor.jsx";
import {DeleteColor} from "./components/ColorModule/DeleteColor.jsx";
import {UpdateColor} from "./components/ColorModule/UpdateColor.jsx";

function App() {

  return (
    <>
      <header><h1>ColorDB</h1></header>
        <BrowserRouter>

            <nav>
                <ul>
                    <li><Link to="/">Home</Link></li>
                    <li><Link to="/colors">Colors</Link></li>
                </ul>
            </nav>
            <Routes>
                <Route path="/" element={<HomePage  />}/>

                <Route path="/colors" element={<ReadAllColors  />}/>
                <Route path="/colors/create" element={<CreateColor  />}/>
                <Route path="/colors/read/:id" element={<ReadColor  />}/>
                <Route path="/colors/update/:id" element={<UpdateColor  />}/>
                <Route path="/colors/delete/:id" element={<DeleteColor  />}/>

                <Route path="*" element={<Error404Page />}/>
            </Routes>

        </BrowserRouter>
    </>
  )
}

export default App
