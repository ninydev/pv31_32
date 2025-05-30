'use client';

import { useEffect } from 'react';
import { useCats } from './CatsContext';
import { CatsListItem } from './CatsListItem';

export function CatsList() {
    const { cats, loading, error, fetchCats } = useCats();

    // Fetch cats data when the component mounts
    useEffect(() => {
        fetchCats();
    }, []);

    if (loading) {
        return (
            <div className="p-4 text-center">
                <div className="animate-spin rounded-full h-12 w-12 border-t-2 border-b-2 border-blue-500 mx-auto"></div>
                <p className="mt-2">Loading cats...</p>
            </div>
        );
    }

    if (error) {
        return (
            <div className="p-4 text-center text-red-500">
                <p>Error: {error}</p>
                <button 
                    onClick={() => fetchCats()} 
                    className="mt-2 px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600"
                >
                    Try Again
                </button>
            </div>
        );
    }

    return (
        <div className="p-4">
            <h2 className="text-2xl font-bold mb-4">Cats Gallery</h2>
            
            <button 
                onClick={() => fetchCats()} 
                className="mb-4 px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600"
            >
                Refresh Cats
            </button>
            
            <ul className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4">
                {cats.map(cat => (
                    <CatsListItem key={cat.id} cat={cat} />
                ))}
            </ul>
        </div>
    );
}