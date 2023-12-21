import { Link } from 'react-router-dom';

export default function Nav() {
    return (
        <nav class="shadow p-4">
            <div class="container mx-auto flex justify-between items-center">
                <a href="/" class="text-black text-lg font-bold text-2xl"><img src="\src\assets\Logo Icon\icon_accessibility.png" width="64px" height="64px"></img></a>
                <ul class="flex space-x-4">
                    <li><a href="/login" class="text-black hover:underline-offset-8 hover:underline">Inloggen</a></li>
                    <li><a href="/ervaringsdeskundigeportaal" class="text-black hover:underline-offset-8 hover:underline">Ervaringsdeskundige</a></li>
                    <li><a href="/bedrijven" class="text-black hover:underline-offset-8 hover:underline">Bedrijven</a></li>
                </ul>
            </div>
        </nav>
    )
};

