using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeDatas
{
    public class NodeNull : INode
    {
        public object? Evaluate(IContext? ReadContext = null) => null;
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
        }
    }
}
