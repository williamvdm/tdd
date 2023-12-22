const Login = () => {
    return (
        <>
            <table style={{ margin: 'auto', marginTop: '10%', marginBottom: '10%' }}>
                <tr>
                    <td colSpan="2" style={{ textAlign: 'center' }}>Login</td>
                </tr>
                <tr>
                    <td>Username:</td>
                    <td><input type="text" style={{ marginBottom: '10px', padding: '5px', background: 'white', borderColor: 'black', borderStyle: 'solid', borderWidth: '2px' }} /></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td><input type="password" style={{ marginBottom: '10px', padding: '5px', background: 'white', borderColor: 'black', borderStyle: 'solid', borderWidth: '2px' }} /></td>
                </tr>
                <tr>
                    <td colSpan="2" style={{ textAlign: 'center' }}><button style={{ marginBottom: '10px', padding: '5px', background: 'white', borderColor: 'black', borderStyle: 'solid', borderWidth: '2px', width: '100%'}}>Inloggen</button></td>
                </tr>
            </table>
            <br/>
            
        </>
    );
};

export default Login;
