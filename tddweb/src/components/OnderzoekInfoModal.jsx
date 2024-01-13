import React from 'react';
import { FaTimes } from 'react-icons/fa';

const OnderzoekInfoModal = ({ onderzoek, closeModal }) => {
    return (
        <div
            className="fixed inset-0 z-50 flex items-center justify-center bg-gray-800 bg-opacity-50"
            role="dialog"
            aria-modal="true"
            tabIndex="-1"
        >
            <div className="bg-white p-8 rounded-lg lg:w-1/4 lg:h-1/3 md:w-full sm:w-full focus:outline-none relative">
                <button
                    className="absolute top-2 right-2 text-gray-700 hover:outline-solid hover:outline-2 hover:outline-accessblue rounded-lg transition ease-in-out flex items-center focus:outline-accessblue"
                    onClick={closeModal}
                >
                    <FaTimes size={20} />
                </button>
                <h2 className="text-2xl font-bold mb-4">{onderzoek.titel}</h2>
                <p className="text-gray-800 mb-4">{onderzoek.beschrijving}</p>
                <p className="text-gray-800">Begindatum: {onderzoek.begindatum}</p>
                <p className="text-gray-800">Einddatum: {onderzoek.einddatum}</p>
                <button
                    className="absolute bottom-4 right-4 bg-accessblue outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue text-white p-2 px-4 rounded-lg transition ease-in-out flex items-center focus:outline-accessblue"
                    aria-label={`Deelnemen aan onderzoek ${onderzoek.title}`}
                >
                    Deelnemen
                </button>
            </div>
        </div>
    );
};

export default OnderzoekInfoModal;


