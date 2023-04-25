using System.Collections.ObjectModel;

namespace UnityCup.BlogSystem;

public class BlogWriter
{
    public readonly string buildPath;
    private readonly ReadOnlyCollection<BlogPage> pages;

    public BlogWriter(string buildPath, ReadOnlyCollection<BlogPage> pages)
    {
        this.buildPath = buildPath;
        this.pages = pages;
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

    public void Write()
    {
        InitializeBuildDirectory();

        foreach (var page in pages)
        {
            File.WriteAllText(Path.Combine(buildPath, $"{page.name}.html"), page.data);
        }
    }
}