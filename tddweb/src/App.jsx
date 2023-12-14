import { useState } from 'react'
import { GoogleLogin } from '@react-oauth/google';
import './index.pcss' // Moet blijven staan
import { Routes, Route } from 'react-router-dom';

// Components
import Nav from './components/Nav.jsx'

// Pages
import Index from './pages/index.jsx';
import Login from './pages/login.jsx';
import Ervaringsdeskundige from './pages/ervaringsdeskundige.jsx';

function App() {
  return (
    <>
      <Nav />
      <Routes>
        <Route path="/" element={<Index />} />
        <Route path="/login" element={<Login />} />
        <Route path="/ervaringsdeskundigeportaal" element={<Ervaringsdeskundige />} />
      </Routes>
    </>
  )
}

export default App
