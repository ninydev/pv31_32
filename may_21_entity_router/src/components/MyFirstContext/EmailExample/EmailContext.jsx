import React, { useEffect } from "react";

export const  EmailContext = React.createContext();

export function EmailProvider({children}) {
    const [email, setEmail] = React.useState("");

    // Read email from localStorage on component mount
    useEffect(() => {
        const savedEmail = localStorage.getItem('email');
        if (savedEmail) {
            setEmail(savedEmail);
        }
    }, []);

    // Save email to localStorage when it changes
    useEffect(() => {
        localStorage.setItem('email', email);
    }, [email]);

    return (
        <EmailContext.Provider value={{ email, setEmail }}>
        {children}
        </EmailContext.Provider>
    );
}
