using System.Text;

namespace UnityCup.BlogSystem;

public class Program
{
    const string buildPath = "../../Build";
    const string blogPath = "../../Blog";
    private readonly BlogReader reader;
    private readonly BlogWriter writer;

    public Program()
    {
        reader = new(blogPath);
        writer = new(buildPath);

        reader.Read();
        writer.Write(reader.pages);

        File.WriteAllText(
            Path.Join(buildPath, @"index.html"),
            GenerateIndexPage(reader.pages.ToArray())
        );
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