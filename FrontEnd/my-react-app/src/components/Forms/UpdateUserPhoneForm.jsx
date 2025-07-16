import { useState } from 'react';
import './UpdateUserPhoneForm.css'; // Estilos personalizados

const UpdateUserPhoneForm = ({ onSuccess }) => {
  const [formData, setFormData] = useState({
    userId: '',
    newNumber: '',
  });
  const [status, setStatus] = useState(null);

  const handleChange = ({ target }) => {
    setFormData(prev => ({ ...prev, [target.name]: target.value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setStatus(null);

    try {
      const response = await fetch('http://localhost:5105/api/user/update-phone-number', {
        method: 'PATCH',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          userId: parseInt(formData.userId),
          newNumber: formData.newNumber,
        }),
      });

      const result = await response.json();

      if (!response.ok) throw new Error(result.message || 'Error al actualizar el número');

      setStatus({ type: 'success', message: '📱 Teléfono actualizado con éxito' });
      setFormData({ userId: '', newNumber: '' });

      if (onSuccess) onSuccess();
    } catch (error) {
      setStatus({ type: 'error', message: error.message });
    }
  };

  return (
    <form className="form-container" onSubmit={handleSubmit}>
      <h2 className="form-title">Actualizar Teléfono</h2>

      <input
        className="form-input"
        type="number"
        name="userId"
        placeholder="ID del Usuario"
        value={formData.userId}
        onChange={handleChange}
        required
      />
      <input
        className="form-input"
        type="number"
        name="newNumber"
        placeholder="Nuevo Número Telefónico"
        value={formData.newNumber}
        onChange={handleChange}
        required
      />

      <button className="form-button" type="submit">Actualizar</button>

      {status && (
        <p className={`form-status ${status.type}`}>
          {status.message}
        </p>
      )}
    </form>
  );
};

export default UpdateUserPhoneForm;
