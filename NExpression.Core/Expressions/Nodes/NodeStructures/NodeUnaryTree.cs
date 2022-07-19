using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations.Interfaces;
using NExpression.Core.Helpers;
using NExpression.Core.Extensions;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeUnaryTree : INode
    {
        public INode RightNode { set; get; }
        public IOperation? Operation { set; get; }

        public NodeUnaryTree(INode RightNode, IOperation? Operation)
        {
            this.RightNode = RightNode;
            this.Operation = Operation;
        }

        public object? Evaluate() => Evaluate(null);
        public object? Evaluate(IContext? ReadContext = null)
        {
            var RightValue = RightNode.Evaluate(ReadContext);
            var Result = Operation?.Execute(RightValue, null, null);

            return Result;
        }
        public T? Evaluate<T>() => Evaluate<T>(null);
        public T? Evaluate<T>(IContext? ReadContext = null)
        {
            return (T?)Convert.ChangeType(Evaluate(), typeof(T?));
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
            RightNode.Traverse(ref Nodes);
        }
    }
}
