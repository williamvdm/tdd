import React from 'react';
import { Navigate, Route } from 'react-router-dom';

const AuthRoute = ({ element }) => {
  const isAuthenticated = localStorage.getItem('token') !== null;

  return isAuthenticated ? (
    element
  ) : (
    <Navigate to="/login" replace />
  );
};

export default AuthRoute;