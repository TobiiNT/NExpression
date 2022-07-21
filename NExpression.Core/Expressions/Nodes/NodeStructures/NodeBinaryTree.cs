using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeBinaryTree : INode
    {
        public INode LeftNode { private set; get; }
        public INode RightNode { private set; get; }
        public IOperation? Operation { private set; get; }

        public NodeBinaryTree(INode LeftNode, INode RightNode, IOperation Operation)
        {
            this.LeftNode = LeftNode;
            this.RightNode = RightNode;
            this.Operation = Operation;
        }

        public object? Evaluate()
        {
            var FirstArg = LeftNode.Evaluate();
            var SecondArg = RightNode.Evaluate();
            var Result = Operation?.Evaluate(FirstArg, SecondArg, null);

            return Result;
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
            LeftNode.Traverse(ref Nodes);
            RightNode.Traverse(ref Nodes);
        }
    }
}
