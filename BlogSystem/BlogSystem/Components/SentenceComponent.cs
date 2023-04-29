namespace UnityCup.BlogSystem.Components;

public class SentenceComponent : IBlogComponent
{
    public readonly string source;

    public SentenceComponent(string source)
    {
        this.source = source;
    }

    public string Build()
        => source;
}