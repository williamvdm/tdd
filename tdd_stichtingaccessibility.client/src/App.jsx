import { BrowserRouter, Routes, Route } from 'react-router-dom';
/*Import hieronder de pagina die je hebt aangemaakt*/
import Home from './pages/Home';
import Dashboard from './pages/Dashboard';
import './App.css';

function App() {
    console.error("Error: Hello, World!")

    return (
        <BrowserRouter>
            <Routes>
                {/*Voeg onderaan een nieuwe route toe met de import*/}
                <Route index element={<Home />} />
                <Route path="/" element={<Home />} />
                <Route path="/dashboard" element={<Dashboard />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;