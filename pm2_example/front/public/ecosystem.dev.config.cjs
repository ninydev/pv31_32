module.exports = {
  apps: [
    {
      name: 'front-public-dev',
      cwd: __dirname,
      script: 'npm',
      args: 'run dev',
      env: {
        NODE_ENV: 'development',
      },
      instances: 1,
      exec_mode: 'fork',
      autorestart: true,
      watch: false,
    },
  ],
};