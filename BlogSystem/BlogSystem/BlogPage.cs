namespace UnityCup.BlogSystem;

public class BlogPage
{
    public readonly string name;
    public readonly string data;

    public BlogPage(string name, string data)
    {
        Console.WriteLine(name);
        this.name = name;
        this.data = data;
    }
}