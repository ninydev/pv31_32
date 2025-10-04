import React, { useEffect, useMemo, useState } from 'react';
import toast from 'react-hot-toast';
import { io } from 'socket.io-client';

const API_URL = process.env.NEXT_PUBLIC_API_URL || 'http://localhost:4000';
const SOCKET_URL = process.env.NEXT_PUBLIC_SOCKET_URL || 'http://localhost:5000';

export default function HomePage() {
  const [colors, setColors] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // Memoize socket instance to avoid reconnect loops
  const socket = useMemo(() => {
    // Only run on client
    if (typeof window === 'undefined') return null;
    return io(SOCKET_URL, {
      transports: ['websocket', 'polling'],
      autoConnect: true,
      reconnection: true,
      reconnectionAttempts: Infinity,
      reconnectionDelay: 500,
      reconnectionDelayMax: 5000,
      timeout: 20000,
      withCredentials: false,
    });
  }, []);

  useEffect(() => {
    async function fetchColors() {
      try {
        setLoading(true);
        const res = await fetch(`${API_URL}/colors`);
        if (!res.ok) throw new Error(`HTTP ${res.status}`);
        const data = await res.json();
        setColors(Array.isArray(data.colors) ? data.colors : []);
        setError(null);
      } catch (e) {
        console.error('Failed to load colors', e);
        setError('Не удалось загрузить цвета');
      } finally {
        setLoading(false);
      }
    }
    fetchColors();
  }, []);

  useEffect(() => {
    if (!socket) return;

    // Ensure connection is established (handles React Strict Mode dev double-mount)
    if (!socket.connected) {
      try { socket.connect(); } catch (e) { /* noop */ }
    }

    const onConnect = () => {
        console.log('Connected')
      toast.success('Socket connected');
    };

    const onConnectError = (err) => {
      console.error('Socket connect_error', err);
      toast.error(`Ошибка сокета: ${err?.message || err}`);
    };

    const onDisconnect = (reason) => {
      console.warn('Socket disconnected:');
      console.error(reason)
      if (reason !== 'io client disconnect') {
        toast('Соединение сокета разорвано', { icon: '⚠️' });
      }
    };

    const onJoined = (payload) => {
        console.log('Socket onJoined');
      toast.success(payload?.message || 'Новый пользователь подключился');
    };

    const onLeft = (payload) => {
        console.log('Socket onLeft');
      toast((payload?.message || 'Пользователь отключился'), { icon: '👋' });
    };

    const onWelcome = (payload) => {
      toast(`Добро пожаловать! Ваш ID: ${payload?.yourId || ''}`);
    };

    socket.on('connect', onConnect);
    socket.on('connect_error', onConnectError);
    socket.on('disconnect', onDisconnect);
    socket.on('user:joined', onJoined);
    socket.on('user:left', onLeft);
    socket.on('welcome', onWelcome);

    return () => {
      socket.off('connect', onConnect);
      socket.off('connect_error', onConnectError);
      socket.off('disconnect', onDisconnect);
      socket.off('user:joined', onJoined);
      socket.off('user:left', onLeft);
      socket.off('welcome', onWelcome);
      // Do not disconnect here to avoid losing connection under React Strict Mode in dev
    };
  }, [socket]);

  return (
    <div className="container">
      <div className="header">
        <h1>Публичная страница: Доступные цвета</h1>
        <div className="hint">
          API: <code>{API_URL}</code> • Socket: <code>{SOCKET_URL}</code>
        </div>
      </div>

      {loading && <p>Загрузка...</p>}
      {error && <p style={{color: 'crimson'}}>{error}</p>}

      {!loading && !error && (
        <>
          <div className="row">
            <button onClick={() => window.location.reload()}>Обновить</button>
          </div>
          <div style={{ height: 12 }} />
          <div className="colors">
            {colors.map((c) => (
              <span key={c} className="color" style={{ background: '#eee', border: '1px solid #ddd' }}>
                {c}
              </span>
            ))}
            {colors.length === 0 && <p>Список пуст.</p>}
          </div>
        </>
      )}
    </div>
  );
}
