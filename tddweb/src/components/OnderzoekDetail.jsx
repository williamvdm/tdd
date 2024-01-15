import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import React from 'react';

function OnderzoekDetail() {
    const { onderzoekid } = useParams();
    const [onderzoekData, setOnderzoekData] = useState(null)
    const [isOnderzoekLoading, setIsOnderzoekLoading] = useState(true)

    useEffect(() => {
        try {
            console.log("Begin fetch");
            fetch(`https://ablox.azurewebsites.net/api/Onderzoek/${onderzoekid}`)
                .then(res => res.json())
                .then(data => {
                    console.log(data);
                    setOnderzoekData(data);
                    setIsOnderzoekLoading(false);
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
        {onderzoekData && <h1 className="text-4xl py-10">{onderzoekData.titel}</h1> }
        <div className="flex flex-col items-center p-4 mb-4 rounded-lg bg-white p-6 border border-gray min-w-[300px] w-full">
        {isOnderzoekLoading && <img className="w-24" src="https://www.icegif.com/wp-content/uploads/2023/07/icegif-1263.gif"></img>}
        {onderzoekData && <div className="container">
            <h3>Beschrijving: {onderzoekData.beschrijving }</h3>
            {onderzoekData.bedrijfMail && <p>Uitgevoerd door: {onderzoekData.bedrijfMail}</p>}
            <p>Begindatum: {onderzoekData.begindatum}</p>
            <p>Einddatum: {onderzoekData.einddatum}</p>
            <p>Beloning: {onderzoekData.beloningBeschrijving}</p>
            <button className="mt-10 bg-accessblue outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue text-white p-2 px-4 rounded-lg transition ease-in-out flex items-center focus:outline-accessblue">Begin vragenlijst</button>
            </div>}
        </div>
    </>
);
};

export default OnderzoekDetail;
