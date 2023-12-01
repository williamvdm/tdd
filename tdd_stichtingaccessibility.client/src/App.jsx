import { useEffect, useState } from 'react';
import { GoogleLogin } from '@react-oauth/google'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Home from './pages/Home'
import Dashboard from './pages/Dashboard'
import './App.css';

function App() {

    return (
        <BrowserRouter>
            <Routes>
                <Route index element={<Home />} />
                <Route path="/" element={<Home />} />
                <Route path="/dashboard" element={<Dashboard />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;