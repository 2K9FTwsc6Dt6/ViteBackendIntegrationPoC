using System.Text.Json;

class Manifest
{
    public static string[] Stylesheets { get; }
    public static string EntryPoint { get; }

    static Manifest()
    {
        using var manifest = JsonDocument.Parse(
            System.IO.File.ReadAllText("./vue-input-integration/dist/.vite/manifest.json")
        );
        var main = manifest.RootElement.GetProperty("src/main.ts");
        Stylesheets = [.. main.GetProperty("css").EnumerateArray().Select(css => css.GetString()!)];
        EntryPoint = main.GetProperty("file").GetString()!;
    }
}
