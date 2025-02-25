import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import vueDevTools from 'vite-plugin-vue-devtools'

// https://vite.dev/config/
export default defineConfig({
  plugins: [vue(), vueDevTools()],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url)),
    },
  },
  build: {
    manifest: true,
    rollupOptions: {
      // https://vite.dev/guide/backend-integration.html
      input: './src/main.ts',
      output: {
        entryFileNames: 'assets/[hash:21].js',
        chunkFileNames: 'assets/[hash:21].js',
        assetFileNames: 'assets/[hash:21].[ext]',
        sourcemapFileNames: 'assets/[hash:21].js.map',
      },
    },
  },
})
