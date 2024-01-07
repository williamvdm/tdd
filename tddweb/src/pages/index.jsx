import React, { useState } from 'react';


function Index() {
  const [weatherData, setWeatherData] = useState([]);

  async function fetchWeatherData() {
    try {
      const response = await fetch('http://ablox.azurewebsites.net/WeatherForecast');
      const data = await response.json();
      setWeatherData(data);
    } catch (error) {
      console.error('Kutzooi:', error);
    }
  };

  return (
    <>

      <div className="relative">
        <img
          src="src\assets\banner.jpg"
          alt="Banner"
          className="w-full object-cover"
          style={{ height: '90vh', filter: 'brightness(55%) blur(1px)' }}
        />
        <div className="absolute top-1/2 left-10 transform -translate-y-1/2 text-white p-4">
          <h1 className="text-3xl md:text-6xl lg:text-7xl font-bold">Stichting Accessibility</h1>
          <p className="text-lg md:text-xl lg:text-2xl mt-2">Lorem Impsum Ador Levit</p>
        </div>
      </div>



      <div className='flex justify-center mt-20'>
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


      <div class="mt-20 bg-gray-900 h-80 flex justify-center items-center">
        <div class="p-8 rounded-lg text-white text-center">
          <h2 class="text-2xl font-bold mb-4">
            De Stichting Accessibility heeft de volgende missie:
          </h2>
          <p class="text-lg p-5">
            Een inclusieve samenleving waarin alle mensen met of zonder beperking gelijkwaardig participeren. Zij streven naar digitale, fysieke en sociale toegankelijkheid voor iedereen. Om onderzoek te doen naar de huidige toegankelijkheid en aan de hand daarvan verbetervoorstellen te kunnen doen.
          </p>
        </div>
      </div>


      <div class="mt-20 py-12">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div class="flex flex-wrap -mx-4">
            <div class="w-full md:w-1/3 px-4 mb-8">
              <div class="h-full flex flex-col rounded-lg bg-white shadow p-6 hover:shadow-lg transition ease-in-out border-t-4 border-accessblue">
                <img src="https://via.placeholder.com/150" alt="Image 1" class="w-full mb-2 rounded-lg" />
                <div class="flex-1">
                  <div class="bg-white p-4 rounded-lg">
                    <h3 class="text-lg font-bold mb-2">Onderzoek 1</h3>
                    <p class="text-sm mb-4">
                      Een studie naar de impact van technologische innovaties op de toegankelijkheid van openbare ruimtes voor mensen met beperkingen.
                    </p>
                    <button class='w-full bg-accessblue hover:text-white py-2 px-3 rounded outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue text-s'>
                      Lees meer
                    </button>
                  </div>
                </div>
              </div>
            </div>
            <div class="w-full md:w-1/3 px-4 mb-8">
              <div class="h-full flex flex-col rounded-lg bg-white shadow p-6 hover:shadow-lg transition ease-in-out border-t-4 border-accessorange">
                <img src="https://via.placeholder.com/150" alt="Image 2" class="w-full mb-2 rounded-lg" />
                <div class="flex-1">
                  <div class="bg-white p-4 rounded-lg">
                    <h3 class="text-lg font-bold mb-2">Onderzoek 2</h3>
                    <p class="text-sm mb-4">
                      Analyse van de effectiviteit van online tools voor het verbeteren van de digitale toegankelijkheid van websites voor verschillende gebruikersgroepen.
                    </p>
                    <button class='w-full bg-accessorange text-white py-2 px-3 rounded outline-none hover:outline-solid hover:outline-2 hover:outline-accessorange text-s'>
                      Lees meer
                    </button>
                  </div>
                </div>
              </div>
            </div>
            <div class="w-full md:w-1/3 px-4 mb-8">
              <div class="h-full flex flex-col rounded-lg bg-white shadow p-6 hover:shadow-lg transition ease-in-out border-t-4 border-accessgreen">
                <img src="https://via.placeholder.com/150" alt="Image 3" class="mb-2 rounded-lg" />
                <div class="flex-1">
                  <div class="bg-white p-4 rounded-lg">
                    <h3 class="text-lg font-bold mb-2">Onderzoek 3</h3>
                    <p class="text-sm mb-4">
                      Onderzoek naar de sociale perceptie van toegankelijkheid en de integratie van mensen met beperkingen in verschillende maatschappelijke domeinen.
                    </p>
                    <button class='w-full bg-accessgreen text-white py-2 px-3 rounded outline-none hover:outline-solid hover:outline-2 hover:outline-accessgreen text-s'>
                      Lees meer              
                      </button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>



      <div className="mt-20 relative">
        <img
          src="src\assets\banner.jpg"
          alt="Banner"
          className="w-full object-cover"
          style={{ height: '60vh', filter: 'brightness(35%) blur(1px)'}}
        />
        <div className="absolute bottom-8 left-1/2 -translate-x-1/2 text-white p-4">
  <div className="flex flex-col items-center">
    <h1 className="text-3xl md:text-6xl font-bold text-center">Stichting Accessibility</h1>
    <p className="text-lg md:text-xl lg:text-2xl mt-2 text-center">Wil je meer weten over Stichting Accessibility, druk dan op de knop hieronder!</p>
    <button class='mt-5 bg-accessgreen text-white py-2 px-6 rounded-full outline-none hover:outline-solid hover:outline-2 hover:outline-accessgreen text-s'>
    <a href="https://www.accessibility.nl/" target="_blank" rel="noopener noreferrer">
                      Lees meer              
                     </a> </button></div>
</div>

</div>



      <div className='mt-20 flex justify-center'>
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
