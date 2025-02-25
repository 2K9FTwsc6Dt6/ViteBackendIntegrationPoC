using Microsoft.Extensions.FileProviders;

namespace ViteBackendIntegrationPoC
{
    public class Program
    {
        public static string? ViteDevServerUrl { get; } =
            Environment.GetEnvironmentVariable("VITE_DEV_SERVER_URL");

        public static bool UseViteDevServer { get; } = !string.IsNullOrEmpty(ViteDevServerUrl);

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles(
                new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(
                        Path.Combine(
                            builder.Environment.ContentRootPath,
                            $"vue-input-integration/{(UseViteDevServer ? "public" : "dist")}"
                        )
                    ),
                }
            );

            // Note that this must be placed after app.UseStaticFiles() to avoid conflicts!
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                // Note that I'm a catch-all route...
                pattern: "{**path}",
                defaults: new { controller = "Home", action = "Index" }
            );

            app.Run();
        }
    }
}
