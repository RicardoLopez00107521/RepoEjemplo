// src/components/forms/NewUserForm.jsx
import { useState } from 'react';
import './NewUserForm.css'; // Asegúrate de crear este archivo CSS

const NewUserForm = ({ onSuccess }) => {
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    phoneNumber: '',
    addres: '',
  });
  const [status, setStatus] = useState(null);

  const handleChange = ({ target }) => {
    setFormData(prev => ({ ...prev, [target.name]: target.value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setStatus(null);

    try {
      const response = await fetch('http://localhost:5105/api/user/newUser', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(formData),
      });

      const result = await response.json();

      if (!response.ok) throw new Error(result.message || 'Error al crear usuario');

      setStatus({ type: 'success', message: '✅ Usuario creado con éxito' });
      setFormData({ firstName: '', lastName: '', phoneNumber: '', addres: '' });

      if (onSuccess) onSuccess();
    } catch (error) {
      setStatus({ type: 'error', message: error.message });
    }
  };

  return (
    <form className="form-container" onSubmit={handleSubmit}>
      <h2 className="form-title">Crear Nuevo Usuario</h2>

      <input
        className="form-input"
        name="firstName"
        placeholder="Nombre"
        value={formData.firstName}
        onChange={handleChange}
        required
      />
      <input
        className="form-input"
        name="lastName"
        placeholder="Apellido"
        value={formData.lastName}
        onChange={handleChange}
        required
      />
      <input
        className="form-input"
        name="phoneNumber"
        placeholder="Teléfono"
        value={formData.phoneNumber}
        onChange={handleChange}
        required
      />
      <input
        className="form-input"
        name="addres"
        placeholder="Dirección"
        value={formData.addres}
        onChange={handleChange}
      />

      <button className="form-button" type="submit">Guardar</button>

      {status && (
        <p className={`form-status ${status.type}`}>
          {status.message}
        </p>
      )}
    </form>
  );
};

export default NewUserForm;
