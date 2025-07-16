import React from 'react';
import { Routes, Route } from 'react-router-dom';

import AllUsers from '../pages/AllUserPage';
import AllRoles from '../pages/AllRolePage';
import NewUserPage from '../pages/NewUserPage';
import UpdateUserPhonePage from '../pages/UpdateUserPhonePage';
import DeleteUserPage from '../pages/DeleteUserPage';

function AppRoutes() {
    return (
        <Routes>
            <Route path='/' element={<h2>Bienvenido a la app!</h2>}/>
            <Route path='/users/allUsers' element={<AllUsers />}/>
            <Route path='/roles/allRoles' element={<AllRoles />}/>
            <Route path="/users/new" element={<NewUserPage />} />
            <Route path="/users/update-user-phone" element={<UpdateUserPhonePage />} />
            <Route path="/users/delete-user" element={<DeleteUserPage />} />
        </Routes>
    );
}

export default AppRoutes;