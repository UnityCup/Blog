using System.Collections.ObjectModel;

namespace UnityCup.BlogSystem;

public class BlogReader
{
    public const string blogMarkdownName = "index.md";
    public readonly string blogPath;
    public ReadOnlyCollection<BlogPage> pages { get; private set; }

    public BlogReader(string blogPath)
    {
        this.blogPath = blogPath;
        pages = new(new List<BlogPage>());
    }

    public void Read()
    {
        pages = new(
            Directory.GetDirectories(blogPath, "*", SearchOption.TopDirectoryOnly)
                .Select(path => new DirectoryInfo(path))
                .Select(directoryInfo =>
                    (
                        pageName: directoryInfo.Name,
                        fileInfo: directoryInfo.GetFiles()
                            .Where(fileInfo => fileInfo.Name == blogMarkdownName)
                            .First()
                    )
                )
                .Select(data =>
                    new BlogPage(
                        data.pageName,
                        data.fileInfo.OpenText().ReadToEnd()
                    )
                )
                .ToArray()
        );
    }
}