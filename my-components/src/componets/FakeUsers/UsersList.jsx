import {useEffect, useState} from "react";
import UserItem from "./UserItem.jsx";

const API_URL = 'https://68161aff32debfe95dbd7598.mockapi.io/users'

export default function UsersList() {

    // Зминна для корисувачів
    const [users, setUsers] = useState([])

    // Змінна для завантаження
    const [loading, setLoading] = useState(false)

    // Змінна для помилки
    const [error, setError] = useState(null)

    // pagination
    const [page, setPage] = useState(1)
    const [limit, setLimit] = useState(3)


    // Функція для отримання даних


    const fetchUsersAsync = async () => {
        setLoading(false)
        setError(null)

        try {
            // const response = await fetch(API_URL)
            const response = await fetch(`${API_URL}?limit=${limit}&page=${page}&sortBy=name`)
            if (!response.ok) throw new Error('Failed to fetch data')
            const data = await response.json()
            setUsers(data)
        } catch (error) {
            setError(error)
        } finally {
            setLoading(true)
        }
    }

    const fetchUsersPromise = () => {
        setLoading(false)
        setError(null)

        fetch(`${API_URL}?limit=${limit}&page=${page}&sortBy=name`)
            .then((response) => {
                if (!response.ok) throw new Error('Failed to fetch data: ' + response?.statusText)
                return response.json()
            })
            .then((data) => {
                setUsers((prevUsers) => [...prevUsers, ...data])
            })
            .catch((error) => {
                setError(error)
            })
            .finally(() => {
                setLoading(true)
            })
    }

    // fetchUsersPromise()

    // useEffect(() => {
    //     fetchUsersPromise()
    // }, [])

    useEffect(() => {
        fetchUsersPromise()
    }, [page, limit])

    const loadNext = (e) => {
        e.preventDefault();
        setPage((prevPage) => prevPage + 1)
    }


    if (error) {
        console.error(error)
        return (
            <div>Error: {error?.message}</div>
        )
    }

    if (!loading) return (
        <div>Loading...</div>
    )

    return (<>
        <ul>
            {users.map(user => (
                <UserItem key={user.id} user={user}>
                </UserItem>
            ))}
        </ul>
        <button onClick={loadNext}>Next</button>
    </>)
}