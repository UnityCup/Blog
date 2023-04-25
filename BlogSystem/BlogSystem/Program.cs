namespace UnityCup.BlogSystem;

public class Program
{
    const string buildPath = "Build";
    const string blogPath = "Blog";

    public static void Main(string[] args)
    {
        BlogReader blogReader = new BlogReader(blogPath);

        if (!Directory.Exists(buildPath)) Directory.CreateDirectory(buildPath);

        Console.WriteLine(File.ReadAllText("Blog/test.html"));

        File.WriteAllText(Path.Join(buildPath, @"test2.html"), "HOGEEEEEEEEEEEEEEEEE");
        File.WriteAllText(Path.Join(buildPath, @"index.html"), "this is index.");
    }
}