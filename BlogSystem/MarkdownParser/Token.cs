namespace UnityCup.MarkdownParser;

public class Token
{
    public readonly string literal;
    public readonly TokenType type;

    public Token(string literal, TokenType type)
    {
        this.literal = literal;
        this.type = type;
    }
}