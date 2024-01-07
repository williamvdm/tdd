import { useEffect, useState } from "react";
import db from '../db.json';

const Onderzoek = () => {
    const [onderzoeken, setOnderzoeken] = useState([
        {
            "id": 1,
            "title": "De Impact van Kunstmatige Intelligentie op de Samenleving",
            "description": "Dit onderzoek heeft tot doel de maatschappelijke gevolgen van grootschalige adoptie van kunstmatige intelligentie te onderzoeken en de effecten ervan op verschillende aspecten van het dagelijks leven.",
            "tags": [
                "vragenlijst",
                "adhd",
                "stom"
            ]
        },
        {
            "id": 2,
            "title": "Strategieën voor Klimaatverandering Mitigatie: Een Uitgebreid Overzicht",
            "description": "Analyse en evaluatie van de effectiviteit van verschillende strategieën voor het verminderen van klimaatverandering, met nadruk op duurzaamheid en milieueffecten.",
            "tags": [
                "doof",
                "vragenlijst"
            ]
        },
        {
            "id": 3,
            "title": "De Rol van Blockchain in Veilige Gegevenstransacties",
            "description": "Onderzoek naar hoe blockchaintechnologie de beveiliging en transparantie van gegevenstransacties in diverse sectoren, zoals financiën en gezondheidszorg, kan verbeteren.",
            "tags": [
                "beveiliging",
                "blind"
            ]
        },
        {
            "id": 4,
            "title": "Toegankelijkheid van Websites voor Mensen met ADHD",
            "description": "Een diepgaande analyse van de toegankelijkheid van websites voor mensen met ADHD, met een focus op het verbeteren van de gebruikerservaring en het verminderen van cognitieve belasting.",
            "tags": [
                "toegankelijkheid",
                "adhd",
                "gebruikerservaring",
                "vragenlijst"
            ]
        },
        {
            "id": 5,
            "title": "Online Toegankelijkheid voor Mensen met Autisme",
            "description": "Onderzoek naar manieren om online platforms toegankelijker te maken voor mensen met autisme, met aandacht voor gebruikersinterfaces en informatieverwerking.",
            "tags": [
                "toegankelijkheid",
                "autisme",
                "gebruikersinterfaces"
            ]
        },
        {
            "id": 6,
            "title": "Interviews als Hulpmiddel bij Website-Toegankelijkheidsevaluaties",
            "description": "Onderzoek naar het gebruik van interviews als effectief middel bij het evalueren van de toegankelijkheid van websites, met een focus op gebruikerservaring en feedbackverzameling.",
            "tags": [
                "interview",
                "online",
                "autisme"
            ]
        },
        {
            "id": 7,
            "title": "Effectiviteit van Online Trainingen voor Toegankelijkheidsbewustzijn",
            "description": "Een evaluatie van de effectiviteit van online trainingen voor het vergroten van het bewustzijn over toegankelijkheid van websites, met het oog op betere ontwerppraktijken.",
            "tags": [
                "doof",
                "stom",
                "vragenlijst"
            ]
        },
        {
            "id": 8,
            "title": "Inclusief Ontwerp: Het Belang van Diversiteit in Website-Interfaces",
            "description": "Onderzoek naar inclusieve ontwerppraktijken en het belang van diversiteit in website-interfaces voor het creëren van een betere digitale ervaring voor alle gebruikers.",
            "tags": [
                "autisme",
                "verstandelijk beperkt",
                "adhd"
            ]
        },
        {
            "id": 9,
            "title": "Toegankelijkheidstools voor Webontwikkelaars: Een Vergelijkende Analyse",
            "description": "Een vergelijkende analyse van verschillende tools die webontwikkelaars kunnen gebruiken om de toegankelijkheid van hun websites te verbeteren, met aandacht voor functionaliteit en gebruiksvriendelijkheid.",
            "tags": [
                "slechtziend",
                "blind"
            ]
        },
        {
            "id": 10,
            "title": "Digitale Toegankelijkheid in de Publieke Sector: Een Casestudy",
            "description": "Een casestudy die de status van digitale toegankelijkheid in de publieke sector onderzoekt, met aanbevelingen voor verbetering en implementatie van best practices.",
            "tags": [
                "adhd",
                "autisme",
            ]
        }
    ]);
    const [searchInput, setSearchInput] = useState('');
    const [searchedOnderzoeken, setSearchedOnderzoeken] = useState(onderzoeken);

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

    return (
        <div className="container">
            <h1 className="text-3xl py-10 font-bold">Lopende onderzoeken</h1>
            <div className="flex flex-row justify-end ms:flex-col">
                <form className="flex flex-row p-4 mb-4 rounded-lg bg-white p-6 border border-accessgray w-1/3 mr-4 relative">
                    <input id="search_input" value={searchInput} onChange={(e) => setSearchInput(e.target.value)} className="transition ease-in-out w-full focus:outline-none" placeholder="Klik hier om te zoeken" />
                </form>
                <button className="p-4 mb-4 rounded-lg bg-white p-6 border border-accessgray ml-1">Filter</button>
            </div>

            {onderzoeken &&
                <div className="flex justify-around flex-col items-center">
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
        </div>
    );
};

export default Onderzoek;

