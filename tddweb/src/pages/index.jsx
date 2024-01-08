import React, { useState } from 'react';
import { Red } from 'react-router-dom';

function Index() {
  const [weatherData, setWeatherData] = useState([]);

  async function fetchWeatherData() {
    try {
      const response = await fetch('http://ablox.azurewebsites.net/WeatherForecast')
      const data = await response.json();
      setWeatherData(data);
    } catch (error) {
      console.error('Kutzooi:', error);
    }
  };

  function Redirector(url) {
    
  }

  return (
    <>
      <div className='flex justify-center'>
        <div className='w-full max-w-screen-lg flex space-x-8'>
          <div className='flex-1 rounded-lg bg-white shadow p-6 hover:shadow-lg transition ease-in-out border-t-4 border-accessblue'>
            <h1 className='text-xl m-2 font-bold text-center mb-8'>Onderzoeksportaal</h1>
            <p className='m-2 mb-8'>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </p>
            <button
              className='w-full bg-accessblue hover: text-white py-2 px-4 rounded outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue'
              onClick={fetchWeatherData}>
              Naar onderzoeksportaal
            </button>
          </div>
          <div className='flex-1 rounded-lg bg-white shadow p-6 hover:shadow-lg transition ease-in-out border-t-4 border-accessorange'>
            <h1 className='text-xl m-2 font-bold text-center mb-8'>Bedrijvenportaal</h1>
            <p className='m-2 mb-8'>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </p>
            <button
              className='w-full bg-accessorange text-white py-2 px-4 rounded outline-none hover:outline-solid hover:outline-2 hover:outline-accessorange'>
              Naar bedrijvenportaal
            </button>
          </div>
          <div className='flex-1 rounded-lg bg-white shadow p-6 hover:shadow-lg transition ease-in-out border-t-4 border-accessgreen'>
            <h1 className='text-xl m-2 font-bold text-center mb-8'>Beheerdersportaal</h1>
            <p className='m-2 mb-8'>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </p>
            <button
              className='w-full bg-accessgreen text-white py-2 px-4 rounded outline-none hover:outline-solid hover:outline-2 hover:outline-accessgreen'>
              Naar beheerdersportaal
            </button>
          </div>
        </div>
      </div>
      <div className='flex justify-center'>
        <div id="weatherapi" className="m-2 mb-8">
          {weatherData.map((item, index) => (
            <div key={index}>
              <span>{item.date}</span>: {item.summary}
            </div>
          ))}
        </div>
      </div>
    </>
  );
};

export default Index;
