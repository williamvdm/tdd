import React from 'react';
import { Link } from 'react-router-dom';

const Nav = () => {
  const handleLogout = () => {
    localStorage.removeItem("token");
    window.location.href = '/';
  };

  const isUserLoggedIn = !!localStorage.getItem("token");

  return (
    <nav className="shadow-md mb-6 p-4 bg-accessblue">
      <div className="container mx-auto flex justify-between items-center">
        <Link to="/" className="text-white text-lg font-bold text-2xl" aria-label="Logo van Ablox">
          Ablox
        </Link>
        <ul className="flex space-x-4">
          {isUserLoggedIn && (
            <li>
              <button
                onClick={handleLogout}
                className="text-white hover:underline-offset-8 hover:underline"
              >
                Uitloggen
              </button>
            </li>
          )}
        </ul>
      </div>
    </nav>
  );
};

export default Nav;
