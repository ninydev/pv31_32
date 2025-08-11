// controllers/googleCallback.js
// Окремий контролер для обробки відповіді від Google OAuth
// Усі коментарі українською мовою

const passport = require('passport'); // Використовуємо спільний інстанс Passport

// handleGoogleCallback — функція‑обробник колбеку Google OAuth
// Вона логуватиме результат у файл та повертатиме JSON на фронт
function handleGoogleCallback(req, res, next) {
  const logger = require('../utils/logger');

  // Фіксуємо факт повернення від Google (без важких дампів запиту)
  logger.info('Google OAuth callback повернувся', {
    query: req.query,
  });

  passport.authenticate('google', { session: false }, (err, user, info) => {
    if (err) {
      logger.error('Помилка авторизації Google', { error: String(err) });
      return res.status(500).json({ message: 'Сталася помилка під час авторизації', error: String(err) });
    }

    if (!user) {
      logger.warn('Авторизацію відхилено або скасовано');
      return res.status(401).json({ message: 'Авторизацію відхилено або скасовано' });
    }

    // Логуємо ключову інформацію про користувача (без зайвих даних)
    const safeProfile = {
      id: user.profile && user.profile.id,
      displayName: user.profile && user.profile.displayName,
      emails: user.profile && user.profile.emails,
    };
    logger.info('Успішна авторизація через Google', { profile: safeProfile });
    // За потреби для дебагу: детальніше
    logger.debug('Деталі користувача', { user });

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
