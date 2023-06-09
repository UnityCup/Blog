using System.Text;
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

        public string Inspect()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var statement in statements)
            {
                builder.AppendLine(statement.Inspect());
            }

            return builder.ToString();
        }
    }
}