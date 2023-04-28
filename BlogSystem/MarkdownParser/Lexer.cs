using System.Text;

namespace UnityCup.MarkdownParser;

public class Lexer
{
    public readonly string source;
    public int currentPosition { get; private set; }
    public char currentChar
    {
        get
        {
            if (source.Length <= currentPosition) return (char)0;
            return source[currentPosition];
        }
    }
    public char nextChar
    {
        get
        {
            if (source.Length <= currentPosition + 1) return (char)0;
            return source[currentPosition + 1];
        }
    }

    public Lexer(string source)
    {
        this.source = source;
        this.source = this.source.Replace("\r\n", "\n");
        this.source = this.source.Replace("\r", "\n");
    }

    public void ReadChar()
    {
        currentPosition++;
    }

    public Token NextToken()
    {
        string literal = "";
        TokenType type = TokenType.Illegal;

        switch (currentChar)
        {
            case '#':
                literal = ReadHeadline();
                type = TokenType.Headline1;
                break;
            default:
                if (currentChar == (char)0)
                {
                    literal = "";
                    type = TokenType.EOF;
                    break;
                }
                literal = ReadSentence();
                type = TokenType.Sentence;
                break;
        }

        ReadChar();

        return new Token(literal, type);
    }

    private string ReadHeadline()
    {
        StringBuilder builder = new StringBuilder();

        ReadChar(); // #の読み飛ばし

        while (currentChar == ' ') ReadChar(); // #の後の空白の読み飛ばし

        while (true)
        {
            if (currentChar == '\n') break;
            if (currentChar == (char)0) break;
            builder.Append(currentChar);
            ReadChar();
        }

        return builder.ToString();
    }

    private string ReadSentence()
    {
        StringBuilder builder = new StringBuilder();

        while (true)
        {
            if (currentChar == '\n' && nextChar == '#') break;
            if (currentChar == (char)0) break;
            builder.Append(currentChar);
            ReadChar();
        }

        return builder.ToString();
    }
}
