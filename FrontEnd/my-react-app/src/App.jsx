import React from 'react';
import { BrowserRouter as Router, Link } from 'react-router-dom';
import AppRoutes from './routes/AppRoutes';

function App() {
  return (
    <Router>
      <nav style={{ marginBottom: '20px' }}>
        <Link to="/">Inicio</Link> |{' '}
        <Link to="/users/allUsers">Usuarios</Link> |{' '}
        <Link to="/roles/allRoles">Roles</Link>
      </nav>

      <AppRoutes />
    </Router>
  );
}

export default App;
