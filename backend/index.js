// backend/index.js
import express from 'express';
import multer from 'multer';

const app = express();

app.use((req, res, next) => {
    res.header('Access-Control-Allow-Origin', '*');
    res.header('Access-Control-Allow-Methods', 'GET,POST,PUT,DELETE,OPTIONS');
    res.header('Access-Control-Allow-Headers', 'Content-Type,Authorization');
    if (req.method === 'OPTIONS') {
        return res.sendStatus(204);
    }
    next();
});
const port = 3000;

// Configure multer for file uploads
const upload = multer({ dest: 'uploads/' });

// Route to handle file uploads
app.post('/upload', upload.single('file'), (req, res) => {
    if (!req.file) {
        return res.status(400).send('No file uploaded.');
    }
    res.send(`File uploaded successfully: ${req.file.originalname}`);
});

// Start the server
app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`);
});