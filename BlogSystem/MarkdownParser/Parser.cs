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
        currentToken = lexer.NextToken();
        nextToken = lexer.NextToken();
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
            case TokenType.Sharp:
                return ParseHeadLine1Statement();
            case TokenType.Sentence:
                return ParseSentenceStatement();
            default:
                return null;
        }
    }

    private HeadLineStatement? ParseHeadLine1Statement()
    {
        if (currentToken.type != TokenType.Sharp) return null;
        ReadToken(); // #を飛ばす
        SentenceStatement? sentenceStatement = ParseSentenceStatement();
        if (sentenceStatement is null) return null;

        HeadLineStatement statement = new HeadLineStatement(sentenceStatement);
        return statement;
    }

    private SentenceStatement? ParseSentenceStatement()
    {
        if (currentToken.type != TokenType.Sentence) return null;
        SentenceStatement statement = new SentenceStatement(currentToken.literal);
        ReadToken();
        return statement;
    }
}