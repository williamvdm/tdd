import { useEffect, useState } from 'react';
import { GoogleLogin } from '@react-oauth/google';
import './App.css';

function App() {
    const responseMessage = (response) => {
        console.log("Inlog succes")
        console.log(response);
        window.history.pushState(null, null, '/swagger/index.html');
    };
    const errorMessage = (error) => {
        console.log("Inlog gefaald")
        console.log(error);
    };

    return (
        <div>
            <h2>Aanmelden</h2>
            <br />
            <GoogleLogin
                theme="filled_blue"
                size="large"
                text="signup_with"
                width="300px"
                onSuccess={responseMessage}
                onError={errorMessage} />
        </div>
    );
}

export default App;