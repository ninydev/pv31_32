import React from "react";

export const  EmailContext = React.createContext();

export function EmailProvider({children}) {
    const [email, setEmail] = React.useState("");

    return (
        <EmailContext.Provider value={{ email, setEmail }}>
        {children}
        </EmailContext.Provider>
    );
}