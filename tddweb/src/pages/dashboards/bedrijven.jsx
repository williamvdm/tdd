import { useEffect, useState } from "react";
import testdata from './testdata.json';

const Onderzoek = () => {
    const [onderzoeken, setOnderzoeken] = useState(testdata);
    const [searchInput, setSearchInput] = useState('');
    const [searchedOnderzoeken, setSearchedOnderzoeken] = useState(onderzoeken);

    // bedrijf state variables
    const [bedrijf, setBedrijf] = useState(null);
    const [isBedrijfLoading, setIsBedrijfLoading] = useState(true);

    // Search input filteren
    useEffect(() => {
        if (searchInput) {
            const filteredOnderzoeken = onderzoeken.filter((onderzoek) =>
                onderzoek.tags.some((tag) =>
                    tag.toLowerCase().includes(searchInput.toLowerCase())
                ) ||
                onderzoek.title.toLowerCase().includes(searchInput.toLowerCase())
            );
            setSearchedOnderzoeken(filteredOnderzoeken);
        } else {
            setSearchedOnderzoeken(onderzoeken);
        }
    }, [searchInput, onderzoeken]);

    // TODO: Fetch naar custom hook
    useEffect(() => {
        try {
            fetch("https://ablox.azurewebsites.net/api/Bedrijf/albert@heijn.nl")
                .then(res => res.json())
                .then(data => setBedrijf(data));
            setIsBedrijfLoading(false);
        } catch (error) {
            console.error(error);
        }
    }, []);

    // TODO Fetch onderzoeken

    return (
        <>         
            <div className="container justify-center mx-auto">
                <h1 className="text-4xl py-10">Bedrijven</h1>
                <div className="container flex flex-col md:flex-col sm:flex-col lg:flex-row">
                    {/* Profiel container */}
                    <div className="m-2 flex-grow">
                        <div className="flex flex-col items-center p-4 mb-4 rounded-lg bg-white p-6 border border-gray min-w-[300px] w-full">
                            <h2 className="mb-4 text-center">Bedrijfsomgeving</h2>
                            {isBedrijfLoading && <img className="w-24" src="https://www.icegif.com/wp-content/uploads/2023/07/icegif-1263.gif"></img>}
                            {bedrijf && (
                                <>
                                    <img
                                        src={"https://th.bing.com/th/id/R.4ef0854d04f128f1aa319d3f7d5e513f?rik=RNYp9Wu8gNo%2bRw&riu=http%3a%2f%2fupload.wikimedia.org%2fwikipedia%2fcommons%2fthumb%2fe%2feb%2fAlbert_Heijn_Logo.svg%2f1000px-Albert_Heijn_Logo.svg.png&ehk=uZYDJfGz5w%2bP%2fqPjUz2VcA4m2Q7CiFUIA9RFmGmqEfQ%3d&risl=&pid=ImgRaw&r=0"}
                                        className="rounded-full border border-gray w-40"
                                        alt="Profile"
                                    />
                                    <h3 className="mb-10">{bedrijf.bedrijfsmail}</h3>
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
                            <h2 className="mb-2 text-center">Lopende onderzoeken</h2>
                            <div className="flex flex-row">
                                <button className="ml-auto p-4 flex self-end rounded-xl text-white bg-accessgreen mb-2"><AiFillPlusCircle />
                                </button>
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
                            {searchedOnderzoeken.map((onderzoek) => (
                                <div
                                    className="card shadow-md p-4 mb-4 rounded-lg bg-white p-6 border border-gray transition ease-in-out min-w-full"
                                    key={onderzoek.id}
                                >
                                    <div className="flex flex-col">
                                        <h3 className="text-xl">{onderzoek.title}</h3>
                                        <p className="my-5 text-m">{onderzoek.description}</p>
                                        <ul className="flex wrap">
                                            {onderzoek.tags.map((tag) => (
                                                <li
                                                    key={tag}
                                                    className="mr-2 text-sm bg-accessdarkblue text-white p-2 rounded-xl">
                                                    {tag}
                                                </li>
                                            ))}
                                        </ul>
                                    </div>
                                    <div className="flex justify-end mt-4">
                                        <button
                                            className="bg-accessblue outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue text-white p-2 px-4 rounded-lg transition ease-in-out flex items-center focus:outline-accessblue"
                                            aria-label={`Bekijk onderzoek ${onderzoek.title}`}>
                                            Bekijk onderzoek
                                        </button>
                                    </div>
                                </div>
                            ))}
                        </div>
                    </div>
                </div>
            </div>
        </>
    );


};

export default Onderzoek;

