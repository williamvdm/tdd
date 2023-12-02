import { useEffect } from 'react';  // Import useEffect from React

import { GoogleLogin } from '@react-oauth/google';
import { useNavigate } from 'react-router-dom';
import { jwtDecode } from "jwt-decode";
import { useUser } from '../store/UserStore';

function extractUserInformation(response) {
    return jwtDecode(response.credential);
}

function Login() {
    const navigate = useNavigate();
    const { user, setUser } = useUser();

    useEffect(() => {
        console.log("Current User:", user); /*Deze geeft de user*/

        if (user) {
            navigate('/dashboard');
        }
    }, [user]);

    const responseMessage = (response) => {
        console.log("Inlog succes");
        setUser(jwtDecode(response.credential));
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
