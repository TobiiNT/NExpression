using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeDatas
{
    public class NodeNull : INode
    {
        public INode? InnerNode => null;
        public IContext? Context { get => null; set { } }
        public object? Evaluate() => null;
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
        }
    }
}
