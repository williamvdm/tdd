import { Link } from 'react-router-dom';

export default function Nav() {
    return (
        <nav class="shadow mb-6 p-4">
            <div class="container mx-auto flex justify-between items-center">
                <a href="/" class="text-black text-lg font-bold text-2xl">Ablox</a>
                <ul class="flex space-x-4">
                    <li><a href="/login" class="text-black hover:underline-offset-8 hover:underline">Inloggen</a></li>
                    <li><a href="/ervaringsdeskundigeportaal" class="text-black hover:underline-offset-8 hover:underline">Ervaringsdeskundigeportaal</a></li>

                </ul>
            </div>
        </nav>
    )
};

