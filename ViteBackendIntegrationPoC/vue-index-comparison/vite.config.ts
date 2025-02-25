import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import vueDevTools from 'vite-plugin-vue-devtools'

import type { PreRenderedAsset, PreRenderedChunk } from 'rollup'

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
      output: {
        entryFileNames: (chunkInfo: PreRenderedChunk) =>
          chunkInfo.name === 'index' ? 'assets/main-[hash].js' : 'assets/[name]-[hash].js',
        assetFileNames: (chunkInfo: PreRenderedAsset) =>
          chunkInfo.names.every((name) => name === 'index.css')
            ? 'assets/main-[hash].css'
            : 'assets/[name]-[hash].[ext]',
      },
      // Note that this works as well!
      // output: {
      //   entryFileNames: 'assets/[hash:21].js',
      //   chunkFileNames: 'assets/[hash:21].js',
      //   assetFileNames: 'assets/[hash:21].[ext]',
      //   sourcemapFileNames: 'assets/[hash:21].js.map',
      // },
    },
  },
})
