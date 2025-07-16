import React, {useState, useEffect } from 'react';
import UserCard from './UserCard';

function UserList() {
    const [users, setUsers] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        fetch('http://localhost:5105/api/user/getAll')
            .then(res => {
                if (!res.ok) throw new Error(`Error: ${res.status}`);
                return res.json();
            })
            .then(data => {
                setUsers(data.data || []);
                setLoading(false);
            })
            .catch(err => {
                setError(err.message);
                setLoading(false);
            });
    }, []);

    if (loading) return <p>Obteniendo usuarios....</p>;
    if (error) return <p>Error: {error}</p>;
    if (users.length === 0) return <p>No se econctraron usuarios!</p>;

    return (
        <div>
            {users.map(user => (
                <UserCard
                    key={user.userId}
                    firstName={user.firstName}
                    lastName={user.lastName}
                    phoneNumber={user.phoneNumber}
                    addres={user.addres}
                    userRoles={user.roles}
                />
            ))}
        </div>
    );
}

export default UserList;