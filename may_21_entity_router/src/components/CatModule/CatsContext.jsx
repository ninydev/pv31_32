import React, { createContext, useState, useEffect, useCallback } from 'react';

// Create the context
export const CatsContext = createContext();

// Base URL for the API
const API_URL = 'http://localhost:3000/cats';

export const CatsProvider = ({ children }) => {
  // State for storing cats data
  const [cats, setCats] = useState([]);
  // Loading state for async operations
  const [loading, setLoading] = useState(false);
  // Error state for handling API errors
  const [error, setError] = useState(null);

  const [page, setPage] = useState(1);
  const [limit, setLimit] = useState(10);
  const [sortBy, setSortBy] = useState('name');
  const [order, setOrder] = useState('desc');



  // Fetch all cats from the API
  const fetchCats = useCallback(async () => {
    setLoading(true);
    setError(null);
    try {
      const searchParams
          = new URLSearchParams({page, limit, sortBy, order});

      console.log(API_URL + `?${searchParams.toString()}`);
      const response = await fetch(API_URL + `?${searchParams.toString()}`);
      if (!response.ok) {
        throw new Error(`Error fetching cats: ${response.statusText}`);
      }
      // console.log('Response:', response);
      const data = await response.json();
      setCats(data);
    } catch (err) {
      setError(err.message);
      console.error('Error fetching cats:', err);
    } finally {
      setLoading(false);
    }
  }, [page, limit, sortBy, order]);

  // Fetch a single cat by ID
  const fetchCatById = useCallback(async (id) => {
    setLoading(true);
    setError(null);
    try {
      const response = await fetch(`${API_URL}/${id}`);
      if (!response.ok) {
        throw new Error(`Error fetching cat: ${response.statusText}`);
      }
      const data = await response.json();
      return data;
    } catch (err) {
      setError(err.message);
      console.error(`Error fetching cat with ID ${id}:`, err);
      return null;
    } finally {
      setLoading(false);
    }
  }, []);

  // Create a new cat
  const createCat = useCallback(async (catData) => {
    setLoading(true);
    setError(null);
    try {
      const response = await fetch(API_URL, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(catData),
        credentials: 'include',
      });
      if (!response.ok) {
        throw new Error(`Error creating cat: ${response.statusText}`);
      }
      const newCat = await response.json();
      setCats(prevCats => [...prevCats, newCat]);
      return newCat;
    } catch (err) {
      setError(err.message);
      console.error('Error creating cat:', err);
      return null;
    } finally {
      setLoading(false);
    }
  }, []);

  // Update an existing cat
  const updateCat = useCallback(async (id, catData) => {
    setLoading(true);
    setError(null);
    try {
      const response = await fetch(`${API_URL}/${id}`, {
        method: 'PATCH',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(catData),
        credentials: 'include',
      });
      if (!response.ok) {
        throw new Error(`Error updating cat: ${response.statusText}`);
      }
      const updatedCat = await response.json();
      setCats(prevCats => 
        prevCats.map(cat => cat.id === id ? updatedCat : cat)
      );
      return updatedCat;
    } catch (err) {
      setError(err.message);
      console.error(`Error updating cat with ID ${id}:`, err);
      return null;
    } finally {
      setLoading(false);
    }
  }, []);

  // Delete a cat
  const deleteCat = useCallback(async (id) => {
    setLoading(true);
    setError(null);
    try {
      const response = await fetch(`${API_URL}/${id}`, {
        method: 'DELETE',
        credentials: 'include',
      });
      if (!response.ok) {
        throw new Error(`Error deleting cat: ${response.statusText}`);
      }
      // For 204 No Content response, there's no body to parse
      setCats(prevCats => prevCats.filter(cat => cat.id !== id));
      return true;
    } catch (err) {
      setError(err.message);
      console.error(`Error deleting cat with ID ${id}:`, err);
      return false;
    } finally {
      setLoading(false);
    }
  }, []);

  // Load cats when the component mounts
  useEffect(() => {
    console.log('CatsContext - useEffect');
    fetchCats();
  }, [ page, limit, sortBy, order]);

  // Create the context value object with all the methods and state
  const catsContextValue = {
    // State
    cats,
    loading,
    error,
    // Methods
    fetchCats,
    fetchCatById,
    createCat,
    updateCat,
    deleteCat,
    // Pagination and sorting
    page, limit, sortBy, order,
    // Helper methods
    setPage, setLimit, setSortBy, setOrder,
    clearError: () => setError(null),
  };

  return (
    <CatsContext.Provider value={catsContextValue}>
      {children}
    </CatsContext.Provider>
  );
};

// Custom hook for using the cats context
export const useCats = () => {
  const context = React.useContext(CatsContext);
  if (context === undefined) {
    throw new Error('useCats must be used within a CatsProvider');
  }
  return context;
};