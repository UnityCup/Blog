using UnityCup.MarkdownParser;
using UnityCup.MarkdownParser.Statements;
using UnityCup.BlogSystem.Components;

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

    public string Parse(string title)
    {
        Root root = parser.Parse();

        List<IBlogComponent> blogComponents = new List<IBlogComponent>();

        foreach (var statement in root.statements)
        {
            switch (statement)
            {
                case HeadLineStatement headLine:
                    blogComponents.Add(new HeadLineComponent(new SentenceComponent(headLine.sentence.literal)));
                    break;
                case SentenceStatement sentence:
                    blogComponents.Add(new PragraphComponent(new SentenceComponent(sentence.literal)));
                    break;
            }
        }

        return new BlogBuilder(new TitleContainerComponent(new TitleComponent(title), new TitleIconComponent("🦍")), new PageComponent(blogComponents)).Build();
    }
}