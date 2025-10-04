import http from 'http';
import dotenv from 'dotenv';
import { Server } from 'socket.io';

// Load environment variables from .env
dotenv.config();

const PORT = Number(process.env.PORT) || 5000;
const SERVER_NAME = process.env.SERVER_NAME || 'SimpleSocketServer';

// Basic HTTP server (for health check and to host the Socket.IO upgrade)
const httpServer = http.createServer((req, res) => {
  if (req.method === 'GET' && req.url === '/') {
    const payload = {
      name: SERVER_NAME,
      status: 'ok',
      socketEndpoints: ['io namespace / (default)'],
    };
    res.writeHead(200, { 'Content-Type': 'application/json' });
    res.end(JSON.stringify(payload));
    return;
  }
  res.writeHead(404, { 'Content-Type': 'application/json' });
  res.end(JSON.stringify({ error: 'Not found' }));
});

// Attach Socket.IO with permissive CORS (similar openness as CORS in API example)
const io = new Server(httpServer, {
  cors: {
    origin: '*',
    methods: ['GET', 'POST']
  }
});

io.on('connection', (socket) => {
  // Optionally you can identify a user; here we just use the socket id
  const joinMsg = {
    type: 'user:joined',
    message: `A new user connected: ${socket.id}`,
    usersCount: io.engine.clientsCount
  };

  // Broadcast to everyone (including the new user)
  io.emit('user:joined', joinMsg);

  // Send a private welcome message to the connected user
  socket.emit('welcome', {
    message: 'Welcome to the Socket.IO server!',
    yourId: socket.id,
    usersCount: io.engine.clientsCount
  });

  // When user disconnects, broadcast the leave event
  socket.on('disconnect', (reason) => {
    const leaveMsg = {
      type: 'user:left',
      message: `User disconnected: ${socket.id}`,
      reason,
      usersCount: io.engine.clientsCount
    };
    io.emit('user:left', leaveMsg);
  });
});

httpServer.listen(PORT, () => {
  console.log(`[${SERVER_NAME}] Socket.IO server listening on http://localhost:${PORT}`);
});
