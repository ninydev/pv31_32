import React from "react";
import {useCats} from "./CatsContext.jsx";
import {CatsListItem} from "./CatsListItem.jsx";

export function CatsList() {
    const { cats, loading, error, fetchCats } = useCats();

    React.useEffect( () => {
        if (!loading) {
             fetchCats();
        } else {
            console.log('CatsList: cats: ', cats);
        }
    }, []);

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>Error: {error}</div>;
    }

    return (
        <div>
            <h2>Cats List</h2>
            <ul>
                {cats.map(cat => (
                    <CatsListItem key={cat.id} cat={cat} />
                ))}
            </ul>
        </div>
    );
}