using System.Text.Json;

class Manifest
{
    public static string[] Css { get; }
    public static string File { get; }

    static Manifest()
    {
        using var manifest = JsonDocument.Parse(
            System.IO.File.ReadAllText("./vue-project/dist/.vite/manifest.json")
        );
        var main = manifest.RootElement.GetProperty("src/main.ts");
        Css = [.. main.GetProperty("css").EnumerateArray().Select(css => css.GetString()!)];
        File = main.GetProperty("file").GetString()!;
    }
}
