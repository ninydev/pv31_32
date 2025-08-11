// app.js
// УВАГА: Усі коментарі українською мовою, як було запрошено.

// 1) Завантажуємо змінні середовища з файлу .env
require('dotenv').config();

// 2) Імпортуємо необхідні бібліотеки
const express = require('express'); // веб‑фреймворк для створення HTTP‑сервера
const passport = require('passport'); // Passport.js — бібліотека для автентифікації
const GoogleStrategy = require('passport-google-oauth20').Strategy; // Стратегія Google OAuth 2.0

// 3) Читаємо змінні середовища
const PORT = process.env.PORT || 3000; // Порт сервера
const GOOGLE_CLIENT_ID = process.env.GOOGLE_AUTH_CLIENT_ID; // Клієнтський ID Google
const GOOGLE_CLIENT_SECRET = process.env.GOOGLE_AUTH_CLIENT_SECRET; // Клієнтський секрет Google
const GOOGLE_REDIRECT_URI = process.env.GOOGLE_AUTH_REDIRECT_URI; // Redirect URI (повинен збігатися з налаштуваннями у консолі Google)

// 4) Перевіряємо наявність обовʼязкових змінних середовища
if (!GOOGLE_CLIENT_ID || !GOOGLE_CLIENT_SECRET || !GOOGLE_REDIRECT_URI) {
  // Використовуємо файл-логер замість консолі
  require('./utils/logger').error('Помилка конфігурації: Перевірте .env — відсутні GOOGLE_AUTH_CLIENT_ID, GOOGLE_AUTH_CLIENT_SECRET або GOOGLE_AUTH_REDIRECT_URI');
  process.exit(1);
}

// 5) Налаштовуємо стратегію Passport Google OAuth 2.0
//    Ми не використовуємо сесії, а повертаємо дані користувача напряму у колбеку.
passport.use(
  new GoogleStrategy(
    {
      clientID: GOOGLE_CLIENT_ID,
      clientSecret: GOOGLE_CLIENT_SECRET,
      callbackURL: GOOGLE_REDIRECT_URI,
    },
    // verify callback — викликається Google після успішної авторизації
    // accessToken — токен доступу; refreshToken — токен оновлення (може бути відсутнім);
    // profile — публічний профіль користувача Google
    (accessToken, refreshToken, profile, done) => {
      // Формуємо обʼєкт "user", який повернемо у маршруті колбеку
      const user = {
        profile,
        accessToken,
        refreshToken: refreshToken || null,
      };
      // Повертаємо результат у Passport
      done(null, user);
    }
  )
);

// 6) Створюємо застосунок Express та підключаємо Passport (без сесій)
const app = express();
app.use(passport.initialize());

// 6.1) Глобальні обробники необроблених помилок — щоб не загубити їх у консолі
const logger = require('./utils/logger');
process.on('uncaughtException', (err) => {
  logger.error('uncaughtException', { error: String(err), stack: err && err.stack });
});
process.on('unhandledRejection', (reason) => {
  logger.error('unhandledRejection', { reason: String(reason) });
});

// 7) Підключаємо маршрути
const authRoutes = require('./routes/auth'); // Маршрути авторизації
const homeRoutes = require('./routes/home'); // Головна сторінка

app.use('/auth', authRoutes);
app.use('/', homeRoutes);

app.use((req, res, next) => {
  const start = Date.now();
  res.on('finish', () => {
    const duration = Date.now() - start;
    logger.info('HTTP', {
      method: req.method,
      url: req.originalUrl || req.url,
      status: res.statusCode,
      durationMs: duration,
    });
  });
  next();
});

// 8) Запускаємо сервер на вказаному порту
app.listen(PORT, () => {
  logger.info(`Сервер запущено на порту ${PORT}. Відкрийте http://localhost:${PORT}`);
});
