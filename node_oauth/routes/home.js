// routes/home.js
// Головна сторінка застосунку
// Коментарі українською мовою

const express = require('express');
const router = express.Router();

// GET /
router.get('/', (req, res) => {
  // Коротка підказка як почати авторизацію
  res.send(
    '<h1>Node OAuth з Passport.js (Google)</h1>' +
      '<p>Щоб розпочати, перейдіть за посиланням: <a href="/auth/google">Увійти через Google</a></p>'
  );
});

module.exports = router;
