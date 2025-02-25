# ViteBackendIntegrationPoC

Not like a
[Vue frontend and ASP.NET Core backend](https://learn.microsoft.com/en-us/visualstudio/javascript/tutorial-asp-net-core-with-vue?view=vs-2022),
but an **ASP.NET Core MVC app with the assets from Vue** instead, as explained
[here](https://vite.dev/guide/backend-integration) and implemented
[here](https://github.com/Eptagone/Vite.AspNetCore).

## Development (use VITE development server)

```bash
# ./ViteBackendIntegrationPoC/vue-input-integration
npm run dev
```

```bash
dotnet watch
```

## Production (use build and `dist` folder)

```bash
# ./ViteBackendIntegrationPoC/vue-input-integration
npm run build
```

```bash
dotnet run --launch-profile "build"
```

**Use watch mode (for development):**

```bash
# ./ViteBackendIntegrationPoC/vue-input-integration
npm run watch
```

```bash
dotnet watch --launch-profile "build"
```
