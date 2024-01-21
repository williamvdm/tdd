import React, { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Link } from "react-router-dom";

export default function OnderzoekEdit() {
    const { onderzoekid } = useParams();
    const [vraag, setVraag] = useState("");
    const navigate = useNavigate();

    const handleAddQuestion = async (event) => {
        event.preventDefault();
        console.log("Formulier verzonden");

        // Check if onderzoekid is defined before making the API request
        if (onderzoekid) {
            try {
                const response = await fetch(
                    `http://localhost/api/Onderzoek/${onderzoekid}/vraag/add`,
                    {
                        method: "POST",
                        body: JSON.stringify({
                            vraagID: 0,
                            onderzoekID: onderzoekid,
                            vraag: vraag,
                            antwoorden: []
                        }),
                        headers: {
                            "Content-type": "application/json; charset=UTF-8",
                        },
                    }
                );
            } catch (error) {
                console.error("Verbinding met endpoint mislukt", error);
            }
        } else {
            console.error("onderzoekid is undefined");
        }
    };

    return (
        <div className="container mx-auto my-10 p-6 bg-white border border-gray-300 rounded-lg shadow-lg max-w-screen-md">
            <h1>Onderzoek bewerken</h1>
            <form onSubmit={handleAddQuestion}>
                <label>
                    Vraag:
                    <input
                        type="text"
                        name="titel"
                        className="border-gray-300 border p-2 rounded"
                        value={vraag}
                        onChange={(e) => setVraag(e.target.value)}
                    />
                </label>
                <br />
                <button type="submit" className="mr-2 outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue text-black p-2 px-4 rounded-lg transition ease-in-out flex items-center focus:outline-accessblue">Voeg toe</button>
                <Link to="/dashboard/bedrijf" className="mr-2 outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue text-black p-2 px-4 rounded-lg transition ease-in-out flex items-center focus:outline-accessblue">Klaar</Link>
            </form>
        </div>
    );
}
