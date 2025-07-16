import { useState } from 'react';
import './UpdateUserPhoneForm.css'; // Estilos personalizados

const DeleteUserForm = ({ onSuccess }) => {
  const [formData, setFormData] = useState({
    userId: '',
  });
  const [status, setStatus] = useState(null);

  const handleChange = ({ target }) => {
    setFormData(prev => ({ ...prev, [target.name]: target.value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setStatus(null);

    const id = parseInt(formData.userId);

    try {
      const response = await fetch(`http://localhost:5105/api/user/delete-user/${id}`, {
        method: 'DELETE',
      });

      const result = await response.json();

      if (!response.ok) throw new Error(result.message || 'Error al eliminar el usuario');

      setStatus({ type: 'success', message: '✅ Usuario eliminado con éxito' });
      setFormData({ userId: '' });

      if (onSuccess) onSuccess();
    } catch (error) {
      setStatus({ type: 'error', message: error.message });
    }
  };

  return (
    <form className="form-container" onSubmit={handleSubmit}>
      <h2 className="form-title">Eliminar usuario</h2>

      <input
        className="form-input"
        type="number"
        name="userId"
        placeholder="ID del Usuario"
        value={formData.userId}
        onChange={handleChange}
        required
      />

      <button className="form-button" type="submit">Eliminar</button>

      {status && (
        <p className={`form-status ${status.type}`}>
          {status.message}
        </p>
      )}
    </form>
  );
};

export default DeleteUserForm;
