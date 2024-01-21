import './index.pcss' // Moet blijven staan
import { Routes, Route } from 'react-router-dom';

// Components
import Nav from './components/Nav.jsx'

// Pages
import Index from './pages/index.jsx';
import Login from './pages/login.jsx';
import Onderzoek from './pages/dashboards/onderzoek.jsx';
import Chat from './pages/chat.jsx';
import Registreer from './pages/registreer.jsx';
import OnderzoekDetail from './pages/dashboards/onderzoek/OnderzoekDetail.jsx';
import OnderzoekVragenlijst from './pages/dashboards/onderzoek/OnderzoekVragenlijst.jsx';
import AuthRoute from './components/AuthRouting.jsx';
import LogOut from './pages/logout';
import Bedrijf from './pages/dashboards/bedrijf.jsx';
import OnderzoekCreate from './pages/dashboards/bedrijf/OnderzoekCreate.jsx';
import OnderzoekEdit from './pages/dashboards/bedrijf/OnderzoekEdit.jsx';
import RegistreerBedrijf from './pages/registreerbedrijf.jsx';


function App() {
  return (
    <>
      <Nav />
      <div className="container py-8 justify-center mx-auto">
        <Routes>
          <Route path="/" element={<Index />} />
          <Route path="/login" element={<Login />} />
          <Route path="/registreer" element={<Registreer />} />
          <Route path="/registreerbedrijf" element={<RegistreerBedrijf />} />
          <Route path="/logout" element={<LogOut />} />
          <Route
            path="/dashboard/onderzoek"
            element={<AuthRoute element={<Onderzoek />} />}
          />
          <Route
            path="/onderzoek/create"
            element={<AuthRoute element={<OnderzoekCreate />} />}
          />
          <Route 
            path="/onderzoek/edit/:onderzoekid" 
            element={<OnderzoekEdit />} 
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
            path="/dashboard/bedrijf"
            element={<AuthRoute element={<Bedrijf />} />}
          />
        </Routes>
      </div>
    </>
  );
}

export default App;
