namespace UnityCup.MarkdownParser.Statements;

public class HeadLine1Statement : IStatement
{
    public readonly string literal;

    public HeadLine1Statement(string literal)
    {
        this.literal = literal;
    }

    public string Inspect()
        => $"# {literal}";
}