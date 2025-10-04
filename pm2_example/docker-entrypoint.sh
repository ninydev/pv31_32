#!/usr/bin/env bash
set -euo pipefail

# Load dotenv files for backend services if present so PORT and other vars are available
if [ -f "/app/back/api/.env" ]; then
  set -a
  . /app/back/api/.env
  set +a
fi
if [ -f "/app/back/socket/.env" ]; then
  set -a
  . /app/back/socket/.env
  set +a
fi

# Start all services via PM2 using the existing per-service ecosystem.dev.config.cjs files
chmod +x /app/start_dev.sh
/app/start_dev.sh

# Show PM2 process table and keep the container in foreground by streaming logs
pm2 status
exec pm2 logs --raw