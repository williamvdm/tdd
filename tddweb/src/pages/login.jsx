import { GoogleLogin } from '@react-oauth/google';
import { useNavigate } from "react-router-dom";
import { useState } from 'react';
import { EyeInvisibleOutlined, EyeOutlined } from "@ant-design/icons";

export default function Login() {
    let navigate = useNavigate();
    
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [showPassword, setShowPassword] = useState(false);

    const handleLogin = async (event) => {
        event.preventDefault();
        console.log('Formulier verzonden');
      
        try {
          const response = await fetch("http://localhost/api/User/LoginUser", {
            method: "POST",
            body: JSON.stringify({
              email: email,
              password: password
            }),
            headers: {
              "Content-type": "application/json; charset=UTF-8"
            }
          });
      
          if (response.status === 200) {
            const { token } = await response.json();
            window.localStorage.setItem("token", token);
            navigate("/dashboard/onderzoek");
          } else {
            console.error("Gebruikersnaam en/of wachtwoord kloppen niet");
          }
        } catch (error) {
          console.error("An error occurred during login process:", error);
        }
    };

    const handleTogglePassword = () => {
        setShowPassword(!showPassword);
    }

    return (
        <div class="min-h-screen font-muli bg-accessbluebg pt-20">
            <div className='container flex flex-col mx-auto p-4  sm:w-1/2 avg:w-1/4 rounded-lg bg-white shadow p-6 hover:shadow-lg transition ease-in-out border-t-4 border-accessorange '>
                <h1 className='text-slate-700 text-center text-2xl md:text-3xl lg:text-4xl xl:text-5xl sm:text-4xl mx:text-4xl mb-9'>Login</h1>

                <form onSubmit={handleLogin} className=' text-center mb-5 mx-auto'>
                    <div className='mb-6 flex justify-center flex-col'>
                        <div class="w-72 mb-5">
                            <div class="relative w-full min-w-[200px] h-10">
                                <input
                                required
                                type='text'
                                aria-label='Email verplicht'
                                class='hover:border-b-4 border-orange-500 peer  w-full h-full bg-transparent text-blue-gray-700 font-sans font-normal outline outline-0 focus:outline-0 disabled:bg-blue-gray-50 disabled:border-0 transition-all placeholder-shown:border placeholder-shown:border-t-blue-gray-200 border focus:border-2 border-t-transparent focus:border-t-transparent text-sm px-3 py-2.5 rounded-[7px]  focus:border-gray-900'
                                placeholder=''
                                onChange={(e) => setEmail(e.target.value)}
                                />
                                <label
                                htmlFor='email'
                                aria-required='true'
                                class="flex w-full h-full select-none pointer-events-none absolute left-0 font-normal !overflow-visible truncate peer-placeholder-shown:text-blue-gray-500 leading-tight peer-focus:leading-tight peer-disabled:text-transparent peer-disabled:peer-placeholder-shown:text-blue-gray-500 transition-all -top-1.5 peer-placeholder-shown:text-sm text-[11px] peer-focus:text-[11px] before:content[' '] before:block before:box-border before:w-2.5 before:h-1.5 before:mt-[6.5px] before:mr-1 peer-placeholder-shown:before:border-transparent before:rounded-tl-md before:border-t peer-focus:before:border-t-2 before:border-l peer-focus:before:border-l-2 before:pointer-events-none before:transition-all peer-disabled:before:border-transparent after:content[' '] after:block after:flex-grow after:box-border after:w-2.5 after:h-1.5 after:mt-[6.5px] after:ml-1 peer-placeholder-shown:after:border-transparent after:rounded-tr-md after:border-t peer-focus:after:border-t-2 after:border-r peer-focus:after:border-r-2 after:pointer-events-none after:transition-all peer-disabled:after:border-transparent peer-placeholder-shown:leading-[3.75] text-gray-500 peer-focus:text-gray-900 before:border-blue-gray-200 peer-focus:before:!border-gray-900 after:border-blue-gray-200 peer-focus:after:!border-gray-900">
                                    Email (verplicht)
                                </label>
                            </div>
                        </div>  

                        <div class="w-72 flex justify-center">
                            <div class="relative h-10 w-full min-w-[200px]">
                                <input 
                                required
                                type={showPassword ? "text" : "password"}
                                class="hover:border-b-4 border-orange-500 peer h-full w-full rounded-[7px] border border-t-transparent bg-transparent px-3 py-2.5 font-sans text-sm font-normal text-blue-gray-700 outline outline-0 transition-all placeholder-shown:border placeholder-shown:border-t-blue-gray-200 focus:border-2 focus:border-gray-900 focus:border-t-transparent focus:outline-0 disabled:border-0 disabled:bg-blue-gray-50"
                                placeholder=" "
                                onChange={(e) => setPassword(e.target.value)}
                                />
                                <label
                                htmlFor='wachtwoord'
                                aria-required='true'
                                class="before:content[' '] after:content[' '] pointer-events-none absolute left-0 -top-1.5 flex h-full w-full select-none !overflow-visible truncate text-[11px] font-normal leading-tight text-gray-500 transition-all before:pointer-events-none before:mt-[6.5px] before:mr-1 before:box-border before:block before:h-1.5 before:w-2.5 before:rounded-tl-md before:border-t before:border-l  before:transition-all after:pointer-events-none after:mt-[6.5px] after:ml-1 after:box-border after:block after:h-1.5 after:w-2.5 after:flex-grow after:rounded-tr-md after:border-t after:border-r after:border-blue-gray-200 after:transition-all peer-placeholder-shown:text-sm peer-placeholder-shown:leading-[3.75] peer-placeholder-shown:text-blue-gray-500 peer-placeholder-shown:before:border-transparent peer-placeholder-shown:after:border-transparent peer-focus:text-[11px] peer-focus:leading-tight peer-focus:text-gray-900 peer-focus:before:border-t-2 peer-focus:before:border-l-2 peer-focus:before:!border-gray-900 peer-focus:after:border-t-2 peer-focus:after:border-r-2 peer-focus:after:!border-gray-900 peer-disabled:text-transparent peer-disabled:before:border-transparent peer-disabled:after:border-transparent peer-disabled:peer-placeholder-shown:text-blue-gray-500">
                                Wachtwoord (verplicht)
                                </label>
                                <button
                                    type='button'
                                    className='absolute right-0 top-1/2 transform -translate-y-1/2 mr-2 cursor-pointer'
                                    onClick={handleTogglePassword}
                                >
                                    {showPassword ? <EyeInvisibleOutlined/> : <EyeOutlined/>}
                                </button>
                            </div>
                        </div>
                    </div>
                    <div>
                        <button
                            type='submit'
                            className='w-full bg-accessorange text-white py-2 px-4 rounded border-transparent border-2 hover:border-2 hover:border-accessblue hover:rounded-[7px]'
                        >Inloggen</button>
                    </div>
                </form>

                <div className='flex justify-center mb-5'>
                    <a 
                    className='text-xl text-accessblue'
                    href='/registreer'>
                        Nog geen account? Klik hier om te registreren!
                    </a>
                </div>

                <div className='scheiding mb-4 md:mb-6 lg:mb-8 xl:mb-8 border-b-2 border-black text-center' role='seperator' aria-label='Scheidingstekst'>
                    <span className='scheiding-tekst bg-white px-10 text-1.5rem'>of gebruik Google Login:</span>
                </div>
                
                <div  className='mb-4 md:mb-6 lg:mb-8 xl:mb-10 w-800 mx-auto border-2 border-transparent hover:border-2 hover:border-accessorange hover:rounded-[7px] '> 
                    <GoogleLogin
                        
                        theme="filled_blue"
                        onSuccess={credentialResponse => {
                            console.log(credentialResponse);
                        }}
                        onError={() => {
                            console.log('Het inloggen is niet gelukt.');
                        }}
                        
                    />
                </div>
            </div>
        </div>
    );
}

