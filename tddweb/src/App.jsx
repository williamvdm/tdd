import './index.pcss' // Moet blijven staan
import { Routes, Route } from 'react-router-dom';

// Components
import Nav from './components/Nav.jsx'

// Pages
import Index from './pages/index.jsx';
import Login from './pages/login.jsx';
import Ervaringsdeskundige from './pages/ervaringsdeskundige.jsx';
import Bedrijven from './pages/bedrijven.jsx'
import Onderzoek from './pages/dashboards/onderzoek.jsx';
import Chat from './pages/chat.jsx';
import OnderzoekDetail from './components/OnderzoekDetail.jsx';
import AuthRoute from './components/AuthRouting.jsx';
import LogOut from './pages/logout';

function App() {
  return (
    <>
      <Nav />
      <div className="container py-8 justify-center mx-auto">
        <Routes>
          <Route path="/" element={<Index />} />
          <Route path="/login" element={<Login />} />
          <Route path="/logout" element={<LogOut />} />
          <Route
            path="/portaal/*"
            element={<AuthRoute element={<Ervaringsdeskundige />} />}
          />
          <Route
            path="/dashboard/*"
            element={<AuthRoute element={<Onderzoek />} />}
          />
          <Route
            path="/onderzoek/:onderzoekid"
            element={<AuthRoute element={<OnderzoekDetail />} />}
          />
          <Route
            path="/chat"
            element={<AuthRoute element={<Chat />} />}
          />
        </Routes>
      </div>
    </>
  );
}

export default App;
