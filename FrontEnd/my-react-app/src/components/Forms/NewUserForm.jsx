import { useState } from 'react';
import './NewUserForm.css'; // Puedes reutilizar los estilos del usuario

const NewEmployeeForm = ({ onSuccess }) => {
  const [formData, setFormData] = useState({
    idEmployee: '',
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    hireDate: '',
    idJob: '',
    salary: '',
    comissionPct: '',
    managerId: '',
    idDepartment: ''
  });

  const [status, setStatus] = useState(null);

  const handleChange = ({ target }) => {
    setFormData(prev => ({
      ...prev,
      [target.name]: target.value
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setStatus(null);

    try {
      const response = await fetch('http://localhost:5105/api/employee/new', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          ...formData,
          idEmployee: parseInt(formData.idEmployee),
          salary: parseFloat(formData.salary),
          managerId: parseInt(formData.managerId),
          idDepartment: parseInt(formData.idDepartment),
        })
      });

      const result = await response.json();

      if (!response.ok) throw new Error(result.message || 'Error al crear empleado');

      setStatus({ type: 'success', message: '✅ Empleado creado con éxito' });
      setFormData({
        idEmployee: '',
        firstName: '',
        lastName: '',
        email: '',
        phoneNumber: '',
        hireDate: '',
        idJob: '',
        salary: '',
        comissionPct: '',
        managerId: '',
        idDepartment: ''
      });

      if (onSuccess) onSuccess();
    } catch (error) {
      setStatus({ type: 'error', message: error.message });
    }
  };

  return (
    <form className="form-container" onSubmit={handleSubmit}>
      <h2 className="form-title">Registrar Empleado</h2>

      <input className="form-input" name="idEmployee" placeholder="ID Empleado" value={formData.idEmployee} onChange={handleChange} required />
      <input className="form-input" name="firstName" placeholder="Nombre" value={formData.firstName} onChange={handleChange} required />
      <input className="form-input" name="lastName" placeholder="Apellido" value={formData.lastName} onChange={handleChange} required />
      <input className="form-input" name="email" placeholder="Correo" value={formData.email} onChange={handleChange} required />
      <input className="form-input" name="phoneNumber" placeholder="Teléfono" value={formData.phoneNumber} onChange={handleChange} required />
      <input className="form-input" type="date" name="hireDate" placeholder="Fecha de Contratación" value={formData.hireDate} onChange={handleChange} required />
      <input className="form-input" name="idJob" placeholder="Puesto (ID del trabajo)" value={formData.idJob} onChange={handleChange} required />
      <input className="form-input" type="number" step="0.01" name="salary" placeholder="Salario" value={formData.salary} onChange={handleChange} required />
      <input className="form-input" name="comissionPct" placeholder="Comisión (%)" value={formData.comissionPct} onChange={handleChange} />
      <input className="form-input" name="managerId" placeholder="ID del Manager" value={formData.managerId} onChange={handleChange} />
      <input className="form-input" name="idDepartment" placeholder="ID Departamento" value={formData.idDepartment} onChange={handleChange} required />

      <button className="form-button" type="submit">Guardar</button>

      {status && (
        <p className={`form-status ${status.type}`}>
          {status.message}
        </p>
      )}
    </form>
  );
};

export default NewEmployeeForm;
