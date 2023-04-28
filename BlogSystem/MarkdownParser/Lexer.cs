namespace UnityCup.MarkdownParser;

public class Lexer
{
    public readonly string source;
    public int currentPosition { get; }
    public char currentChar => source[currentPosition];
    public char nextChar => source[currentPosition + 1];

    public Lexer(string source)
    {
        this.source = source;
    }

    public Token NextToken()
    {

    }
}
