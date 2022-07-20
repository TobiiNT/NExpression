using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeDatas.Booleans
{
    public class NodeBoolean : INode
    {
        public INode? InnerNode => null;
        public IContext? Context { get => null; set { } }

        private bool Boolean { get; set; }
        public NodeBoolean(bool Boolean)
        {
            this.Boolean = Boolean;
        }

        public object? Evaluate()
        {
            return Boolean;
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
        }
        public override string ToString() => Boolean.ToString();
    }
}
