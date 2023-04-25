using System.Collections.ObjectModel;

namespace UnityCup.BlogSystem;

public class BlogWriter
{
    public readonly string buildPath;

    public BlogWriter(string buildPath)
    {
        this.buildPath = buildPath;
    }

    private void InitializeBuildDirectory()
    {
        if (Directory.Exists(buildPath))
        {
            foreach (var filePath in Directory.GetFiles(buildPath))
                File.Delete(filePath);

            foreach (var directoryPath in Directory.GetDirectories(buildPath))
                Directory.Delete(directoryPath);
        }
        else Directory.CreateDirectory(buildPath);
    }

    public void Write(ReadOnlyCollection<BlogPage> pages)
    {
        InitializeBuildDirectory();

        foreach (var page in pages)
        {
            File.WriteAllText(Path.Combine(buildPath, $"{page.name}.html"), page.data);
        }
    }
}