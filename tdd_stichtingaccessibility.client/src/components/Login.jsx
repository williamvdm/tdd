import { GoogleLogin } from '@react-oauth/google';
import { useNavigate } from 'react-router-dom';
import { jwtDecode } from 'jwt-decode';

function Login() {
    const navigate = useNavigate();

    const responseMessage = (response) => {
        console.log("Inlog succes");
        console.log(jwtDecode(response.credential));
        // Eerste manier:
        // In de browser storage opslaan en later opvragen daaruit
        // Geheime stuff meesturen om daar wat mee te kunnen
        // Nog een manier:
        // React vanuit componenten stuff meegeven, maar blijf maar bij de eerste manier
        // Uitzoeken wat de verschillende browser storages zijn en welke het handigst is en hoe je het gebruikt in JavaScript.
        // Nog een 3e manier:
        // COOKIES
        navigate('/dashboard', { credential: response.credential });
    };

    const errorMessage = (error) => {
        console.log("Inlog gefaald");
        console.log(error);
    };

    return (
        <div>
            <GoogleLogin
                theme="filled_blue"
                size="large"
                text="signup_with"
                onSuccess={responseMessage}
                onError={errorMessage}
            />
        </div>
    );
}

export default Login;