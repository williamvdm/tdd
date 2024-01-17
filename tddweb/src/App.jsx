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
<<<<<<< HEAD
import Registreer from './pages/registreer.jsx';
=======
import OnderzoekDetail from './pages/dashboards/onderzoek/OnderzoekDetail.jsx';
import OnderzoekVragenlijst from './pages/dashboards/onderzoek/OnderzoekVragenlijst.jsx';
import AuthRoute from './components/AuthRouting.jsx';
import LogOut from './pages/logout';
>>>>>>> develop

function App() {
  return (
    <>
      <Nav />
<<<<<<< HEAD
      <Routes>
        <Route path="/" element={<Index />} />
        <Route path="/login" element={<Login />} />
        <Route path="/registreer" element={<Registreer />} />
        <Route path="/portaal/ervaringsdeskundige" element={<Ervaringsdeskundige />} />
        <Route path="/portaal/bedrijven" element={<Bedrijven />} />
        <Route path="/portaal/onderzoek" element={<Onderzoek />} />
        <Route path="/chat" element={<Chat />} />
      </Routes>
=======
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
            path="/onderzoek/:onderzoekid/vragenlijst"
            element={<AuthRoute element={<OnderzoekVragenlijst />} />}
          />
          <Route
            path="/chat"
            element={<AuthRoute element={<Chat />} />}
          />
        </Routes>
      </div>
>>>>>>> develop
    </>
  );
}

export default App;
