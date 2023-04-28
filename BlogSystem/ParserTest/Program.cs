using UnityCup.MarkdownParser;

namespace UnityCup.ParserTest;

public class Program
{
    private readonly Parser lexer;

    public Program()
    {
        this.lexer = new Parser(@"aaaaaaa
bbbbbbbb#afafw
# afwfa
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