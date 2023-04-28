using UnityCup.MarkdownParser;

namespace UnityCup.BlogSystem;

public class BlogParser
{
    public readonly string source;
    private readonly Parser parser;

    public BlogParser(string source)
    {
        this.source = source;
        this.parser = new Parser(new Lexer(source));
    }

    public string Parse()
    {
        return parser.Parse().Inspect();
    }
}