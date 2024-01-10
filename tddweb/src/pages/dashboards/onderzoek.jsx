import { useEffect, useState } from "react";
import testdata from './testdata.json';
import { BsCaretRightFill } from "react-icons/bs";

const Onderzoek = () => {
    const [onderzoeken, setOnderzoeken] = useState(testdata);
    const [searchInput, setSearchInput] = useState('');
    const [searchedOnderzoeken, setSearchedOnderzoeken] = useState(onderzoeken);
    const [filteredTags, setFilteredTags] = useState([]);
    const [menuOpen, setMenuOpen] = useState(true);

    useEffect(() => {
        const uniqueTags = new Set();

        onderzoeken.forEach((onderzoek) => {
            onderzoek.tags.forEach((tag) => {
                uniqueTags.add(tag);
            });
        });

        const uniqueTagsArray = Array.from(uniqueTags);

        setFilteredTags(uniqueTagsArray);
    }, [onderzoeken]);

    useEffect(() => {
        if (searchInput) {
            const filteredOnderzoeken = onderzoeken.filter((onderzoek) =>
                onderzoek.tags.some((tag) =>
                    tag.toLowerCase().includes(searchInput.toLowerCase())
                )
            );
            setSearchedOnderzoeken(filteredOnderzoeken);
        } else {
            setSearchedOnderzoeken(onderzoeken);
        }
    }, [searchInput, onderzoeken]);

    function filterDropdown() {
        let menu = document.getElementById("filter_menu");
        setMenuOpen(!menuOpen);
        menu.style.visibility = menuOpen ? "visible" : "hidden";
    }

    return (
        <>
            <h1 className="text-4xl py-10">Dashboard</h1>
            <div className="container flex flex-col md:flex-col sm:flex-col lg:flex-row">
                {/* Profiel container */}
                <div className="m-2 flex-grow">
                    <div className="flex flex-col items-center p-4 mb-4 rounded-lg bg-white p-6 border border-gray min-w-[300px] w-full">
                        <h2 className="mb-4 text-center">Mijn profiel</h2>
                        <img
                            src="https://pbs.twimg.com/profile_images/918270974029697024/lNFaPqEz_400x400.jpg"
                            className="rounded-full border border-gray w-40"
                            alt="Profile"
                        />
                        <h3 className="mb-10">Pipo de Klaas</h3>
                        <button
                            className="outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue rounded-lg text-sm focus:outline-accessblue"
                            aria-label="Bewerk profielgegevens"
                        >
                            Bewerk profielgegevens
                        </button>
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
        </>
    );


};

export default Onderzoek;

