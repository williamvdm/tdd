import { useState } from 'react'
import { GoogleLogin } from '@react-oauth/google';
import './App.css'

function App() {
  return (
    <>
      {/* <GoogleLogin
      theme='filled_blue'
      width='200px'
        onSuccess={credentialResponse => {
          console.log(credentialResponse);
        }}
        onError={() => {
          console.log('Login Failed');
        }}
      /> */}
      <div className='flex justify-center'>
        <div className='w-full max-w-screen-lg flex space-x-8'>
          <div className='flex-1 rounded-lg bg-white shadow p-6 hover:shadow-lg transition ease-in-out border-t-4 border-accessblue'>
            <h1 className='text-xl m-2 font-bold text-center mb-8'>Onderzoeksportaal</h1>
            <p className='m-2 mb-8'>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </p>
            <button className='w-full bg-accessblue hover: text-white py-2 px-4 rounded outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue'>
              Naar onderzoeksportaal
            </button>
          </div>
          <div className='flex-1 rounded-lg bg-white shadow p-6 hover:shadow-lg transition ease-in-out border-t-4 border-accessorange'>
            <h1 className='text-xl m-2 font-bold text-center mb-8'>Bedrijvenportaal</h1>
            <p className='m-2 mb-8'>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </p>
            <button className='w-full bg-accessorange text-white py-2 px-4 rounded outline-none hover:outline-solid hover:outline-2 hover:outline-accessorange'>
              Naar bedrijvenportaal
            </button>
          </div>
          <div className='flex-1 rounded-lg bg-white shadow p-6 hover:shadow-lg transition ease-in-out border-t-4 border-accessgreen'>
            <h1 className='text-xl m-2 font-bold text-center mb-8'>Beheerdersportaal</h1>
            <p className='m-2 mb-8'>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </p>
            <button className='w-full bg-accessgreen text-white py-2 px-4 rounded outline-none hover:outline-solid hover:outline-2 hover:outline-accessgreen'>
              Naar beheerdersportaal
            </button>
          </div>
        </div>
      </div>
    </>
  )
}

export default App
