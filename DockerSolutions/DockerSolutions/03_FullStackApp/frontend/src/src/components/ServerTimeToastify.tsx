"use client";

import React, { useEffect, useRef } from 'react';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';


const ServerTimeToastify: React.FC = () => {
    const urlRef = useRef<string | undefined>(process.env.NEXT_PUBLIC_SSE_TIME_URL);
    const lastPayloadRef = useRef<string | null>(null);

    useEffect(() => {
        const url = urlRef.current;
        if (!url) {
            console.warn('NEXT_PUBLIC_SSE_TIME_URL is not defined.');
            return;
        }

        const es = new EventSource(url);

        es.onmessage = (e: MessageEvent) => {
            // предотвращаем дубли, если провайдер шлёт одинаковые сообщения
            if (e.data && e.data === lastPayloadRef.current) return;
            lastPayloadRef.current = e.data;

            try {
                const payload = JSON.parse(e.data) as { time?: string; [k: string]: unknown };
                const time = payload.time ?? e.data;
                toast.info(`Server time: ${time}`, {
                    position: 'top-left',
                    autoClose: 3000,
                    closeOnClick: true,
                    pauseOnHover: true,
                    hideProgressBar: false,
                });
            } catch {
                toast.info(`Event: ${e.data}`, { autoClose: 3000 });
            }
        };

        es.onerror = (err) => {
            console.error('SSE error:', err);
            // EventSource сам переподключается, просто показываем уведомление один раз при первом сбое
            toast.error('SSE connection error. Attempting to reconnect...');
        };

        return () => {
            es.close();
        };
    }, []);

    return (
        <div>
            <ToastContainer newestOnTop closeOnClick />
        </div>
    );
};

export default ServerTimeToastify;