import React from 'react'
import ReactDOM from 'react-dom/client'
import { GoogleOAuthProvider } from '@react-oauth/google';
import { BrowserRouter } from 'react-router-dom';
import App from './App.jsx'

ReactDOM.createRoot(document.getElementById('root')).render(
  <GoogleOAuthProvider clientId="564563511455-a3hop6b9n311gcj8gi6o930gua1hmv4r.apps.googleusercontent.com">
    <React.StrictMode>
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </React.StrictMode>
  </GoogleOAuthProvider>,
)
