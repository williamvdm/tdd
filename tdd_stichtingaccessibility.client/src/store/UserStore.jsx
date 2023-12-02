import { useState } from "react";

export function useUser() {
    const [user, setUser] = useState();

    const setUserValue = (newValue) => {
        setUser(newValue);
    };

    return { user, setUser: setUserValue };
}
