import {BrowserRouter, Link, Route, Routes} from "react-router";
import {HomePage} from "./pages/HomePage.jsx";
import {Error404Page} from "./pages/Error404Page.jsx";

import './App.css'
import {ReadAllColors} from "./components/ColorModule/ReadAllColors.jsx";
import {CreateColor} from "./components/ColorModule/CreateColor.jsx";
import {ReadColor} from "./components/ColorModule/ReadColor.jsx";
import {DeleteColor} from "./components/ColorModule/DeleteColor.jsx";
import {UpdateColor} from "./components/ColorModule/UpdateColor.jsx";
import SomeBigEmailComponent from "./components/MyFirstContext/EmailExample/SomeBigEmailComponent.jsx";
import {EmailProvider} from "./components/MyFirstContext/EmailExample/EmailContext.jsx";
import {OtherEmailComponent} from "./components/MyFirstContext/EmailExample/OtherEmailComponent.jsx";

function App() {

    return (
        <>
            <header><h1>ColorDB</h1></header>
            <BrowserRouter>

                <nav>
                    <ul>
                        <li><Link to="/">Home</Link></li>
                        <li><Link to="/colors">Colors</Link></li>
                        <li><Link to="/context_start">Context Start</Link></li>
                        <li><Link to="/some/other">Context Other</Link></li>
                    </ul>
                </nav>
                <Routes>
                    <Route path="/" element={<HomePage/>}/>
                    <Route path="/colors" element={<ReadAllColors/>}/>
                    <Route path="/colors/create" element={<CreateColor/>}/>
                    <Route path="/colors/read/:id" element={<ReadColor/>}/>
                    <Route path="/colors/update/:id" element={<UpdateColor/>}/>
                    <Route path="/colors/delete/:id" element={<DeleteColor/>}/>

                    <Route path="/some/other" element={
                        <EmailProvider key="123">
                            <OtherEmailComponent/>
                        </EmailProvider>
                    }/>
                    <Route path="/context_start" element={
                        <EmailProvider key="321">
                            <SomeBigEmailComponent/>
                        </EmailProvider>
                    }/>
                    <Route path="*" element={<Error404Page/>}/>

                </Routes>

            </BrowserRouter>
        </>
    )
}

export default App
