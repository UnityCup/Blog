namespace UnityCup.MarkdownParser.Statements
{
    public class SentenceStatement : IStatement
    {
        public readonly string literal;

        public SentenceStatement(string literal)
        {
            this.literal = literal;
        }

        public string Inspect()
            => literal;
    }
}