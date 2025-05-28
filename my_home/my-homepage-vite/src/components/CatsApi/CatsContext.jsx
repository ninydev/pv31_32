import React from "react";
import {catsApiClient} from "./catsApiClient.js";

const CatsContext = React.createContext()

export const CatsProvider = ({ children }) => {
    const [cats, setCats] = React.useState([]);
    const [loading, setLoading] = React.useState(false);
    const [error, setError] = React.useState(null);

    const fetchCats = async (searchParams = {}) => {
        setLoading(true);
        setError(null);

        try {
            const response = await catsApiClient(searchParams);
            setCats(response);
        } catch (err) {
            setError(err.message);
        } finally {
            setLoading(false);
        }
    };

    return (
        <CatsContext.Provider value={{ cats, loading, error, fetchCats }}>
            {children}
        </CatsContext.Provider>
    );
}

export const useCats = () => {
    const context = React.useContext(CatsContext);
    if (!context) {
        throw new Error("useCats must be used within a CatsProvider");
    }
    return context;
};
