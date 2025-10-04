import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// Vite config to serve Admin UI under /admin base when behind Nginx reverse proxy
export default defineConfig({
  base: '/admin/',
  plugins: [react()],
  server: {
    host: true, // 0.0.0.0
    port: 5173,
    // Make HMR work through the reverse proxy on port 80/443
    hmr: {
      // When accessing via http(s)://host[/admin], client uses the same host/port
      // If running behind 80/443, set clientPort accordingly; it will auto-pick window.location.port.
      path: '/admin',
    },
  },
  preview: {
    port: 5173,
  },
})
