# Багатостадійна збірка для Next.js (builder + runner)
# Мета: мінімізувати розмір кінцевого образу, пришвидшити збірку за рахунок кешу
# та підвищити безпеку (у рантаймі немає dev-інструментів).

# === СТАДІЯ 1: BUILDER ===
# Використовуємо повноцінний Node-образ (glibc) для сумісності з нативними залежностями
FROM node:22 AS builder

# Папка роботи всередині контейнера
WORKDIR /app

# 1) Копіюємо тільки файли залежностей для максимально ефективного кешування
# ВАЖЛИВО: контекст збірки — корінь 02_DockerNext, тому шляхи починаються з frontend/
COPY frontend/package*.json ./
# Якщо у вас є yarn.lock/pnpm-lock.yaml — скопіюйте їх також, щоб збірка була детермінованою
# COPY frontend/yarn.lock ./

# 2) Встановлюємо залежності з урахуванням devDependencies (вони потрібні на стадії збірки)
# Використовуємо Yarn (вже входить до node:22). За наявності yarn.lock варто додати --frozen-lockfile
RUN corepack enable && yarn install --no-progress

# 3) Копіюємо решту коду застосунку
COPY frontend/ .

# 4) Збираємо Next.js застосунок (Turbopack/Next 15). Це створить папку .next
# За замовчуванням outDir: .next; для prod-режиму встановлюємо NODE_ENV=production
ENV NODE_ENV=production
# Вимикаємо телеметрію Next під час збірки для чистоти CI
ENV NEXT_TELEMETRY_DISABLED=1
RUN yarn build

# Опційно: якщо ви хочете standalone-режим (мінімальні рантайм-залежності),
# додайте в next.config.js: `output: 'standalone'`. Тоді копіювати будемо .next/standalone + .next/static + public

# === СТАДІЯ 2: RUNNER ===
# Використовуємо легкий образ для рантайму
FROM node:22-alpine AS runner

# Безпечні налаштування середовища
ENV NODE_ENV=production
ENV NEXT_TELEMETRY_DISABLED=1

# Створюємо системного користувача без прав root для безпечного запуску (краща практика)
# (UID/GID 1001 — стандартний некритичний користувач)
RUN addgroup -g 1001 -S nodejs && adduser -S nextjs -u 1001 -G nodejs

WORKDIR /app

# Встановлюємо лише prod-залежності, щоб мінімізувати розмір
# Скопіюємо package*.json з builder (у ньому вже є точні версії після install)
COPY --from=builder /app/package*.json ./
RUN corepack enable && yarn install --production --no-progress --prefer-offline && yarn cache clean

# Копіюємо зібрані артефакти з builder.
# Варіант A (звичайний): .next, public, а також node_modules вже встановлені для prod вище.
# Якщо використовуєте output: 'standalone' — див. варіант B нижче (закоментовано).
COPY --from=builder /app/.next ./.next
COPY --from=builder /app/public ./public
# Якщо у вас є файли конфігурації, які потрібні на рантаймі (next.config.js), додайте:
# COPY --from=builder /app/next.config.js ./

# Варіант B (standalone): розкоментуйте, якщо у вашому next.config.js: output: 'standalone'
# COPY --from=builder /app/.next/standalone ./
# COPY --from=builder /app/.next/static ./.next/static
# COPY --from=builder /app/public ./public

# Відкриваємо порт 3000 (документаційно)
EXPOSE 3000

# Переходимо на некореневого користувача
USER nextjs

# Команда запуску продакшн-сервера Next.js
CMD ["yarn", "start"]
