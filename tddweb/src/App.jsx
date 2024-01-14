import React, { useEffect } from 'react';
import { Routes, Route, Navigate, useNavigate } from 'react-router-dom';

// Components
import Nav from './components/Nav.jsx';

// Pages
import Index from './pages/index.jsx';
import Login from './pages/login.jsx';
import Ervaringsdeskundige from './pages/ervaringsdeskundige.jsx';
import Bedrijven from './pages/bedrijven.jsx';
import Onderzoek from './pages/dashboards/onderzoek.jsx';
import Chat from './pages/chat.jsx';
import OnderzoekDetail from './components/OnderzoekDetail.jsx';

function App() {
  const navigate = useNavigate();

  useEffect(() => {
    // Check if a token is present in localStorage
    const token = localStorage.getItem('token');

    // If there is no token and the user is trying to access a protected route,
    // navigate them to the login page, except for the root route "/"
    if (!token && !window.location.pathname.includes('/login') && window.location.pathname !== '/') {
      navigate('/login');
    }
  }, [navigate]);

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
          <Route path="/onderzoek/:onderzoekid" element={<OnderzoekDetail />} />
          <Route path="/chat" element={<Chat />} />
          {/* You can add more routes as needed */}
          {/* Non-existent routes will be handled by the default redirect */}
          <Route path="*" element={<Navigate to="/login" />} />
        </Routes>
      </div>
    </>
  );
}

export default App;
