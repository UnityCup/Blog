namespace UnityCup.MarkdownParser;

public class Parser
{
    public readonly Lexer lexer;

    public Parser(Lexer lexer)
    {
        this.lexer = lexer;
    }
}