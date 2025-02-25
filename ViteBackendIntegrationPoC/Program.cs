using Microsoft.Extensions.FileProviders;

namespace ViteBackendIntegrationPoC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/servers/yarp/getting-started?view=aspnetcore-9.0
            builder
                .Services.AddReverseProxy()
                .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            if (!app.Environment.IsDevelopment())
            {
                app.UseStaticFiles(
                    new StaticFileOptions
                    {
                        FileProvider = new PhysicalFileProvider(
                            Path.Combine(
                                builder.Environment.ContentRootPath,
                                "vue-input-integration/dist"
                            )
                        ),
                    }
                );
            }

            // TODO: Static files from "vue-input-integration/public" in Production mode
            // to prevent the need for a reverse proxy altogether???

            // Note that this must be placed after app.UseStaticFiles() to avoid conflicts!
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                // Note that I'm a catch-all route...
                pattern: "{**path}",
                defaults: new { controller = "Home", action = "Index" }
            );

            if (app.Environment.IsDevelopment())
            {
                app.MapReverseProxy();
            }

            app.Run();
        }
    }
}
