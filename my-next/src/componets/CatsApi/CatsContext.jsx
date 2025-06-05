'use client';

import React, { createContext, useContext, useState } from 'react';
import { catsApiClient } from './catsApiClient';

// Create the context
const CatsContext = createContext();

// Create the provider component
export function CatsProvider({ children }) {
    const [cats, setCats] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    // Function to fetch cats data
    const fetchCats = async (searchParams = {}) => {
        setLoading(true);
        setError(null);

        searchParams.limit = 10;

        try {
            // Call the server action to fetch cats
            console.log("Client Side ", searchParams);
            const response = await catsApiClient(searchParams);
            setCats(response);
        } catch (err) {
            setError(err.message);
            console.error('Error fetching cats:', err);
        } finally {
            setLoading(false);
        }
    };

    // Create the context value object
    const contextValue = {
        cats,
        loading,
        error,
        fetchCats
    };

    return (
        <CatsContext.Provider value={contextValue}>
            {children}
        </CatsContext.Provider>
    );
}

// Custom hook to use the cats context
export function useCats() {
    const context = useContext(CatsContext);
    
    if (!context) {
        throw new Error('useCats must be used within a CatsProvider');
    }
    
    return context;
}