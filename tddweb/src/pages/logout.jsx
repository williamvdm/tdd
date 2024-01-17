import React, { useEffect } from 'react';

const LogOut = () => {
  useEffect(() => {
    localStorage.removeItem('token');
    window.location.href = '/';
  }, []);

  return null;
};

export default LogOut;