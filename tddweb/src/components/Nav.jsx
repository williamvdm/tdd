import React, { useState } from 'react';
import { Link } from 'react-router-dom';

function Nav() {
    return (
<<<<<<< HEAD
        <nav class="shadow p-4">
            <div class="container mx-auto flex justify-between items-center">
                <Link to="/" className="text-black text-lg font-bold text-2xl">Ablox</Link>
                <ul class="flex space-x-4">
                    <li><Link to="/login" className="text-black hover:underline-offset-8 hover:underline">Inloggen</Link></li>
                    <li><Link to="/registreer" className="text-black hover:underline-offset-8 hover:underline">Registreer</Link></li>
                    <li className="group">
                        <span className="text-black cursor-pointer group-hover:underline">Portaal</span>
                        <ul className="hidden group-hover:block absolute z-10">
                            <li><Link to="/portaal/ervaringsdeskundige" className="text-black hover:underline">Ervaringsdeskundige</Link></li>
                            <li><Link to="/portaal/bedrijven" className="text-black hover:underline">Bedrijven</Link></li>
                            <li><Link to="/portaal/onderzoek" className="text-black hover:underline">Onderzoek</Link></li>
                        </ul>
                    </li>
                    <li><Link to="/chat" className="text-black hover:underline-offset-8 hover:underline">Chat</Link></li>
                </ul>
=======
        <nav className="shadow-md mb-6 p-4 bg-accessblue">
            <div className="container mx-auto flex justify-between items-center">
                <Link to="/" className="text-white text-lg font-bold text-2xl" aria-label="Logo van Ablox">
                    Ablox
                </Link>
>>>>>>> develop
            </div>
        </nav>
    );
};

export default Nav;
