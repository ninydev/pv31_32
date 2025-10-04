module.exports = {
  apps: [
    {
      name: 'front-public-dev',
      cwd: __dirname,
        script: "node_modules/next/dist/bin/next",
        args: "dev -p 3000",
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