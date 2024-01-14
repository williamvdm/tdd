import { useEffect, useState } from "react";
import OnderzoekInfoModal from "../../components/OnderzoekInfoModal";
import { jwtDecode } from "jwt-decode";
import { Link } from 'react-router-dom';

const Admin = () => {
    const [onderzoeken, setOnderzoeken] = useState(null);
    const [gebruikers, setGebruikers] = useState(null);
    const [bedrijven, setBedrijven] = useState(null);

    const [searchInputOnderzoek, setSearchInputOnderzoek] = useState('');
    const [searchInputGebruiker, setSearchInputGebruiker] = useState('');
    const [searchInputBedrijf, setSearchInputBedrijf] = useState('');

    const [searchedOnderzoeken, setSearchedOnderzoeken] = useState(null);
    const [searchedGebruikers, setSearchedGebruikers] = useState(null);
    const [searchedBedrijven, setSearchedBedrijven] = useState(null);

    const [selectedOnderzoek, setSelectedOnderzoek] = useState(null);
    const [selectedGebruiker, setSelectedGebruiker] = useState(null);
    const [selectedBedrijf, setSelectedBedrijf] = useState(null);

    const [isOnderzoekenLoading, setIsOnderzoekenLoading] = useState(true);
    const [isGebruikersLoading, setIsGebruikersLoading] = useState(true);
    const [isBedrijvenLoading, setIsBedrijvenLoading] = useState(true);
    
    const [isOnderzoekModalOpen, setIsOnderzoekModalOpen] = useState(false);
    const [isGebruikerModalOpen, setIsGebruikerModalOpen] = useState(false);
    const [isBedrijfModalOpen, setIsBedrijfModalOpen] = useState(false);

    const token = localStorage.getItem("token")
    let decodedToken = null;
    if (token) {
        decodedToken = jwtDecode(token);
    }

    const openModalOnderzoek = (onderzoek) => {
        setSelectedOnderzoek(onderzoek);
        setIsOnderzoekModalOpen(true);
    };

    const closeModalOnderzoek = () => {
        setSelectedOnderzoek(null);
        setIsOnderzoekModalOpen(false);
    };

    const openModalBedrijf = (bedrijf) => {
        setSelectedBedrijf(bedrijf);
        setIsBedrijfModalOpen(true);
    };

    const closeModalBedrijf = () => {
        setSelectedBedrijf(null);
        setIsBedrijfModalOpen(false);
    };

    const openModalGebruiker = (gebruiker) => {
        setSelectedGebruiker(gebruiker);
        setIsGebruikerModalOpen(true);
    };

    const closeModalGebruiker = () => {
        setSelectedGebruiker(null);
        setIsGebruikerModalOpen(false);
    };

    // Search input filteren
    useEffect(() => {
        if (searchInputOnderzoek && onderzoeken) {
            const filteredOnderzoeken = onderzoeken.filter((onderzoek) =>
                (onderzoek.title && onderzoek.title.toLowerCase().includes(searchInputOnderzoek.toLowerCase())) ||
                (onderzoek.beschrijving && onderzoek.beschrijving.toLowerCase().includes(searchInputOnderzoek.toLowerCase()))
            );
            setSearchedOnderzoeken(filteredOnderzoeken);
        } else {
            setSearchedOnderzoeken(onderzoeken);
        }
    }, [searchInputOnderzoek, onderzoeken]);

    // Fetch lijst met onderzoeken
    useEffect(() => {
        try {
            console.log("begin fetch");
            fetch("https://ablox.azurewebsites.net/api/Onderzoek")
                .then(res => res.json())
                .then(data => {
                    console.log(data);
                    setOnderzoeken(data);
                    setSearchedOnderzoeken(data);
                    setIsOnderzoekenLoading(false);
                })
                .catch(error => {
                    console.log("Couldn't fetch");
                    console.error(error);
                });
            fetch("https://ablox.azurewebsites.net/api/User/GetUserList")
                .then(res => res.json())
                .then(data => {
                    console.log(data);
                    setGebruikers(data);
                    setSearchedGebruikers(data);
                    setIsGebruikersLoading(false);
                })
                .catch(error => {
                    console.log("Couldn't fetch");
                    console.error(error);
                });
            fetch("https://ablox.azurewebsites.net/api/Bedrijf")
                .then(res => res.json())
                .then(data => {
                    console.log(data);
                    setBedrijven(data);
                    setSearchedBedrijven(data);
                    setIsBedrijvenLoading(false);
                })
                .catch(error => {
                    console.log("Couldn't fetch");
                    console.error(error);
                });
        } catch (error) {
            console.error(error);
        }
    }, []);

    return (
        <>
            <h1 className="text-4xl py-10">Dashboard Admin</h1>
            <div className="container flex flex-col md:flex-col sm:flex-col lg:flex-row">
                {isOnderzoekModalOpen && (
                    <OnderzoekInfoModal
                        onderzoek={selectedOnderzoek}
                        closeModal={closeModalOnderzoek}
                    />
                )}
                {isBedrijfModalOpen && (
                    <BedrijfInfoModal
                        onderzoek={selectedBedrijf}
                        closeModal={closeModalBedrijf}
                    />
                )}
                {isGebruikerModalOpen && (
                    <GebruikerInfoModal
                        onderzoek={selectedGebruiker}
                        closeModal={closeModalGebruiker}
                    />
                )}
                {/* Profiel container */}
                <div className="m-2 flex-grow">
                    <div className="flex flex-col items-center p-4 mb-4 rounded-lg bg-white p-6 border border-gray min-w-[300px] w-full">
                        <h2 className="mb-4 text-center">Mijn profiel</h2>
                        {decodedToken && (
                            <>
                                <img
                                    src="https://pbs.twimg.com/profile_images/918270974029697024/lNFaPqEz_400x400.jpg"
                                    className="rounded-full border border-gray w-40"
                                    alt="Profile"
                                />
                                <h3 className="mb-10">{decodedToken.given_name} {decodedToken.family_name}</h3>
                                <button
                                    data-modal-target="profile-edit-modal"
                                    data-modal-toggle="profile-edit-modal"
                                    className="text-gray-500 outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue px-4 rounded-lg transition ease-in-out flex items-center focus:outline-accessblue w-1/7"
                                    aria-label="Bewerk profielgegevens"
                                >
                                    Bewerk profielgegevens
                                </button>
                                <Link to="/logout" className="mt-2 text-gray-500 outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue px-4 rounded-lg transition ease-in-out flex items-center focus:outline-accessblue w-1/7">
                                    Uitloggen
                                </Link>
                            </>
                        )}
                    </div>
                </div>
                {/* Lopende onderzoeken container */}
                <div className="m-2 flex-grow">
                    <div className="p-4 mb-4 rounded-lg bg-white p-6 border border-gray min-w-full w-full">
                        <h2 className="mb-4 text-center">Lopende onderzoeken</h2>
                        <div className="flex flex-row">
                            <form className="flex flex-row p-4 mb-4 rounded-lg bg-white p-6 border border-gray w-full">
                                <input
                                    id="search_input_onderzoek"
                                    value={searchInputOnderzoek}
                                    onChange={(e) => setSearchInputOnderzoek(e.target.value)}
                                    className="transition ease-in-out w-full h-full focus:outline-none focus:ring focus:border-accessblue"
                                    placeholder="Typ hier om te zoeken door lopende onderzoeken"
                                />
                            </form>
                        </div>
                        {isOnderzoekenLoading && <img className="w-24 mx-auto" src="https://www.icegif.com/wp-content/uploads/2023/07/icegif-1263.gif"></img>}
                        {isOnderzoekenLoading == false && searchedOnderzoeken.length == 0 && <h3>Geen zoekresultaten...</h3>}
                        {searchedOnderzoeken && searchedOnderzoeken.map((onderzoek) => (
                            <div
                                className="card shadow-md p-4 mb-4 rounded-lg bg-white p-6 border border-gray transition ease-in-out min-w-full"
                                key={onderzoek.id}
                            >
                                <div className="flex flex-col">
                                    <h3 className="text-xl">{onderzoek.titel}</h3>
                                    <p className="my-5 text-m">{onderzoek.beschrijving}</p>
                                </div>
                                <div className="flex justify-end mt-4">
                                    <button
                                        className="bg-accessblue outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue text-white p-2 px-4 rounded-lg transition ease-in-out flex items-center focus:outline-accessblue"
                                        aria-label={`Bekijk onderzoek ${onderzoek.titel}`}
                                        onClick={() => openModalOnderzoek(onderzoek)}
                                    >
                                        Bekijk onderzoek
                                    </button>
                                </div>
                            </div>
                        ))}
                    </div>

                    <div className="p-4 mb-4 rounded-lg bg-white p-6 border border-gray min-w-full w-full">
                        <h2 className="mb-4 text-center">Gebruikers</h2>
                        <div className="flex flex-row">
                            <form className="flex flex-row p-4 mb-4 rounded-lg bg-white p-6 border border-gray w-full">
                                <input
                                    id="search_input"
                                    value={searchInputGebruiker}
                                    onChange={(e) => setSearchInputGebruiker(e.target.value)}
                                    className="transition ease-in-out w-full h-full focus:outline-none focus:ring focus:border-accessblue"
                                    placeholder="Typ hier om te zoeken door lopende onderzoeken"
                                />
                            </form>
                        </div>
                        {isGebruikersLoading && <img className="w-24 mx-auto" src="https://www.icegif.com/wp-content/uploads/2023/07/icegif-1263.gif"></img>}
                        {isGebruikersLoading == false && searchedGebruikers.length == 0 && <h3>Geen zoekresultaten...</h3>}
                        {searchedGebruikers && searchedGebruikers.map((user) => (
                            <div
                                className="card shadow-md p-4 mb-4 rounded-lg bg-white p-6 border border-gray transition ease-in-out min-w-full"
                                key={user.id}
                            >
                                <div className="flex flex-col">
                                    <h3 className="text-xl">{user.voornaam}</h3>
                                    <p className="my-5 text-m">{user.achternaam}</p>
                                </div>
                                <div className="flex justify-end mt-4">
                                    <button
                                        className="bg-accessblue outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue text-white p-2 px-4 rounded-lg transition ease-in-out flex items-center focus:outline-accessblue"
                                        aria-label={`Bekijk gebruiker ${user.voornaam}`}
                                        onClick={() => openModalGebruiker(user)}
                                    >
                                        Bekijk gebruiker
                                    </button>
                                </div>
                            </div>
                        ))}
                    </div>

                    <div className="p-4 mb-4 rounded-lg bg-white p-6 border border-gray min-w-full w-full">
                        <h2 className="mb-4 text-center">Bedrijven</h2>
                        <div className="flex flex-row">
                            <form className="flex flex-row p-4 mb-4 rounded-lg bg-white p-6 border border-gray w-full">
                                <input
                                    id="search_input"
                                    value={searchInputBedrijf}
                                    onChange={(e) => setSearchInputBedrijf(e.target.value)}
                                    className="transition ease-in-out w-full h-full focus:outline-none focus:ring focus:border-accessblue"
                                    placeholder="Typ hier om te zoeken door geregistreerde bedrijven"
                                />
                            </form>
                        </div>
                        {isBedrijvenLoading && <img className="w-24 mx-auto" src="https://www.icegif.com/wp-content/uploads/2023/07/icegif-1263.gif"></img>}
                        {isBedrijvenLoading == false && searchedBedrijven.length == 0 && <h3>Geen zoekresultaten...</h3>}
                        {searchedBedrijven && searchedBedrijven.map((bedrijf) => (
                            <div
                                className="card shadow-md p-4 mb-4 rounded-lg bg-white p-6 border border-gray transition ease-in-out min-w-full"
                                key={bedrijf.id}
                            >
                                <div className="flex flex-col">
                                    <h3 className="text-xl">{bedrijf.titel}</h3>
                                    <p className="my-5 text-m">{bedrfijf.beschrijving}</p>
                                </div>
                                <div className="flex justify-end mt-4">
                                    <button
                                        className="bg-accessblue outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue text-white p-2 px-4 rounded-lg transition ease-in-out flex items-center focus:outline-accessblue"
                                        aria-label={`Bekijk bedrijf ${bedrijf.titel}`}
                                        onClick={() => openModalBedrijf(bedrijf)}
                                    >
                                        Bekijk bedrijf
                                    </button>
                                </div>
                            </div>
                        ))}
                    </div>
                </div>
            </div>
        </>
    );


};

export default Admin;

