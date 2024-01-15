import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

export default function OnderzoekVragenlijst() {
    const { onderzoekid } = useParams();
    const [onderzoekVragen, setOnderzoekVragen] = useState();

    useEffect(() => {
        try {
            console.log("Begin fetch");
            fetch(`https://ablox.azurewebsites.net/api/Onderzoek/${onderzoekid}/vragen  `)
                .then(res => res.json())
                .then(data => {
                    console.log(data);
                    setOnderzoekVragen(data);
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
            {onderzoekVragen == null && <h1>Vragen laden...</h1>}
            {onderzoekVragen && onderzoekVragen.map((vraag) => (
                <>
                    <div className="card shadow-md p-4 mb-4 rounded-lg bg-white p-6 border border-gray transition ease-in-out min-w-full" key={vraag.vraagID}>
                        <h3 className="text-2xl py-10">{vraag.vraag}</h3>
                        <form className="flex flex-row p-4 mb-4 rounded-lg bg-white p-6 border border-gray w-full">
                            <input
                                id={vraag.vraagid}
                                value=""
                                // onChange={(e) => setAnswer(e.target.value)}
                                className="transition ease-in-out w-full h-full focus:outline-none focus:ring focus:border-accessblue"
                                placeholder="Typ hier je antwoord..."
                            />
                        </form>
                    </div>
                </>
            ))}
            {onderzoekVragen &&
            <div className="flex justify-end">
                <button className="bg-accessblue outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue text-white p-2 px-4 rounded-lg transition ease-in-out flex items-center focus:outline-accessblue">
                    Vragenlijst afronden
                </button>
            </div>}
        </>
    );
}
