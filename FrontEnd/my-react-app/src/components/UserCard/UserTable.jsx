import React, { useState, useEffect } from 'react';
import './UserTable.css'; // Puedes renombrarlo si quieres: EmployeeTable.css

function EmployeeTable() {
    const [employees, setEmployees] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        fetch('http://localhost:5105/api/employee/getAll') // Ajusta el endpoint real si es necesario
            .then(res => {
                if (!res.ok) throw new Error(`Error: ${res.status}`);
                return res.json();
            })
            .then(data => {
                setEmployees(data.data || []);
                setLoading(false);
            })
            .catch(err => {
                setError(err.message);
                setLoading(false);
            });
    }, []);

    if (loading) return <p>Cargando empleados...</p>;
    if (error) return <p>Error: {error}</p>;
    if (employees.length === 0) return <p>No se encontraron empleados.</p>;

    return (
        <div className="table-container">
            <table className="user-table">
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>Correo</th>
                        <th>Puesto</th>
                        <th>Departamento</th>
                        <th>Salario</th>
                        <th>Salario Diario</th>
                    </tr>
                </thead>
                <tbody>
                    {employees.map((emp, index) => (
                        <tr key={index}>
                            <td>{emp.fullName}</td>
                            <td>{emp.email}</td>
                            <td>{emp.jobTitle}</td>
                            <td>{emp.departmentName}</td>
                            <td>${emp.salary.toFixed(2)}</td>
                            <td>${emp.dailySalary.toFixed(2)}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default EmployeeTable;
