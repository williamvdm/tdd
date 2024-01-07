import { useEffect, useState } from "react";
import db from '../db.json';

const Onderzoek = () => {
    const [onderzoeken, setOnderzoeken] = useState([
        {
            "id": 1,
            "title": "De Impact van Kunstmatige Intelligentie op de Samenleving",
            "description": "Dit onderzoek heeft tot doel de maatschappelijke gevolgen van grootschalige adoptie van kunstmatige intelligentie te onderzoeken en de effecten ervan op verschillende aspecten van het dagelijks leven.",
            "tags": [
                "kunstmatige intelligentie",
                "samenleving",
                "technologie"
            ]
        },
        {
            "id": 2,
            "title": "Strategieën voor Klimaatverandering Mitigatie: Een Uitgebreid Overzicht",
            "description": "Analyse en evaluatie van de effectiviteit van verschillende strategieën voor het verminderen van klimaatverandering, met nadruk op duurzaamheid en milieueffecten.",
            "tags": [
                "klimaatverandering",
                "milieu",
                "duurzaamheid"
            ]
        },
        {
            "id": 3,
            "title": "De Rol van Blockchain in Veilige Gegevenstransacties",
            "description": "Onderzoek naar hoe blockchaintechnologie de beveiliging en transparantie van gegevenstransacties in diverse sectoren, zoals financiën en gezondheidszorg, kan verbeteren.",
            "tags": [
                "blockchain",
                "beveiliging",
                "gegevenstransacties"
            ]
        },
        {
            "id": 4,
            "title": "Toegankelijkheid van Websites voor Mensen met ADHD",
            "description": "Een diepgaande analyse van de toegankelijkheid van websites voor mensen met ADHD, met een focus op het verbeteren van de gebruikerservaring en het verminderen van cognitieve belasting.",
            "tags": [
                "toegankelijkheid",
                "ADHD",
                "gebruikerservaring"
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
                "toegankelijkheid",
                "interviews",
                "gebruikerservaring"
            ]
        },
        {
            "id": 7,
            "title": "Effectiviteit van Online Trainingen voor Toegankelijkheidsbewustzijn",
            "description": "Een evaluatie van de effectiviteit van online trainingen voor het vergroten van het bewustzijn over toegankelijkheid van websites, met het oog op betere ontwerppraktijken.",
            "tags": [
                "toegankelijkheid",
                "online training",
                "bewustzijn"
            ]
        },
        {
            "id": 8,
            "title": "Inclusief Ontwerp: Het Belang van Diversiteit in Website-Interfaces",
            "description": "Onderzoek naar inclusieve ontwerppraktijken en het belang van diversiteit in website-interfaces voor het creëren van een betere digitale ervaring voor alle gebruikers.",
            "tags": [
                "inclusief ontwerp",
                "diversiteit",
                "website-interfaces"
            ]
        },
        {
            "id": 9,
            "title": "Toegankelijkheidstools voor Webontwikkelaars: Een Vergelijkende Analyse",
            "description": "Een vergelijkende analyse van verschillende tools die webontwikkelaars kunnen gebruiken om de toegankelijkheid van hun websites te verbeteren, met aandacht voor functionaliteit en gebruiksvriendelijkheid.",
            "tags": [
                "toegankelijkheid",
                "webontwikkelaars",
                "analyse"
            ]
        },
        {
            "id": 10,
            "title": "Digitale Toegankelijkheid in de Publieke Sector: Een Casestudy",
            "description": "Een casestudy die de status van digitale toegankelijkheid in de publieke sector onderzoekt, met aanbevelingen voor verbetering en implementatie van best practices.",
            "tags": [
                "digitale toegankelijkheid",
                "publieke sector",
                "best practices"
            ]
        }
    ]);

    return (
        <div className="container">
            <h1 className="text-2xl">Onderzoeken</h1>
            {onderzoeken &&
                <div className="flex justify-around flex-col items-center">
                    {onderzoeken.map(onderzoek => (
                        <div className="card shadow-md p-4 mb-4 rounded-lg bg-white shadow p-6 hover:shadow-lg border border-accessgray transition ease-in-out min-w-full" key={onderzoek.id}>
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
                                    className='bg-accessblue text-white py-2 px-4 rounded outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue'>
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