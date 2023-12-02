import { useEffect } from 'react';
import { useUser } from '../store/UserStore';

function Dashboard() {
    const { user } = useUser();

    useEffect(() => {
        console.log("Dashboard: ", user); /*Deze geeft undefined maar moet ook de user geven*/
    }, [user]);

    return (
        <h1>Dashboard</h1>
    );
}

export default Dashboard;