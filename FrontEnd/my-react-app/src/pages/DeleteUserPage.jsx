// src/pages/NewUserPage.jsx
import { useNavigate } from 'react-router-dom';
import DeleteUserForm from '../components/Forms/DeleteUserForm';

const DeleteUserPage = () => {
  const navigate = useNavigate();

  const handleSuccess = () => {
    // Redirige a la lista de usuarios, por ejemplo
    navigate('/users/allUsers');
  };

  return (
    <div style={{ padding: '1rem' }}>
      <DeleteUserForm onSuccess={handleSuccess} />
    </div>
  );
};

export default DeleteUserPage;