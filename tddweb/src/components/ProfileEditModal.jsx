import { useEffect, useRef, useState } from "react";
import React from 'react';

// Profiel bewerken modal NIET AF
const ProfileEditModal = ({ user, closeModal }) => {
    const modalRef = useRef(null);
    const [formData, setFormData] = useState({
        username: user.username || "",
        password: "",
        email: user.email || "",
        mobilephone: user.mobilephone || "",
        beperkingen: user.beperkingen || [],
        hulpmiddelen: user.hulpmiddelen || [],
    });

    return (
        <div
            className="fixed inset-0 z-50 flex items-center justify-center bg-gray-800 bg-opacity-50"
            role="dialog"
            aria-modal="true"
            tabIndex="-1"
        >
            <div className="bg-white p-8 rounded-lg lg:w-1/4 lg:h-1/2 md:w-full sm:w-full focus:outline-none relative">
                <button
                    className="absolute top-2 right-2 text-gray-700 hover:outline-solid hover:outline-2 hover:outline-accessblue rounded-lg transition ease-in-out flex items-center focus:outline-accessblue"
                    onClick={closeModal}
                    aria-label="Venster sluiten"
                >
                    X
                </button>
                <h2 className="text-2xl font-bold mb-4">Profiel bewerken</h2>

                <form className="flex flex-col space-y-4">
                    <label htmlFor="password">Wachtwoord:</label>
                    <input
                        type="password"
                        id="password"
                        name="password"
                        value={formData.password}
                        onChange={(e) => setFormData({ ...formData, password: e.target.value })}
                        className="border-gray-300 border p-2 rounded"
                    />

                    <label htmlFor="email">E-mail:</label>
                    <input
                        type="email"
                        id="email"
                        name="email"
                        value={formData.email}
                        onChange={(e) => setFormData({ ...formData, email: e.target.value })}
                        className="border-gray-300 border p-2 rounded"
                    />

                    <label htmlFor="voorkeurBenadering">Telefoon:</label>
                    <input
                        type="text"
                        id="voorkeurBenadering"
                        name="voorkeurBenadering"
                        value={formData.mobilephone}
                        onChange={(e) => setFormData({ ...formData, mobilephone: e.target.value })}
                        className="border-gray-300 border p-2 rounded"
                    />

                    <label htmlFor="beperkingen">Beperkingen:</label>
                    <h4>Slechtziend</h4>

                    <label htmlFor="hulpmiddelen">Hulpmiddelen:</label>
                    <h4>Screenreader</h4>
                </form>
            </div>
        </div>
    );
};

export default ProfileEditModal;
