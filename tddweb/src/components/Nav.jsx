import { Link } from 'react-router-dom';

export default function Nav() {
    return (
    
        <nav className="sticky top-0 z-10 shadow-md mb-6 p-4 bg-accessblue">
            <div className="container mx-auto flex justify-between items-center">
                <Link to="/" className="text-white text-lg font-bold text-2xl" aria-label="Logo van Ablox">Ablox</Link>
             
            </div>
        </nav>
    );
}
