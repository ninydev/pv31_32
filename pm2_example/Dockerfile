# Multi-service dev container using PM2
# Suitable for Azure Web App for Containers or a VM with Docker

FROM node:22-alpine

# Install bash (used by scripts) and tini for proper PID 1 signal handling
RUN apk add --no-cache bash tini

# PM2 globally
RUN npm i -g pm2

WORKDIR /app

# Copy only package manifests first for better build caching and install deps per service
COPY back/api/package.json back/api/package.json
COPY back/socket/package.json back/socket/package.json
COPY front/public/package.json front/public/package.json
COPY front/admin/package.json front/admin/package.json

# Install dependencies for each microservice
RUN set -e; \
  cd /app/back/api && npm ci || npm i; \
  cd /app/back/socket && npm ci || npm i; \
  cd /app/front/public && npm ci || npm i; \
  cd /app/front/admin && npm ci || npm i

# Copy the rest of the source code
COPY . .

# Environment: development (dev servers)
ENV NODE_ENV=development

# Expose default dev ports (can be overridden in Azure App Settings or docker run -p mapping)
# - front/public (Next.js dev): 3000
# - front/admin (Vite dev):     5173
# - back/api (Express):         4000
# - back/socket (Socket.IO):    5000
EXPOSE 3000 5173 4000 5000

# Ensure entrypoint is executable
RUN chmod +x /app/docker-entrypoint.sh /app/start_dev.sh

# Use tini as PID 1 for proper signal forwarding; then run our entrypoint
ENTRYPOINT ["/sbin/tini", "--", "/bin/bash", "/app/docker-entrypoint.sh"]

# No CMD needed; entrypoint starts PM2 and tails logs
