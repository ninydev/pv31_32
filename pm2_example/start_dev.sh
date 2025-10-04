#!/usr/bin/env bash
set -euo pipefail

# Start or reload all 4 microservices in DEV mode using their local PM2 configs
# Requires: pm2 installed globally (npm i -g pm2)

BASE_DIR="$(cd "$(dirname "$0")" && pwd)"

SERVICES=(
  "back/api back-api-dev"
  "back/socket back-socket-dev"
  "front/admin front-admin-dev"
  "front/public front-public-dev"
)

start_or_reload() {
  local rel_path="$1"
  local app_name="$2"
  local cfg="${BASE_DIR}/${rel_path}/ecosystem.dev.config.cjs"

  if ! [ -f "$cfg" ]; then
    echo "Config not found: $cfg" >&2
    return 1
  fi

  echo "\n=== ${app_name}: starting/reloading (cwd: ${rel_path}) ==="
  # If already running -> reload; else -> start
  if pm2 list | grep -qw "$app_name"; then
    pm2 reload "$app_name" --update-env || pm2 restart "$app_name" --update-env
  else
    (cd "${BASE_DIR}/${rel_path}" && pm2 start "$cfg")
  fi
}

for entry in "${SERVICES[@]}"; do
  rel_path=$(echo "$entry" | awk '{print $1}')
  app_name=$(echo "$entry" | awk '{print $2}')
  start_or_reload "$rel_path" "$app_name"
done

# Show status table
pm2 status

echo "\nAll services are started/reloaded in DEV mode."
