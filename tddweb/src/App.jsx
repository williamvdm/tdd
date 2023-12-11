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

      <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
        Button
      </button>
    </>
  )
}

export default App
