import express from 'express';
import cors from 'cors';
import dotenv from 'dotenv';

// Load environment variables from .env
dotenv.config();

const app = express();

// CORS configuration (allow all origins by default)
app.use(cors());

// Parse JSON bodies (not strictly needed for GET /colors but useful for future)
app.use(express.json());

// Health/root route (optional helpful info)
app.get('/', (req, res) => {
  res.json({
    name: process.env.SERVER_NAME || 'ColorsAPI',
    endpoints: ['/colors'],
    status: 'ok'
  });
});

// Single endpoint that returns available colors
app.get('/api/colors', (req, res) => {
  const colors = [
    'red', 'green', 'blue', 'yellow', 'orange', 'purple', 'pink', 'brown', 'black', 'white',
    'cyan', 'magenta', 'lime', 'teal', 'indigo', 'violet', 'gray', 'silver', 'gold'
  ];
  res.json({ colors });
});

const PORT = Number(process.env.PORT) || 3000;
const SERVER_NAME = process.env.SERVER_NAME || 'ColorsAPI';

app.listen(PORT, () => {
  console.log(`[${SERVER_NAME}] listening on http://localhost:${PORT}`);
});
