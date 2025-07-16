// src/pages/NewUserPage.jsx
import { useNavigate } from 'react-router-dom';
import NewUserForm from '../components/Forms/NewUserForm';

const NewUserPage = () => {
  const navigate = useNavigate();

  const handleSuccess = () => {
    // Redirige a la lista de usuarios, por ejemplo
    navigate('/users/allUsers');
  };

  return (
    <div style={{ padding: '1rem' }}>
      <NewUserForm onSuccess={handleSuccess} />
    </div>
  );
};

export default NewUserPage;
