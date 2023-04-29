using System.Collections.ObjectModel;

namespace UnityCup.BlogSystem;

public class BlogWriter
{
    public readonly string buildPath;

    public BlogWriter(string buildPath)
    {
        this.buildPath = buildPath;
    }

    public void Write(ReadOnlyCollection<BlogPage> pages)
    {
        foreach (var page in pages)
        {
            File.WriteAllText(Path.Combine(buildPath, $"{page.name}.html"), page.htmlData);
        }
    }
}