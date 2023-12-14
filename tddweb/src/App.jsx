import { useState } from 'react'
import { GoogleLogin } from '@react-oauth/google';
import './index.pcss' // Moet blijven staan
import { Routes, Route } from 'react-router-dom';

// Components
import Nav from './components/Nav.jsx'

import Index from './pages/index.jsx';

function App() {
  return (
    <>
      <Nav />
      <Routes>
        <Route path="/" element={<Index />} />
      </Routes>
    </>
  )
}

export default App
