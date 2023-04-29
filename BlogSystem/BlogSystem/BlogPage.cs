namespace UnityCup.BlogSystem;

public class BlogPage
{
    public readonly string name;
    public readonly string source;
    public readonly string htmlData;

    public BlogPage(string name, string source)
    {
        Console.WriteLine(name);
        this.name = name;
        this.source = source;
        this.htmlData = new BlogParser(source).Parse(name);
    }
}