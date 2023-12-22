import { Link } from 'react-router-dom';

export default function Nav() {
    return (
        <nav class="shadow mb-6 p-4">
            <div class="container mx-auto flex justify-between items-center">
                <Link to="/" className="text-black text-lg font-bold text-2xl">Ablox</Link>
                <ul class="flex space-x-4">
                    <li><Link to="/login" className="text-black hover:underline-offset-8 hover:underline">Inloggen</Link></li>
                    <li className="group">
                        <span className="text-black cursor-pointer group-hover:underline">Portaal</span>
                        <ul className="hidden group-hover:block absolute z-10">
                            <li><Link to="/ervaringsdeskundigeportaal" className="text-black hover:underline">Ervaringsdeskundigeportaal</Link></li>
                            <li><Link to="/bedrijven" className="text-black hover:underline">Bedrijven</Link></li>
                            <li><Link to="/onderzoek" className="text-black hover:underline">Onderzoek</Link></li>
                        </ul>
                    </li>
                    <li><Link to="/chat" className="text-black hover:underline-offset-8 hover:underline">Chat</Link></li>
                </ul>
            </div>
        </nav>
    );
}
