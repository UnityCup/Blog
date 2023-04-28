using UnityCup.MarkdownParser;

namespace UnityCup.ParserTest;

public class Program
{
    public Program(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Lexer or Parser");
            return;
        }

        switch (args[0])
        {
            case "Parser":
                ParserTest();
                break;
            case "Lexer":
                LexerTest();
                break;
        }
    }

    private void ParserTest()
    {
        Lexer lexer = new Lexer(@"aaaaaaa
bbbbbbbb#afafw
# afwfa
#kkkkkk
## feffeffe
fafwafeef");

        Parser parser = new Parser(lexer);
        Console.WriteLine(parser.Parse().Inspect());
    }

    private void LexerTest()
    {
        Lexer lexer = new Lexer(@"aaaaaaa
bbbbbbbb#afafw
# afwfa
#kkkkkk
## feffeffe
fafwafeef");

        Token token = lexer.NextToken();
        while (true)
        {
            Console.WriteLine($"{token.literal} : {token.type}\n");
            if (token.type == TokenType.EOF) return;
            token = lexer.NextToken();
        }
    }

    public static void Main(string[] args) => new Program(args);
}