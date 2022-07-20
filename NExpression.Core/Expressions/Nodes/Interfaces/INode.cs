using NExpression.Core.Contexts.Interfaces;

namespace NExpression.Core.Expressions.Nodes.Interfaces
{
    public interface INode
    {
        public INode? InnerNode { get; }
        public IContext? Context { set; get; }

        public object? Evaluate();

        public void Traverse(ref Stack<INode> Nodes);
    }
}
