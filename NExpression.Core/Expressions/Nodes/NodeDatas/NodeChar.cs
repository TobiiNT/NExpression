using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeDatas
{
    public class NodeChar : INode
    {
        private char Char { get; set; }
        public NodeChar(char Char)
        {
            this.Char = Char;
        }

        public object? Evaluate(IContext? ReadContext = null)
        {
            return Char;
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
        }
        public override string ToString() => this.Char.ToString();
    }
}
