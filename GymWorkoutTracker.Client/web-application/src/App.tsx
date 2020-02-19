import React from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import Routing from "./components/Routing";
import { Link } from "react-router-dom";

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <Link to="/">Gym Tracker ⌚</Link>
            </header>
            <main className="mt-5">
                <Routing />
            </main>
        </div>
    );
}

export default App;
