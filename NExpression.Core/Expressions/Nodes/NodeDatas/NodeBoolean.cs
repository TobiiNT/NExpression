using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeDatas
{
    public class NodeBoolean : INode
    {
        private bool Boolean { get; set; }
        public NodeBoolean(bool Boolean)
        {
            this.Boolean = Boolean;
        }

        public object? Evaluate(IContext? ReadContext = null)
        {
            return Boolean;
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
        }
        public override string ToString() => this.Boolean.ToString();
    }
}
