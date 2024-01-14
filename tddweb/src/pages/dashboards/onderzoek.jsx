import { useEffect, useState } from "react";
import OnderzoekInfoModal from "../../components/OnderzoekInfoModal";
import { jwtDecode } from "jwt-decode";

const Onderzoek = () => {
    const [onderzoeken, setOnderzoeken] = useState(null);
    const [searchInput, setSearchInput] = useState('');
    const [searchedOnderzoeken, setSearchedOnderzoeken] = useState(null);
    const [selectedOnderzoek, setSelectedOnderzoek] = useState(null);
    const [isOnderzoekenLoading, setIsOnderzoekenLoading] = useState(true);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const decodedToken = jwtDecode(localStorage.getItem("token"));

    const openModal = (onderzoek) => {
        setSelectedOnderzoek(onderzoek);
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setSelectedOnderzoek(null);
        setIsModalOpen(false);
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
                                <h3 className="mb-10">{decodedToken.voornaam} {decodedToken.achternaam}</h3>
                                <button
                                    data-modal-target="profile-edit-modal"
                                    data-modal-toggle="profile-edit-modal"
                                    className="outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue rounded-lg text-sm focus:outline-accessblue"
                                    aria-label="Bewerk profielgegevens"
                                >
                                    Bewerk profielgegevens
                                </button>
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
                                        onClick={() => openModal(onderzoek)}
                                    >
                                        Bekijk onderzoek
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

export default Onderzoek;

