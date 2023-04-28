using UnityCup.MarkdownParser.Statements;

namespace UnityCup.MarkdownParser;

public class Parser
{
    private readonly Lexer lexer;

    public Parser(Lexer lexer)
    {
        this.lexer = lexer;
    }

    public Root Parse()
    {
        List<IStatement> statements = new List<IStatement>();



        return new Root(statements);
    }
}