namespace UnityCup.MarkdownParser.Statements;

public class HeadLineStatement : IStatement
{
    public readonly SentenceStatement sentence;

    public HeadLineStatement(SentenceStatement sentence)
    {
        this.sentence = sentence;
    }

    public string Inspect()
        => $"# {sentence.Inspect()}";
}