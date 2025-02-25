namespace ViteBackendIntegrationPoC.Vite;

public sealed class DevServer
{
    public static string? Url { get; } = Environment.GetEnvironmentVariable("VITE_DEV_SERVER_URL");

    public static bool Use { get; } = !string.IsNullOrEmpty(Url);

    public static string StaticFilesDirectory { get; } =
        $"{Root.Directory}/{(Use ? "public" : "dist")}";
}
