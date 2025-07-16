// src/pages/NewUserPage.jsx
import { useNavigate } from 'react-router-dom';
import UpdateUserPhoneForm from '../components/Forms/UpdateUserPhoneForm';

const UpdateUserPhonePage = () => {
  const navigate = useNavigate();

  const handleSuccess = () => {
    // Redirige a la lista de usuarios, por ejemplo
    navigate('/users/allUsers');
  };

  return (
    <div style={{ padding: '1rem' }}>
      <UpdateUserPhoneForm onSuccess={handleSuccess} />
    </div>
  );
};

export default UpdateUserPhonePage;