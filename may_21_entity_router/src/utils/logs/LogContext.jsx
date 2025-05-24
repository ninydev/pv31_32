import React, { createContext, useState, useEffect } from 'react';

export const LogContext = createContext();

export const LogProvider = ({children}) => {
    // State to store all logs
    const [logs, setLogs] = useState([]);

    // Load logs from localStorage on mount
    useEffect(() => {
        const savedLogs = localStorage.getItem('reactAppLogs');
        if (savedLogs) {
            try {
                setLogs(JSON.parse(savedLogs));
            } catch (e) {
                console.error('Failed to parse saved logs:', e);
            }
        }
    }, []);

    // Save logs to localStorage when they change
    useEffect(() => {
        localStorage.setItem('reactAppLogs', JSON.stringify(logs));
    }, [logs]);

    // Add a new log entry to the logs array
    const addLog = (type, ...args) => {
        const newLog = {
            id: Date.now(),
            timestamp: new Date().toISOString(),
            type,
            message: args.map(arg => 
                typeof arg === 'object' ? JSON.stringify(arg) : String(arg)
            ).join(' ')
        };

        setLogs(prevLogs => [...prevLogs, newLog]);
        return newLog;
    };

    const logger = {
        // Logging methods that both console log and store in state
        error: (...args) => {
            console.error('[ERROR]:', ...args);
            return addLog('error', ...args);
        },
        info: (...args) => {
            // console.info('[INFO]:', ...args);
            return addLog('info', ...args);
        },
        debug: (...args) => {
            // console.debug('[DEBUG]:', ...args);
            return addLog('debug', ...args);
        },
        trace: (...args) => {
            // console.trace('[TRACE]:', ...args);
            return addLog('trace', ...args);
        },

        // Methods to retrieve and manage logs
        getLogs: () => logs,
        getLogsByType: (type) => logs.filter(log => log.type === type),
        clearLogs: () => setLogs([]),

        // Method to display logs in UI (returns JSX)
        displayLogs: (filter = null) => {
            const filteredLogs = filter ? logs.filter(log => log.type === filter) : logs;

            return (
                <div className="log-display">
                    <h3>Application Logs {filter ? `(${filter})` : ''}</h3>
                    {filteredLogs.length === 0 ? (
                        <p>No logs to display</p>
                    ) : (
                        <ul className="log-list">
                            {filteredLogs.map(log => (
                                <li key={log.id} className={`log-item log-${log.type}`}>
                                    <span className="log-timestamp">{new Date(log.timestamp).toLocaleString()}</span>
                                    <span className="log-type">[{log.type.toUpperCase()}]</span>
                                    <span className="log-message">{log.message}</span>
                                </li>
                            ))}
                        </ul>
                    )}
                </div>
            );
        },

        // Method to show a message to the user (can be used with a notification system)
        showMessage: (message, type = 'info', duration = 3000) => {
            // Log the message
            addLog(type, message);

            // Return an object that can be used by a notification component
            return {
                id: Date.now(),
                message,
                type,
                duration
            };
        }
    };

    return (
        <LogContext.Provider value={logger}>
            {children}
        </LogContext.Provider>
    );
};
