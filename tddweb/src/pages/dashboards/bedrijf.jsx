import { useEffect, useState } from "react";
import { jwtDecode } from "jwt-decode";
import { Link } from 'react-router-dom';

export default function Bedrijf() {
    const [onderzoeken, setOnderzoeken] = useState(null);
    const [searchInput, setSearchInput] = useState('');
    const [searchedOnderzoeken, setSearchedOnderzoeken] = useState([]);
    const [selectedOnderzoek, setSelectedOnderzoek] = useState(null);
    const [isOnderzoekenLoading, setIsOnderzoekenLoading] = useState(true);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isProfileEditModalOpen, setIsProfileEditModalOpen] = useState(false);

    const token = localStorage.getItem("token")
    let decodedToken = null;
    if (token) {
        decodedToken = jwtDecode(token);
    }

    const openModal = (onderzoek) => {
        setSelectedOnderzoek(onderzoek);
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setSelectedOnderzoek(null);
        setIsModalOpen(false);
    };

    const openProfileEditModal = () => {
        setIsProfileEditModalOpen(true);
    };

    const closeProfileEditModal = () => {
        setIsProfileEditModalOpen(false);
    };

    // Search input filteren
    useEffect(() => {
        if (searchInput && onderzoeken) {
            const filteredOnderzoeken = onderzoeken.filter((onderzoek) =>
                (onderzoek.title && onderzoek.title.toLowerCase().includes(searchInput.toLowerCase())) ||
                (onderzoek.beschrijving && onderzoek.beschrijving.toLowerCase().includes(searchInput.toLowerCase()))
            );
            setSearchedOnderzoeken(filteredOnderzoeken);
        } else {
            setSearchedOnderzoeken(onderzoeken);
        }
    }, [searchInput, onderzoeken]);

    // Fetch lijst met onderzoeken
    useEffect(() => {
        try {
            console.log("begin fetch");
            fetch("http://localhost/api/Onderzoek/bedrijf/jumbo@jumbo.nl")
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
        } catch (error) {
            console.error(error);
        }
    }, []);

    return (
        <>
            <h1 className="text-4xl py-10">Dashboard</h1>
            <div className="container flex flex-col md:flex-col sm:flex-col lg:flex-row">
                {isModalOpen && (
                    <OnderzoekInfoModal
                        onderzoek={selectedOnderzoek}
                        closeModal={closeModal}
                    />
                )}

                {isProfileEditModalOpen && (
                    <ProfileEditModal
                        user={decodedToken}
                        closeModal={closeProfileEditModal}
                    />
                )}
                {/* Profiel container */}
                <div className="m-2 flex-grow">
                    <div className="flex flex-col items-center p-4 mb-4 rounded-lg bg-white p-6 border border-gray min-w-[300px] w-full">
                        <h2 className="mb-4 text-center">Mijn profiel</h2>
                        {decodedToken && (
                            <>
                                <img
                                    src="https://scontent-ams4-1.xx.fbcdn.net/v/t39.30808-6/370151348_697536122404214_4329006098959866260_n.png?_nc_cat=1&ccb=1-7&_nc_sid=efb6e6&_nc_ohc=4P9_bzXJ1HAAX9v0RCx&_nc_ht=scontent-ams4-1.xx&oh=00_AfCqNE7brQqHCg1xA-1vdpks7AwuRxbSTQ2RUUZruYDRvA&oe=65AE9A8E"
                                    className="rounded-full border border-gray w-40"
                                    alt="Profile"
                                />
                                <h3 className="mb-10">Jumbo</h3>
                                <button
                                    onClick={openProfileEditModal}
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
                        <div className="flex justify-end">
                        <Link to="#" className="bg-accessgreen outline-none hover:outline-solid hover:outline-2 mb-5 hover:outline-accessgreen text-white p-2 px-4 rounded-lg transition ease-in-out flex items-center focus:outline-accessgreen w-[100px]">
                            Creeren
                        </Link>
                        </div>
                        <div className="flex flex-row">
                            <form className="flex flex-row p-4 mb-4 rounded-lg bg-white p-6 border border-gray w-full">
                                <input
                                    id="search_input"
                                    value={searchInput}
                                    onChange={(e) => setSearchInput(e.target.value)}
                                    className="transition ease-in-out w-full h-full focus:outline-none focus:ring focus:border-accessblue"
                                    placeholder="Typ hier om te zoeken door lopende onderzoeken"
                                />
                            </form>
                        </div>
                        {isOnderzoekenLoading && <img className="w-24 mx-auto" src="https://www.icegif.com/wp-content/uploads/2023/07/icegif-1263.gif"></img>}
                        {isOnderzoekenLoading == false && searchedOnderzoeken.length == 0 && <h3>Geen zoekresultaten...</h3>}
                        {searchedOnderzoeken && searchedOnderzoeken.map((onderzoek) => (
                            <div
                                className="card shadow-md p-4 mb-4 rounded-lg bg-white p-6 border border-gray transition ease-in-out min-w-full w-full"
                                key={onderzoek.id}
                            >
                                <div className="flex flex-col">
                                    <h3 className="text-xl">{onderzoek.titel}</h3>
                                    <p className="my-5 text-m">{onderzoek.beschrijving}</p>
                                </div>
                                <div className="flex justify-end mt-4">
                                    <button
                                        className="mr-2 outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue text-black p-2 px-4 rounded-lg transition ease-in-out flex items-center focus:outline-accessblue"
                                        aria-label={`Bekijk onderzoek ${onderzoek.titel}`}

                                    >
                                        Verwijder
                                    </button>
                                    <button
                                        className="bg-accessorange outline-none hover:outline-solid hover:outline-2 hover:outline-accessorange text-white p-2 px-4 rounded-lg transition ease-in-out flex items-center focus:outline-accessorange"
                                        aria-label={`Bekijk onderzoek ${onderzoek.titel}`}

                                    >
                                        Bewerk
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

