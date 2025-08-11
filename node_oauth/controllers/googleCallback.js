// controllers/googleCallback.js
// Окремий контролер для обробки відповіді від Google OAuth
// Усі коментарі українською мовою

const passport = require('passport'); // Використовуємо спільний інстанс Passport

// handleGoogleCallback — функція‑обробник колбеку Google OAuth
// Вона логуватиме результат у консоль та повертатиме JSON на фронт
function handleGoogleCallback(req, res, next) {
  passport.authenticate('google', { session: false }, (err, user, info) => {
    if (err) {
      console.error('Помилка авторизації Google:', err);
      return res.status(500).json({ message: 'Сталася помилка під час авторизації', error: String(err) });
    }

    if (!user) {
      return res.status(401).json({ message: 'Авторизацію відхилено або скасовано' });
    }

    // Логуємо результат у консоль сервера (для навчальних цілей)
    console.log('Успішна авторизація через Google. Дані користувача:');
    console.log(JSON.stringify(user, null, 2));

    // Відповідь на фронт
    return res.status(200).json({
      message: 'Успішна авторизація через Google',
      // У продакшені уникайте розсилання токенів без нагальної потреби
      tokens: {
        accessToken: user.accessToken,
        refreshToken: user.refreshToken || null,
      },
      profile: user.profile,
    });
  })(req, res, next);
}

module.exports = { handleGoogleCallback };
