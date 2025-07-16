import { useState } from 'react';
import './NewUserForm.css'; // Reutiliza estilos del formulario de creación

const UpdateEmployeeForm = ({ onSuccess }) => {
  const [idEmployee, setIdEmployee] = useState('');
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    hireDate: '',
    idJob: '',
    salary: '',
    comissionPct: '',
    managerId: '',
    idDepartment: '',
  });

  const [status, setStatus] = useState(null);

  const handleChange = ({ target }) => {
    const { name, value } = target;
    if (name === 'idEmployee') {
      setIdEmployee(value);
    } else {
      setFormData(prev => ({
        ...prev,
        [name]: value,
      }));
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setStatus(null);

    if (!idEmployee) {
      setStatus({ type: 'error', message: '❌ ID de empleado es requerido' });
      return;
    }

    // Construir payload solo con campos no vacíos
    const updatePayload = {};
    for (const [key, value] of Object.entries(formData)) {
      if (value !== '') {
        updatePayload[key] = ['salary', 'managerId', 'idDepartment'].includes(key)
          ? parseFloat(value)
          : value;
      }
    }

    try {
      const response = await fetch(`http://localhost:5105/api/employee/update/${idEmployee}`, {
        method: 'PATCH',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(updatePayload),
      });

      const result = await response.json();

      if (!response.ok) throw new Error(result.message || 'Error al actualizar el empleado');

      setStatus({ type: 'success', message: '✅ Empleado actualizado con éxito' });
      setIdEmployee('');
      setFormData({
        firstName: '',
        lastName: '',
        email: '',
        phoneNumber: '',
        hireDate: '',
        idJob: '',
        salary: '',
        comissionPct: '',
        managerId: '',
        idDepartment: '',
      });

      if (onSuccess) onSuccess();
    } catch (error) {
      setStatus({ type: 'error', message: error.message });
    }
  };

  return (
    <form className="form-container" onSubmit={handleSubmit}>
      <h2 className="form-title">Actualizar Empleado</h2>

      <input
        className="form-input"
        name="idEmployee"
        placeholder="ID Empleado"
        value={idEmployee}
        onChange={handleChange}
        required
      />
      <input className="form-input" name="firstName" placeholder="Nombre" value={formData.firstName} onChange={handleChange} />
      <input className="form-input" name="lastName" placeholder="Apellido" value={formData.lastName} onChange={handleChange} />
      <input className="form-input" name="email" placeholder="Correo" value={formData.email} onChange={handleChange} />
      <input className="form-input" name="phoneNumber" placeholder="Teléfono" value={formData.phoneNumber} onChange={handleChange} />
      <input className="form-input" type="date" name="hireDate" placeholder="Fecha de Contratación" value={formData.hireDate} onChange={handleChange} />
      <input className="form-input" name="idJob" placeholder="Puesto (ID del trabajo)" value={formData.idJob} onChange={handleChange} />
      <input className="form-input" type="number" step="0.01" name="salary" placeholder="Salario" value={formData.salary} onChange={handleChange} />
      <input className="form-input" name="comissionPct" placeholder="Comisión (%)" value={formData.comissionPct} onChange={handleChange} />
      <input className="form-input" name="managerId" placeholder="ID del Manager" value={formData.managerId} onChange={handleChange} />
      <input className="form-input" name="idDepartment" placeholder="ID Departamento" value={formData.idDepartment} onChange={handleChange} />

      <button className="form-button" type="submit">Actualizar</button>

      {status && (
        <p className={`form-status ${status.type}`}>
          {status.message}
        </p>
      )}
    </form>
  );
};

export default UpdateEmployeeForm;
