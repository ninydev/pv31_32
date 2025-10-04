import React, { useEffect } from 'react';
import { Admin, Resource, ListGuesser } from 'react-admin';
import { SnackbarProvider, useSnackbar } from 'notistack';
import { io } from 'socket.io-client';
import dataProvider from './dataProvider.js';
import ColorsList from './ColorsList.jsx';

const SOCKET_URL = import.meta.env.VITE_SOCKET_URL || 'http://localhost:5000';

function SocketListener() {
  const { enqueueSnackbar } = useSnackbar();

  useEffect(() => {
    const socket = io(SOCKET_URL, {
      transports: ['websocket', 'polling'],
    });

    // Welcome message could be used too
    socket.on('welcome', (payload) => {
      enqueueSnackbar(payload?.message || 'Connected to socket', { variant: 'success' });
    });

    socket.on('user:joined', (payload) => {
      enqueueSnackbar(payload?.message || 'User joined', { variant: 'info' });
    });

    socket.on('user:left', (payload) => {
      enqueueSnackbar(payload?.message || 'User left', { variant: 'warning' });
    });

    socket.on('connect_error', (err) => {
      enqueueSnackbar(`Socket error: ${err.message}`, { variant: 'error' });
    });

    return () => {
      socket.disconnect();
    };
  }, [enqueueSnackbar]);

  return null; // no UI
}

function AdminApp() {
  return (
    <Admin dataProvider={dataProvider}>
      <Resource name="colors" list={ColorsList || ListGuesser} />
    </Admin>
  );
}

export default function App() {
  return (
    <SnackbarProvider maxSnack={5} autoHideDuration={3000} anchorOrigin={{ vertical: 'top', horizontal: 'right' }}>
      <SocketListener />
      <AdminApp />
    </SnackbarProvider>
  );
}
