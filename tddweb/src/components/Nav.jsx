import React, { useState } from 'react';
import { Link } from 'react-router-dom';

function Nav() {
    return (
        <nav className="shadow-md mb-6 p-4 bg-accessblue">
            <div className="container mx-auto flex justify-between items-center">
                <Link to="/" className="text-white text-lg font-bold text-2xl" aria-label="Logo van Ablox">
                    Ablox
                </Link>
            </div>
        </nav>
    );
};

export default Nav;
