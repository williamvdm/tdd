import { useState } from 'react'
import { GoogleLogin } from '@react-oauth/google';
import './App.css'

function App() {
  return (
    <>
      <GoogleLogin
        onSuccess={credentialResponse => {
          console.log(credentialResponse);
        }}
        onError={() => {
          console.log('Login Failed');
        }}
      />
    </>
  )
}

export default App
