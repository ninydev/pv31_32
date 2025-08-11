// utils/logger.js
// Простіший файл-логер: пише повідомлення у файл logs/app.log
// Усі коментарі українською мовою

const fs = require('fs');
const path = require('path');

// Шлях до директорії логів і до файлу логів
const logsDir = path.join(__dirname, '..', 'logs');
const logFilePath = path.join(logsDir, 'app.log');

// Гарантуємо існування директорії logs
if (!fs.existsSync(logsDir)) {
  fs.mkdirSync(logsDir, { recursive: true });
}

// Створюємо write stream у режимі додавання
const stream = fs.createWriteStream(logFilePath, { flags: 'a' });

// Форматуємо час у ISO для зручності читання
function timestamp() {
  return new Date().toISOString();
}

// Базова функція логування
function write(level, message, meta) {
  try {
    const line = {
      time: timestamp(),
      level,
      message: String(message),
      ...(meta !== undefined ? { meta } : {}),
    };
    stream.write(JSON.stringify(line) + '\n');
  } catch (e) {
    // У крайніх випадках, якщо логи не пишуться у файл, спробуємо консоль
    // (але основна вимога — файл)
    // eslint-disable-next-line no-console
    console.error('Logger write error:', e);
  }
}

// Зручні шорткати
function info(message, meta) {
  write('info', message, meta);
}
function warn(message, meta) {
  write('warn', message, meta);
}
function error(message, meta) {
  write('error', message, meta);
}
function debug(message, meta) {
  write('debug', message, meta);
}

module.exports = {
  info,
  warn,
  error,
  debug,
  // корисно експортувати шлях до файлу логів
  logFilePath,
};
