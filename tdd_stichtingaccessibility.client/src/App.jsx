import { BrowserRouter, Routes, Route } from 'react-router-dom';
/*Import hieronder de pagina die je hebt aangemaakt*/
import Home from './pages/Home';
import Dashboard from './pages/Dashboard';
import './App.css';

function App() {
    console.error("Error: no errors")
  
    const responseMessage = (response) => {
        console.log("Inlog succes")
        console.log(response);
        window.history.pushState(null, null, '/swagger/index.html');
    };
    const errorMessage = (error) => {
        console.log("Inlog gefaald")
        console.log(error);
    };

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