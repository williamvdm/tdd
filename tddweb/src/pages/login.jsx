import { GoogleLogin } from '@react-oauth/google';
import '../css/login.css'; 

function Login() {
    
    const handleLogin = (event) => {
        event.preventDefault();
        console.log('Formulier verzonden');
    };

    return (
        <>
        <div className='login-container'>
            <h1>Login</h1>
            <form onSubmit={handleLogin}>
                <div>
                    <label htmlFor="gebruikersnaam" aria-required="true"> Gebruikersnaam: <span class="verplicht">(verplicht)</span></label>
                    <input type="text" id="gebruikersnaam" required />
                </div>
                <div>
                    <label htmlFor="wachtwoord" aria-required="true">Wachtwoord: <span class="verplicht">(verplicht)</span></label>
                    <input type="password" id="wachtwoord" required />
                </div>

                <div>
                    <button>Inloggen</button>
                </div>
            </form>

                <div className="scheiding" role="seperator" aria-label="Scheidinstekst">
                    <span className="scheiding-tekst">of gebruik Google Login:</span>
                </div>

                <div  id="googlelogin">
                    <GoogleLogin
                            onSuccess={credentialResponse => {
                                console.log(credentialResponse);
                            }}
                            onError={() => {
                                console.log('Het inloggen is niet gelukt.');
                            }}
                        />
                </div>
        </div>
        </>
    );
};

export default Login;