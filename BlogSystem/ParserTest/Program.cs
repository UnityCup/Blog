using UnityCup.MarkdownParser;

namespace UnityCup.ParserTest;

public class Program
{
    private readonly Lexer lexer;

    public Program()
    {
        this.lexer = new Lexer(@"aaaaaaa
#afwfa
#kkkkkk
## feffeffe
fafwafeef");

        Token token = lexer.NextToken();
        while (true)
        {
            Console.WriteLine($"{token.literal} : {token.type}");
            if (token.type == TokenType.EOF) return;
            token = lexer.NextToken();
        }
    }

    public static void Main(string[] args) => new Program();
}