using UnityCup.MarkdownParser.Statements;

namespace UnityCup.MarkdownParser;

public class Parser
{
    public Token currentToken { get; private set; }
    public Token nextToken { get; private set; }
    private readonly Lexer lexer;

    public Parser(Lexer lexer)
    {
        this.lexer = lexer;
        nextToken = lexer.NextToken();
        currentToken = lexer.NextToken();
    }

    public Root Parse()
    {
        List<IStatement> statements = new List<IStatement>();

        while (currentToken.type != TokenType.EOF)
        {
            IStatement? statement = ParseStatement();
            if (statement is not null)
            {
                statements.Add(statement);
            }
            else
            {
                ReadToken();
            }
        }

        return new Root(statements);
    }

    private void ReadToken()
    {
        currentToken = nextToken;
        nextToken = lexer.NextToken();
    }

    private IStatement? ParseStatement()
    {
        switch (currentToken.type)
        {
            case TokenType.Headline1:
                return ParseHeadLine1Statement();
            case TokenType.Sentence:
                return ParseSentenceStatement();
            default:
                return null;
        }
    }

    private HeadLine1Statement? ParseHeadLine1Statement()
    {
        HeadLine1Statement statement = new HeadLine1Statement(currentToken.literal);
        ReadToken();
        return statement;
    }

    private SentenceStatement? ParseSentenceStatement()
    {
        SentenceStatement statement = new SentenceStatement(currentToken.literal);
        ReadToken();
        return statement;
    }
}