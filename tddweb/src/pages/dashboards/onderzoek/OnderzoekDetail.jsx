import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import React from 'react';
import { Link } from 'react-router-dom';

// Details van een specifiek onderzoek ophalen waar je aan kunt deelnemen
export default function OnderzoekDetail() {
    const { onderzoekid } = useParams();
    const [onderzoekData, setOnderzoekData] = useState(null)
    const [isOnderzoekLoading, setIsOnderzoekLoading] = useState(true)

    useEffect(() => {
        try {
            console.log("Begin fetch");
            fetch(`http://localhost/api/Onderzoek/${onderzoekid}`)
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
        <div className="container mx-auto my-10 p-6 bg-white border border-gray-300 rounded-lg shadow-lg max-w-screen-md">
            {onderzoekData && (
                <>
                    <div className="mb-4 flex items-center">
                        <div>
                            <h1 className="text-4xl mb-2">{onderzoekData.titel}</h1>
                            {isOnderzoekLoading && (
                                <img className="w-16 h-16" src="https://www.icegif.com/wp-content/uploads/2023/07/icegif-1263.gif" alt="Loading" />
                            )}
                        </div>
                    </div>
                    <div>
                        <div className="mb-4">
                            <div className="flex items-center">
                                <strong>Beschrijving:</strong>
                            </div>
                            {onderzoekData.beschrijving}
                        </div>
                        {onderzoekData.bedrijfMail && (
                            <div className="mb-4">
                                <div className="flex items-center">
                                    <strong>Uitgevoerd door:</strong>
                                </div>
                                {onderzoekData.bedrijfMail}
                            </div>
                        )}
                        <div className="mb-4">
                            <div className="flex items-center">
                                <strong>Begindatum:</strong>
                            </div>
                            {onderzoekData.begindatum}
                        </div>
                        <div className="mb-4">
                            <div className="flex items-center">
                                <strong>Einddatum:</strong>
                            </div>
                            {onderzoekData.einddatum}
                        </div>
                        <div className="mb-4">
                            <div className=" flex items-center">
                                <strong>Beloning:</strong>
                            </div>
                            {onderzoekData.beloningBeschrijving}
                        </div>
                        <div className="flex justify-center">
                            <Link
                                to={`/onderzoek/${onderzoekid}/vragenlijst`}
                                className="mt-5 bg-accessblue text-white p-3 px-6 rounded-lg transition ease-in-out focus:outline-none focus:shadow-outline-blue"
                            >
                                Begin vragenlijst
                            </Link>
                        </div>
                    </div>
                </>
            )}
        </div>
    );
};
