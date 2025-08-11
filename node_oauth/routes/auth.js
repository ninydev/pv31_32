// routes/auth.js
// Маршрути для авторизації через Google
// Коментарі українською мовою

const express = require('express');
const passport = require('passport'); // Спільний інстанс Passport
const { handleGoogleCallback } = require('../controllers/googleCallback');

const router = express.Router();

// 1) Редирект на Google OAuth (початок авторизації)
//    Скоупи: профіль і email користувача
router.get('/google', passport.authenticate('google', { scope: ['profile', 'email'] }));

// 2) Колбек Google OAuth — обробка відповіді
router.get('/google/callback', handleGoogleCallback);

// 3) Необовʼязковий маршрут на випадок помилки
router.get('/google/failure', (req, res) => {
  res.status(401).send('Не вдалося авторизуватися через Google');
});

module.exports = router;
