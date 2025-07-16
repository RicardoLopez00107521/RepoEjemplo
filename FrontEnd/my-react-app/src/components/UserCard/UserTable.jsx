import React, { useState, useEffect } from 'react';
import './UserTable.css'; // Este archivo contendrá los estilos

function UserTable() {
    const [users, setUsers] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        fetch('http://localhost:5105/api/User/getAll')
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
    if (users.length === 0) return <p>¡No se encontraron usuarios!</p>;

    return (
        <div className="table-container">
            <table className="user-table">
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>Teléfono</th>
                        <th>Dirección</th>
                        <th>Roles</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(user => (
                        <tr key={user.userId}>
                            <td>{user.firstName} {user.lastName}</td>
                            <td>{user.phoneNumber}</td>
                            <td>{user.addres}</td>
                            <td>
                                {user.roles.map((role, index) => (
                                    <span key={index} className="role-badge">{role}</span>
                                ))}
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default UserTable;
