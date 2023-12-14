import { Link } from 'react-router-dom';

export default function Nav() {
    return (
        <nav className="shadow mb-6 p-4">
            <div className="container mx-auto flex justify-between items-center">
                <a href="/" className="text-black text-lg font-bold text-2xl">Ablox</a>
                <ul className="flex space-x-4">
                    <li><a href="/login" className="text-black hover:underline-offset-8 hover:underline">Inloggen</a></li>
                </ul>
            </div>
        </nav>
    )
};

