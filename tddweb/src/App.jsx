import './index.pcss' // Moet blijven staan
import { Routes, Route } from 'react-router-dom';

// Components
import Nav from './components/Nav.jsx'
import Footer from './components/Footer.jsx'

// Pages
import Index from './pages/index.jsx';
import Login from './pages/login.jsx';
import Bedrijven from './pages/dashboards/bedrijven.jsx';
import Onderzoek from './pages/dashboards/onderzoek.jsx';
import Chat from './pages/chat.jsx';

function App() {
  return (
    <>
      <Nav />
      <div className="justify-center">
      <Routes>
        <Route path="/" element={<Index />} />
        <Route path="/login" element={<Login />} />
        <Route path="/dashboard/bedrijven" element={<Bedrijven />} />
        <Route path="/dashboard/onderzoek" element={<Onderzoek />} />
        <Route path="/chat" element={<Chat />} />
      </Routes> 
      <Footer />
        </div>
    </>
  )
}

export default App
