PM2 Example Admin (React-admin)

Описание
- Простой фронтенд на React + react-admin без авторизации.
- Получает список цветов из нашего API.
- Подключается к нашему Socket.IO серверу и показывает тосты (notistack) при подключении/отключении пользователей.

Требования
- Node.js 18+

Переменные окружения
Создайте файл .env в папке front/admin (уже добавлен по умолчанию):

VITE_API_URL=http://localhost:4000
VITE_SOCKET_URL=http://localhost:5000

Запуск бэкендов
- API: 
  cd back/api
  npm install
  npm start
- Socket:
  cd back/socket
  npm install
  npm start

Запуск фронтенда
- Front (admin):
  cd front/admin
  npm install
  npm run dev
  Откройте в браузере: http://localhost:5173

Проверка
- На главной странице react-admin должна отображаться таблица с доступными цветами.
- При подключении/отключении клиентов к сокету будут появляться тосты (user:joined / user:left).
