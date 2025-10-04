# Multi-service dev container using PM2 + Nginx reverse proxy
# Suitable for Azure Web App for Containers or a VM with Docker

FROM node:22-alpine

# Install bash, tini, nginx and openssl (for a dev self-signed certificate)
RUN apk add --no-cache bash tini nginx openssl

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

# Prepare Nginx config and self-signed certs
RUN mkdir -p /etc/nginx/conf.d /etc/nginx/certs \
 && openssl req -x509 -nodes -days 365 -newkey rsa:2048 \
      -keyout /etc/nginx/certs/dev.key \
      -out /etc/nginx/certs/dev.crt \
      -subj "/CN=localhost" \
 && rm -f /etc/nginx/conf.d/default.conf

# Copy our Nginx configuration
COPY nginx.conf /etc/nginx/nginx.conf

# Environment: development (dev servers)
ENV NODE_ENV=development

# Expose only proxy ports
EXPOSE 80 443

# Ensure entrypoint is executable
RUN chmod +x /app/docker-entrypoint.sh /app/start_dev.sh

# Use tini as PID 1 for proper signal forwarding; then run our entrypoint
ENTRYPOINT ["/sbin/tini", "--", "/bin/bash", "/app/docker-entrypoint.sh"]

# No CMD needed; entrypoint starts Nginx + PM2 and tails logs
