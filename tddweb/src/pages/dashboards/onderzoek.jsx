import { useEffect, useState } from "react";
import testdata from './testdata.json';

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
        <div className="container">
            <h1 className="text-3xl py-10 font-bold">Lopende onderzoeken</h1>
            <div className="flex flex-row justify-end ms:flex-col ms:w-full">
                <form className="flex flex-row p-4 mb-4 rounded-lg bg-white p-6 border border-accessgray w-1/3 mr-4 relative">
                    <input id="search_input" value={searchInput} onChange={(e) => setSearchInput(e.target.value)} className="transition ease-in-out w-full h-full focus:outline-none" placeholder="Klik hier om te zoeken" />
                </form>
                <button className="p-4 mb-4 rounded-lg bg-white p-6 border border-accessgray ml-1" onClick={filterDropdown} >Filter</button>
                <div id="filter_menu" className="rounded-lg bg-white border border-accessgray absolute p-4 mt-20 invisible">
                    {filteredTags.map((filteredTag) => (
                        <div key={filteredTag} className="p-1">
                            <input type="checkbox" id={filteredTag} name={filteredTag} value={filteredTag} />
                            <label className="ml-2" htmlFor={filteredTag}>{filteredTag}</label>
                        </div>
                    ))}
                </div>
            </div>

            {
                onderzoeken &&
                <div className="flex justify-around flex-col items-center">
                    {searchInput == "anita" && <img src="https://www.britsekortharen.nl/wp-content/uploads/2013/12/britse-korthaar.jpg"></img> }
                    {searchedOnderzoeken.length == 0 && <div>Geen zoekresultaten...</div>}
                    {searchedOnderzoeken.map(onderzoek => (
                        <div className="card p-4 mb-4 rounded-lg bg-white p-6 border border-accessgray transition ease-in-out min-w-full" key={onderzoek.id}>
                            <div className="flex flex-col">
                                <h3 className="text-xl">{onderzoek.title}</h3>
                                <p className="my-5">{onderzoek.description}</p>
                                <ul>
                                    {onderzoek.tags.map(tag => (
                                        <li key={tag}>{tag}</li>
                                    ))}
                                </ul>
                            </div>
                            <div className="flex justify-end mt-4">
                                <button
                                    className='bg-accessblue hover:bg-accessbluedark text-white py-2 px-4 rounded-lg transition ease-in-out'>
                                    bekijk onderzoek
                                </button>
                            </div>
                        </div>
                    ))}
                </div>
            }
        </div >
    );
};

export default Onderzoek;

