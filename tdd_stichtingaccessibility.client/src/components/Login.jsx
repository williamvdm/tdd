import { GoogleLogin } from '@react-oauth/google';
import { useNavigate } from 'react-router-dom';
import { jwtDecode } from 'jwt-decode';

function Login() {
    const navigate = useNavigate();

    const responseMessage = (response) => {
        console.log("Inlog succes");
        console.log(jwtDecode(response.credential));

        // In de browser storage opslaan
        localStorage.setItem('credential', response.credential);

        // Navigeer naar de andere pagina
        navigate('/dashboard');
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