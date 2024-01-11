import './index.pcss' // Moet blijven staan
import { Routes, Route } from 'react-router-dom';

// Components
import Nav from './components/Nav.jsx'

// Pages
import Index from './pages/index.jsx';
import Login from './pages/login.jsx';
import Ervaringsdeskundige from './pages/ervaringsdeskundige.jsx';
import Bedrijven from './pages/bedrijven.jsx'
import Footer from './components/Footer.jsx';
import Onderzoek from './pages/dashboards/onderzoek.jsx';

function App() {
  return (
    <>

      <Nav />
      <div className="container py-8 justify-center mx-auto">

      <Routes>
        <Route path="/" element={<Index />} />
        <Route path="/login" element={<Login />} />
        <Route path="/portaal/ervaringsdeskundige" element={<Ervaringsdeskundige />} />
        <Route path="/portaal/bedrijven" element={<Bedrijven />} />
        <Route path="/dashboard/onderzoek" element={<Onderzoek />} />
        <Route path="/chat" element={<Chat />} />
      </Routes>
      </div>
      <Footer/>

    </>
  )
}

export default App
