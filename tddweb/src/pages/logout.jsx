import React, { useEffect } from 'react';

export default function LogOut() {
  useEffect(() => {
    localStorage.removeItem('token');
    window.location.href = '/';
  }, []);

  return null;
};
