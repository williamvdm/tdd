import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";


export default function OnderzoekEdit() {
    const currentURL = window.location.href;
    const urlParams = new URLSearchParams(currentURL);
    const onderzoekid = urlParams.get('onderzoekid');

    let navigate = useNavigate();

    const [onderzoekData, setOnderzoekData] = useState({
        titel: "string",
        beschrijving: "string",
        bedrijfMail: "string",
        begindatum: "2024-01-18",
        einddatum: "2024-01-18",
        locatie: {
            postCode: "string",
            plaatsNaam: "string",
            straatNaam: "string",
            huisnummer: 0,
        },
        beloningBeschrijving: "string",
    });

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setOnderzoekData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    const handleAddQuestion = async (event) => {
        event.preventDefault();
        console.log("Formulier verzonden");
        console.log(onderzoekData);
        try {
            const response = await fetch(
                `http://localhost/api/Onderzoek/${onderzoekid}/vraag/add`,
                {
                    method: "POST",
                    body: {
                        vraagID: 0,
                        onderzoekID: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                        vraag: "Hoe heet Laurens?",
                        antwoorden: []
                    },
                    headers: {
                        "Content-type": "application/json; charset=UTF-8",
                    },
                }
            );

            if (response.status === 200) {
                navigate("/dashboard/bedrijf");
            } else {
                console.error("Iets klopt niet");
            }
        } catch (error) {
            console.error("Verbinding met endpoint mislukt", error);
        }
    };

    return (

        <div className="container mx-auto my-10 p-6 bg-white border border-gray-300 rounded-lg shadow-lg max-w-screen-md">
            <h1>Onderzoek Bewerken</h1>
            <form onSubmit={handleAddQuestion}>
                <label>
                    Titel: 
                    <input
                        type="text"
                        name="titel"
                        className="border-gray-300 border p-2 rounded"
                        value={onderzoekData.titel}
                        onChange={handleInputChange}
                    />
                </label>
                <br />
                <button type="submit" className="mr-2 outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue text-black p-2 px-4 rounded-lg transition ease-in-out flex items-center focus:outline-accessblue">Create Onderzoek</button>
            </form>
        </div>
    );
}
