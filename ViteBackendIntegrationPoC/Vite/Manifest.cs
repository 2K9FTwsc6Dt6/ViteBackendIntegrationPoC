using System.Text.Json;

namespace ViteBackendIntegrationPoC.Vite;

public sealed class Manifest
{
    private static readonly bool _hotReload =
        Environment.GetEnvironmentVariable("VITE_HOT_RELOAD_MANIFEST") == "true";

    private static readonly Record _record = Parse();

    public static Record Record => _hotReload ? Parse() : _record;

    private static Record Parse()
    {
        using var manifest = JsonDocument.Parse(
            File.ReadAllText($"{Root.Directory}/.vite/manifest.json")
        );
        var main = manifest.RootElement.GetProperty("src/main.ts");
        return new(
            main.GetProperty("file").GetString()!,
            [.. main.GetProperty("css").EnumerateArray().Select(css => css.GetString()!)]
        );
    }
}
