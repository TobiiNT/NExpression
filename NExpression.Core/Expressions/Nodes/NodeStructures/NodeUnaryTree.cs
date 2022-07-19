using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations.Interfaces;

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

        public object? Evaluate(IContext? ReadContext = null)
        {
            var RightValue = RightNode.Evaluate(ReadContext);
            var Result = Operation?.Evaluate(RightValue);

            return Result;
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
            RightNode.Traverse(ref Nodes);
        }
    }
}
