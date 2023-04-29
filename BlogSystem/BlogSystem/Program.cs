using System.Text;

namespace UnityCup.BlogSystem;

public class Program
{
    const string buildPath = "Build";
    const string blogPath = "Blog";
    const string pageTemplatePath = "IndexPage";
    private readonly BlogReader reader;
    private readonly BlogWriter writer;

    public Program()
    {
        if (Directory.Exists(buildPath)) Directory.Delete(buildPath, true);
        Directory.CreateDirectory(buildPath);

        reader = new(blogPath);
        writer = new(buildPath);

        reader.Read();
        writer.Write(reader.pages);

        File.WriteAllText(
            Path.Join(buildPath, @"index.html"),
            GenerateIndexPage(reader.pages.ToArray())
        );
        Directory.CreateDirectory(Path.Join(buildPath, "css"));
        File.Copy(Path.Join(pageTemplatePath, @"css/style.css"), Path.Join(buildPath, @"css/style.css"));
        Directory.CreateDirectory(Path.Join(buildPath, "img"));
        File.Copy(Path.Join(pageTemplatePath, @"img/UnityCupLogo.png"), Path.Join(buildPath, @"img/UnityCupLogo.png"));
    }

    public string GenerateIndexPage(BlogPage[] pages)
    {
        StringBuilder builder = new();

        foreach (var page in pages)
        {
            builder.AppendLine($"<a href=\"{page.name}\">{page.name}</a>");
        }

        return builder.ToString();
    }

    public static void Main(string[] args)
        => new Program();
}