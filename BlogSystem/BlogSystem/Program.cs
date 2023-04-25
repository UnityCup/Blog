namespace UnityCup.BlogSystem;

public class Program
{
    const string buildPath = "Build";
    const string blogPath = "Blog";

    public Program()
    {
        BlogReader blogReader = new BlogReader(blogPath);
        blogReader.Read();

        BlogWriter blogWriter = new BlogWriter(buildPath, blogReader.pages);
        blogWriter.Write();

        File.WriteAllText(Path.Join(buildPath, @"index.html"), "<p>This is index Page.</p><a href=\"TestPage\">TestPage</a>");
    }

    public static void Main(string[] args)
        => new Program();
}