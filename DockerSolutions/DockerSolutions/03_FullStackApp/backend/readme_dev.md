# README (dev) — Backend

Цей документ описує, як запустити backend у режимі розробки в Docker та як відкрити документацію API.

## Вимоги
- Встановлені Docker і Docker Compose
- Відкритий локальний порт 5001 (або інший, якщо зміните налаштування)

## Швидкий старт

1) Створіть (за потреби) локальну папку для завантажень:
    - Linux/macOS: `mkdir -p ./uploads`
    - Windows (PowerShell): `New-Item -ItemType Directory -Force -Path .\uploads | Out-Null`

2) Запустіть сервіс у режимі розробки:
    - `docker compose -f docker-compose-dev.yaml up --build`

3) Перевірте, що API доступне:
    - Базовий URL: `http://localhost:5001/`
    - Swagger UI (документація): `http://localhost:5001/swagger`

Щоб зупинити:
- `docker compose -f docker-compose-dev.yaml down`

## Змінні оточення

У dev-компоновці використовуються наступні змінні (мають дефолтні значення):

- `ASPNETCORE_ENVIRONMENT=Development`
- `ASPNETCORE_URLS` — адреса, на якій слухає додаток у контейнері  
  За замовчуванням: `http://0.0.0.0:5001`
- `UPLOAD_FOLDER` — шлях у контейнері для збереження завантажених файлів  
  За замовчуванням: `/app/uploads`

