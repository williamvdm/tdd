import { useState } from 'react';
import { EyeOutlined, EyeInvisibleOutlined } from '@ant-design/icons';
import { useNavigate } from "react-router-dom";
import React, { useEffect } from 'react';

//MUI

import { DatePicker } from '@mui/x-date-pickers';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import Checkbox from '@mui/material/Checkbox';
import Radio from '@mui/material/Radio';
import RadioGroup from '@mui/material/RadioGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import FormControl from '@mui/material/FormControl';
import TextField from '@mui/material/TextField';
import Autocomplete from '@mui/material/Autocomplete';
import CheckBoxOutlineBlankIcon from '@mui/icons-material/CheckBoxOutlineBlank';
import CheckBoxIcon from '@mui/icons-material/CheckBox';

function Registreer() {
    let navigate = useNavigate();

    const [showPassword, setShowPassword] = useState(false);  
    const [selectedDate, handleDateChange] = useState(null);
    const label = { inputProps: { 'aria-label': 'Checkbox demo' } };
    const icon = <CheckBoxOutlineBlankIcon fontSize="small" />;
    const checkedIcon = <CheckBoxIcon fontSize="small" />;

    const [achternaam, setAchternaam] = useState('');
    const [voornaam, setVoornaamn] = useState('');
    const [password, setPassword] = useState('');
    const [telefoon, setTelefoon] = useState('');
    const [email, setEmail] = useState('');
    const [toestemmingBenadering, setToestemmingBenadering] = useState(true);
    const [voorkeurBenadering, setVoorkeurBenadering] = useState('');
    const [aandoening, setAandoening] = useState('');
    const [beperking, setBeperking] = useState('');
    const [adres, setAdres] = useState('');

    const handleRegistreer = async (event) => {
        event.preventDefault();
        console.log('Formulier verzonden');
      
        try {
          const response = await fetch("http://localhost/api/User/RegisterUser", {
            method: "POST",
            body: JSON.stringify({
                // id: "0",
                password: password, 
                voornaam: voornaam,
                achternaam: achternaam, 
                email: email,
                telefoon: telefoon,
                toestemmingBenadering: toestemmingBenadering,
                voorkeurBenadering: voorkeurBenadering,
                provider: 'a', // moet nog een default voor komen 
                identityHash: 'a', // moet nog een default voor komen 
                role: 'a', // moet nog een default voor komen 
                isAdult: true,
                verzorger: {
                    "VerzorgerId": 0,
                    "VerzorgerEmail": "string",
                    "VerzorgerTelefoon": "0612345678"
                },
                aandoening: [
                    {
                        "aandoeningId": 0,
                        "aandoeningNaam": "string"
                    }
                ],
                beperking: [
                    {
                        "beperkingId": 0,
                        "beperkingNaam": "string"
                    }
                ],
                beschikbaarheid: [
                    {
                        "beschikbaarheidId": 0,
                        "begintijd": "2024-01-18T15:48:14.638Z",
                        "eindtijd": "2024-01-18T15:48:14.638Z"
                    }
                ],
                adres: {
                    locatieID: 0,
                    postCode: "string",
                    plaatsNaam: "string",
                    straatNaam: "string",
                    huisnummer: 0
                },
                onderzoeken: []
            }),
            headers: {
              "Content-type": "application/json; charset=UTF-8"
            }
          });
      
          if (response.status === 200) {
            navigate("/login");
          } else {
            console.error("Gebruikersnaam en/of wachtwoord kloppen niet");
          }
        } catch (error) {
          console.error("An error occurred during register process:", error);
        }
    };

    const handleTogglePassword = () => {
        setShowPassword(!showPassword);  
    };

    const handleToestemmingBenadering = (event) => {
        setToestemmingBenadering(event.target.checked);  
    };

    const beperkingen = [
        { title: 'Slechthorend of doof'},
        { title: 'Slechtziend'},
        { title: 'Blind'},
        { title: 'Leerbeperking'},
        { title: 'Motorische beperking'},
      ];

    const aandoeningen = [
        { title: 'Astma'},
        { title: 'Hartafwijking'},
        { title: 'Hoge bloeddruk'},
        { title: 'Maag-darmstoornis'},
        { title: 'Diabetes'},
    ]

    return (
        <div className="min-h-screen font-muli bg-accessbluebg pt-20">
            <div className='container flex flex-col mx-auto p-4 reg:w-1/2 rounded-lg bg-white shadow p-6 hover:shadow-lg transition ease-in-out border-t-4 border-accessorange '>
                <h1 className='text-slate-700 text-center text-5xl  mb-9'>Registratie</h1>
                <form onSubmit={handleRegistreer} className='text-center mb-5 mx-auto w-6/10'>
                    <div className='container mb-6 flex justify-center flex-col space-y-4'>
                        <div className="relative w-full min-w-[200px] h-10">
                            <input
                                required
                                type='text'
                                aria-label='Email verplicht'
                                className='hover:border-b-4 border-orange-500 peer w-full h-full bg-transparent text-blue-gray-700 font-sans font-normal outline outline-0 focus:outline-0 disabled:bg-blue-gray-50 disabled:border-0 transition-all placeholder-shown:border placeholder-shown:border-t-blue-gray-200 border focus:border-2 border-t-transparent focus:border-t-transparent text-sm px-3 py-2.5 rounded-[7px] focus:border-gray-900'
                                placeholder=''
                                onChange={(event) => setEmail(event.target.value)}
                            />
                            <label
                                htmlFor='email'
                                aria-required='true'
                                className="flex w-full h-full select-none pointer-events-none absolute left-0 font-normal !overflow-visible truncate peer-placeholder-shown:text-blue-gray-500 leading-tight peer-focus:leading-tight peer-disabled:text-transparent peer-disabled:peer-placeholder-shown:text-blue-gray-500 transition-all -top-1.5 peer-placeholder-shown:text-sm text-[11px] peer-focus:text-[11px] before:content[' '] before:block before:box-border before:w-2.5 before:h-1.5 before:mt-[6.5px] before:mr-1 peer-placeholder-shown:before:border-transparent before:rounded-tl-md before:border-t peer-focus:before:border-t-2 before:border-l peer-focus:before:border-l-2 before:pointer-events-none before:transition-all peer-disabled:before:border-transparent after:content[' '] after:block after:flex-grow after:box-border after:w-2.5 after:h-1.5 after:mt-[6.5px] after:ml-1 peer-placeholder-shown:after:border-transparent after:rounded-tr-md after:border-t peer-focus:after:border-t-2 after:border-r peer-focus:after:border-r-2 after:pointer-events-none after:transition-all peer-disabled:after:border-transparent peer-placeholder-shown:leading-[3.75] text-gray-500 peer-focus:text-gray-900 before:border-blue-gray-200 peer-focus:before:!border-gray-900 after:border-blue-gray-200 peer-focus:after:!border-gray-900">
                                Email (verplicht)
                            </label>
                        </div>

                        <div className="relative h-10 w-full min-w-[200px]">
                            <input
                                required
                                type={showPassword ? "text" : "password"}
                                className="hover:border-b-4 border-orange-500 peer h-full w-full rounded-[7px] border border-t-transparent bg-transparent px-3 py-2.5 font-sans text-sm font-normal text-blue-gray-700 outline outline-0 transition-all placeholder-shown:border placeholder-shown:border-t-blue-gray-200 focus:border-2 focus:border-gray-900 focus:border-t-transparent focus:outline-0 disabled:border-0 disabled:bg-blue-gray-50"
                                placeholder=" "
                                onChange={(event) => setPassword(event.target.value)}
                            />
                            <label
                                htmlFor='password'
                                aria-required='true'
                                className="before:content[' '] after:content[' '] pointer-events-none absolute left-0 -top-1.5 flex h-full w-full select-none !overflow-visible truncate text-[11px] font-normal leading-tight text-gray-500 transition-all before:pointer-events-none before:mt-[6.5px] before:mr-1 before:box-border before:block before:h-1.5 before:w-2.5 before:rounded-tl-md before:border-t before:border-l before:border-blue-gray-200 before:transition-all after:pointer-events-none after:mt-[6.5px] after:ml-1 after:box-border after:block after:h-1.5 after:w-2.5 after:flex-grow after:rounded-tr-md after:border-t after:border-r after:border-blue-gray-200 after:transition-all peer-placeholder-shown:text-sm peer-placeholder-shown:leading-[3.75] peer-placeholder-shown:text-blue-gray-500 peer-placeholder-shown:before:border-transparent peer-placeholder-shown:after:border-transparent peer-focus:text-[11px] peer-focus:leading-tight peer-focus:text-gray-900 peer-focus:before:border-t-2 peer-focus:before:border-l-2 peer-focus:before:!border-gray-900 peer-focus:after:border-t-2 peer-focus:after:border-r-2 peer-focus:after:!border-gray-900 peer-disabled:text-transparent peer-disabled:before:border-transparent peer-disabled:after:border-transparent peer-disabled:peer-placeholder-shown:text-blue-gray-500">
                                Wachtwoord (verplicht)
                            </label>
                            <button
                                type='button'
                                className='absolute right-0 top-1/2 transform -translate-y-1/2 mr-2 cursor-pointer'
                                onClick={handleTogglePassword}
                            >
                                {showPassword ? <EyeInvisibleOutlined /> : <EyeOutlined />}
                            </button>
                        </div>
                    </div>

                    <div className='container flex mb-6 justify-center space-x-4'>
                        <div className="relative w-full md:w-1/2 min-w-[200px] h-10">
                            <input
                                required
                                type='text'
                                aria-label='voornaam verplicht'
                                className='hover:border-b-4 border-orange-500 peer w-full h-full bg-transparent text-blue-gray-700 font-sans font-normal outline outline-0 focus:outline-0 disabled:bg-blue-gray-50 disabled:border-0 transition-all placeholder-shown:border placeholder-shown:border-t-blue-gray-200 border focus:border-2 border-t-transparent focus:border-t-transparent text-sm px-3 py-2.5 rounded-[7px] focus:border-gray-900'
                                placeholder=''
                                onChange={(event) => setVoornaamn(event.target.value)}
                            />
                            <label
                                htmlFor='voornaam'
                                aria-required='true'
                                className="flex w-full h-full select-none pointer-events-none absolute left-0 font-normal !overflow-visible truncate peer-placeholder-shown:text-blue-gray-500 leading-tight peer-focus:leading-tight peer-disabled:text-transparent peer-disabled:peer-placeholder-shown:text-blue-gray-500 transition-all -top-1.5 peer-placeholder-shown:text-sm text-[11px] peer-focus:text-[11px] before:content[' '] before:block before:box-border before:w-2.5 before:h-1.5 before:mt-[6.5px] before:mr-1 peer-placeholder-shown:before:border-transparent before:rounded-tl-md before:border-t peer-focus:before:border-t-2 before:border-l peer-focus:before:border-l-2 before:pointer-events-none before:transition-all peer-disabled:before:border-transparent after:content[' '] after:block after:flex-grow after:box-border after:w-2.5 after:h-1.5 after:mt-[6.5px] after:ml-1 peer-placeholder-shown:after:border-transparent after:rounded-tr-md after:border-t peer-focus:after:border-t-2 after:border-r peer-focus:after:border-r-2 after:pointer-events-none after:transition-all peer-disabled:after:border-transparent peer-placeholder-shown:leading-[3.75] text-gray-500 peer-focus:text-gray-900 before:border-blue-gray-200 peer-focus:before:!border-gray-900 after:border-blue-gray-200 peer-focus:after:!border-gray-900">
                                Voornaam (verplicht)
                            </label>
                        </div>
                        <div className="relative w-full md:w-1/2 min-w-[200px] h-10">
                            <input
                                required
                                type='text'
                                aria-label='achternaam'
                                className='hover:border-b-4 border-orange-500 peer w-full h-full bg-transparent text-blue-gray-700 font-sans font-normal outline outline-0 focus:outline-0 disabled:bg-blue-gray-50 disabled:border-0 transition-all placeholder-shown:border placeholder-shown:border-t-blue-gray-200 border focus:border-2 border-t-transparent focus:border-t-transparent text-sm px-3 py-2.5 rounded-[7px] focus:border-gray-900'
                                placeholder=''
                                onChange={(event) => setAchternaam(event.target.value)}
                            />
                            <label
                                htmlFor='achternaam'
                                aria-required='true'
                                className="flex w-full h-full select-none pointer-events-none absolute left-0 font-normal !overflow-visible truncate peer-placeholder-shown:text-blue-gray-500 leading-tight peer-focus:leading-tight peer-disabled:text-transparent peer-disabled:peer-placeholder-shown:text-blue-gray-500 transition-all -top-1.5 peer-placeholder-shown:text-sm text-[11px] peer-focus:text-[11px] before:content[' '] before:block before:box-border before:w-2.5 before:h-1.5 before:mt-[6.5px] before:mr-1 peer-placeholder-shown:before:border-transparent before:rounded-tl-md before:border-t peer-focus:before:border-t-2 before:border-l peer-focus:before:border-l-2 before:pointer-events-none before:transition-all peer-disabled:before:border-transparent after:content[' '] after:block after:flex-grow after:box-border after:w-2.5 after:h-1.5 after:mt-[6.5px] after:ml-1 peer-placeholder-shown:after:border-transparent after:rounded-tr-md after:border-t peer-focus:after:border-t-2 after:border-r peer-focus:after:border-r-2 after:pointer-events-none after:transition-all peer-disabled:after:border-transparent peer-placeholder-shown:leading-[3.75] text-gray-500 peer-focus:text-gray-900 before:border-blue-gray-200 peer-focus:before:!border-gray-900 after:border-blue-gray-200 peer-focus:after:!border-gray-900">
                                Achternaam 
                            </label>
                        </div>
                    </div>

                    <div className='container flex mb-6 justify-center space-x-4'>
                        <div className="relative w-full md:w-1/2 min-w-[200px] h-10">
                            <input
                                required
                                type='text'
                                aria-label='postcode'
                                className='hover:border-b-4 border-orange-500 peer w-full h-full bg-transparent text-blue-gray-700 font-sans font-normal outline outline-0 focus:outline-0 disabled:bg-blue-gray-50 disabled:border-0 transition-all placeholder-shown:border placeholder-shown:border-t-blue-gray-200 border focus:border-2 border-t-transparent focus:border-t-transparent text-sm px-3 py-2.5 rounded-[7px] focus:border-gray-900'
                                placeholder=''
                                onChange={(event) => setAdres(event.target.value)}
                            />
                            <label
                                htmlFor='postcode'
                                aria-required='true'
                                className="flex w-full h-full select-none pointer-events-none absolute left-0 font-normal !overflow-visible truncate peer-placeholder-shown:text-blue-gray-500 leading-tight peer-focus:leading-tight peer-disabled:text-transparent peer-disabled:peer-placeholder-shown:text-blue-gray-500 transition-all -top-1.5 peer-placeholder-shown:text-sm text-[11px] peer-focus:text-[11px] before:content[' '] before:block before:box-border before:w-2.5 before:h-1.5 before:mt-[6.5px] before:mr-1 peer-placeholder-shown:before:border-transparent before:rounded-tl-md before:border-t peer-focus:before:border-t-2 before:border-l peer-focus:before:border-l-2 before:pointer-events-none before:transition-all peer-disabled:before:border-transparent after:content[' '] after:block after:flex-grow after:box-border after:w-2.5 after:h-1.5 after:mt-[6.5px] after:ml-1 peer-placeholder-shown:after:border-transparent after:rounded-tr-md after:border-t peer-focus:after:border-t-2 after:border-r peer-focus:after:border-r-2 after:pointer-events-none after:transition-all peer-disabled:after:border-transparent peer-placeholder-shown:leading-[3.75] text-gray-500 peer-focus:text-gray-900 before:border-blue-gray-200 peer-focus:before:!border-gray-900 after:border-blue-gray-200 peer-focus:after:!border-gray-900">
                                Postcode
                            </label>
                        </div>
                        <div className="relative w-full md:w-1/2 min-w-[200px] h-10">
                            <input
                                required
                                type='text'
                                aria-label='telefoonnummer'
                                className='hover:border-b-4 border-orange-500 peer w-full h-full bg-transparent text-blue-gray-700 font-sans font-normal outline outline-0 focus:outline-0 disabled:bg-blue-gray-50 disabled:border-0 transition-all placeholder-shown:border placeholder-shown:border-t-blue-gray-200 border focus:border-2 border-t-transparent focus:border-t-transparent text-sm px-3 py-2.5 rounded-[7px] focus:border-gray-900'
                                placeholder=''
                                onChange={(event) => setTelefoon(event.target.value)}
                            />
                            <label
                                htmlFor='telefoonnummer'
                                aria-required='true'
                                className="flex w-full h-full select-none pointer-events-none absolute left-0 font-normal !overflow-visible truncate peer-placeholder-shown:text-blue-gray-500 leading-tight peer-focus:leading-tight peer-disabled:text-transparent peer-disabled:peer-placeholder-shown:text-blue-gray-500 transition-all -top-1.5 peer-placeholder-shown:text-sm text-[11px] peer-focus:text-[11px] before:content[' '] before:block before:box-border before:w-2.5 before:h-1.5 before:mt-[6.5px] before:mr-1 peer-placeholder-shown:before:border-transparent before:rounded-tl-md before:border-t peer-focus:before:border-t-2 before:border-l peer-focus:before:border-l-2 before:pointer-events-none before:transition-all peer-disabled:before:border-transparent after:content[' '] after:block after:flex-grow after:box-border after:w-2.5 after:h-1.5 after:mt-[6.5px] after:ml-1 peer-placeholder-shown:after:border-transparent after:rounded-tr-md after:border-t peer-focus:after:border-t-2 after:border-r peer-focus:after:border-r-2 after:pointer-events-none after:transition-all peer-disabled:after:border-transparent peer-placeholder-shown:leading-[3.75] text-gray-500 peer-focus:text-gray-900 before:border-blue-gray-200 peer-focus:before:!border-gray-900 after:border-blue-gray-200 peer-focus:after:!border-gray-900">
                                Telefoonnummer 
                            </label>
                        </div>
                    </div>

                    <div className='container flex mb-6 justify-center space-x-4 '>
                        <div className="relative w-full md:w-1/2 min-w-[200px] h-10 ">
                            <LocalizationProvider dateAdapter={AdapterDayjs}>
                                <DatePicker
                                    aria-label='geboortedatum'
                                    label="Selecteer je geboortedatum"
                                    format="DD-MM-YYYY"
                                    value={selectedDate}
                                    onChange={handleDateChange}
                                    className="w-full"
                                    sx={{
                                        "& .MuiOutlinedInput-root": {
                                            "& fieldset": {
                                                borderColor: "#ed8936",
                                            },
                                        },
                                    }}      
                                />
                            </LocalizationProvider>
                        </div>
                            
                        <div className="shadow bg-orange-100 rounded-md relative flex flex-col md:flex-row w-full md:w-1/2 min-w-[200px] pb-0">
                            <h2 className='text-slate-900 mb-4 md:mb-0 md:mr-4'>Mogen commerciële partijen je benaderen?</h2>
                            <div className='flex'>
                                <Checkbox {...label} checked={toestemmingBenadering} color="success" onChange={handleToestemmingBenadering}/>
                            </div>
                        </div>
                    </div>

                    <div className='shadow container flex mb-6 justify-center space-x-4 rounded-md bg-orange-100'>
                        <div className="mb-9 relative w-full h-10 ">
                            <h2 className='text-slate-900'>Voorkeur benadering</h2>

                            <FormControl>
                                <RadioGroup
                                    row
                                    aria-labelledby="demo-row-radio-buttons-group-label"
                                    name="row-radio-buttons-group"
                                    onChange={(event) => setVoorkeurBenadering(event.target.value)}
                                >
                                    <FormControlLabel value="Telefonisch" control={<Radio />} label="Telefonisch" />
                                    <FormControlLabel value="Via portal" control={<Radio />} label="Via portal" />
                                </RadioGroup>
                            </FormControl>
                        </div>
                    </div>

                    <div className='container flex flex-col mb-6 '>
                        <h2 className='text-slate-900 mb-4'>Selecteer de beperking(en) die je hebt</h2>
                        <Autocomplete
                            multiple
                            id="checkboxes-tags-demo"
                            options={beperkingen}
                            disableCloseOnSelect
                            getOptionLabel={(option) => option.title}
                            renderOption={(props, option, { selected }) => (
                                <li {...props}>
                                <Checkbox
                                    icon={icon}
                                    checkedIcon={checkedIcon}
                                    style={{ marginRight: 8 }}
                                    checked={selected}
                                />
                                {option.title}
                                </li>
                            )}
                            sx={{
                                "& .MuiAutocomplete-tag": {
                                    backgroundColor: "#fff3e0",
                                },
                                "& .MuiOutlinedInput-root fieldset": {
                                    borderColor: '#ed8936'
                                }
                            }}
                            style={{ width: '100' }}
                            renderInput={(params) => (
                                <TextField {...params} label="Beperkingen" placeholder="" />
                            )}
                            onChange={(event, value) => setBeperking(value)}
                        />
                    </div>

                    <div className='container flex flex-col mb-6 '>
                        <h2 className='text-slate-900 mb-4'>Selecteer de aandoening(en) die je hebt</h2>
                        <Autocomplete
                            multiple
                            id="checkboxes-tags-demo"
                            options={aandoeningen}
                            disableCloseOnSelect
                            getOptionLabel={(option) => option.title}
                            renderOption={(props, option, { selected }) => (
                                <li {...props}>
                                <Checkbox
                                    icon={icon}
                                    checkedIcon={checkedIcon}
                                    style={{ marginRight: 8 }}
                                    checked={selected}
                                />
                                {option.title}
                                </li>
                            )}
                            sx={{
                                "& .MuiAutocomplete-tag": {
                                    backgroundColor: "#fff3e0",
                                },
                                "& .MuiOutlinedInput-root fieldset": {
                                    borderColor: '#ed8936'
                                }
                            }}
                            style={{ width: '100' }}
                            renderInput={(params) => (
                                <TextField {...params} label="Beperkingen" placeholder="" />
                            )}
                            onChange={(event, value) => setAandoening(value)}
                        />
                    </div>
                    
                    <div>
                        <button
                            type='submit'
                            className='w-full bg-accessorange text-white py-2 px-4 rounded border-transparent border-2 hover:border-2 hover:border-accessblue hover:rounded-[7px]'
                        >Registreren</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default Registreer;
