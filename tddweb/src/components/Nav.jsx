import { Link } from 'react-router-dom';

export default function Nav() {
    return (
        <nav className="shadow-md mb-6 p-4 bg-accessblue">
            <div className="container mx-auto flex justify-between items-center">
                <Link to="/" className="text-white text-lg font-bold text-2xl">Ablox</Link>
                <ul className="flex space-x-4">
                    <li><Link to="/login" className="text-white hover:underline-offset-8 hover:underline">Inloggen</Link></li>
                    <li className="group">
                        <span className="text-white hover:underline-offset-8 hover:underlin">Portaal</span>
                        <ul className="hidden group-hover:block absolute z-10">
                            <li><Link to="/portaal/ervaringsdeskundige" className="text-black hover:underline">Ervaringsdeskundige</Link></li>
                            <li><Link to="/portaal/bedrijven" className="text-black hover:underline">Bedrijven</Link></li>
                            <li><Link to="/dashboard/onderzoek" className="text-black hover:underline">Onderzoek</Link></li>
                        </ul>
                    </li>
                    <li><Link to="/chat" className="text-white hover:underline-offset-8 hover:underline">Chat</Link></li>
                </ul>
            </div>
        </nav>
    );
}
