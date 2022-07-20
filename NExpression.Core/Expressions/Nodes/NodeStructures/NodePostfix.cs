using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodePostfix : INode
    {
        public INode? InnerNode => null;
        public IContext? Context { get => null; set { } }

        public INode LeftNode { set; get; }
        public IOperation? Operation { set; get; }

        public NodePostfix(INode LeftNode, IOperation? Operation)
        {
            this.LeftNode = LeftNode;
            this.Operation = Operation;
        }

        public object? Evaluate()
        {
            var LeftValue = LeftNode.Evaluate();
            var Result = Operation?.Evaluate(LeftValue);

            return Result;
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
            LeftNode.Traverse(ref Nodes);
        }
    }
}
