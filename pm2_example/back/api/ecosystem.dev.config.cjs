module.exports = {
  apps: [
    {
      name: 'back-api-dev',
      cwd: __dirname,
      script: 'node',
      args: 'src/server.mjs',
      watch: ['src', '.env'],
      ignore_watch: ['node_modules'],
      env: {
        NODE_ENV: 'development',
      },
      instances: 1,
      exec_mode: 'fork',
      autorestart: true,
    },
  ],
};