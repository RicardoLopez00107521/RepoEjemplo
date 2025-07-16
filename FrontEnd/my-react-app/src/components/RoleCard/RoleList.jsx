import React, {useState, useEffect} from 'react';
import RoleCard from './RoleCard';

function RoleList() {
    const[roles, setRoles] = useState([]);
    const[loading, setLoading] = useState(true);
    const[error, setError] = useState(null);

    useEffect(() => {
        fetch('http://localhost:5105/api/role/getAll')
            .then(res => {
                if(!res.ok) throw new Error(`Error: ${res.status}`);
                return res.json();
            })
            .then(data => {
                setRoles(data.data || []);
                setLoading(false);
            })
            .catch(err => {
                setError(err.message);
                setLoading(false);
            });
    }, []);

    if (loading) return <p>Obteniendo roles....</p>;
    if (error) return <p>Error: {error}</p>;
    if (roles.length === 0) return <p>No se encontraron roles!</p>;

    return (
        <div>
            {roles.map(role => (
                <RoleCard
                    key={role.roleId}
                    roleName={role.roleName}
                    userRoles={role.users}
                />
            ))}
        </div>
    );
}

export default RoleList;