using System.Collections.ObjectModel;

namespace UnityCup.MarkdownParser.Statements
{
    public class Root : INode
    {
        public readonly ReadOnlyCollection<IStatement> statements;

        public Root(IList<IStatement> statements)
        {
            this.statements = new ReadOnlyCollection<IStatement>(statements);
        }
    }
}