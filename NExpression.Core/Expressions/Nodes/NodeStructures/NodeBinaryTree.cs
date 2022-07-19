using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations.Interfaces;
using NExpression.Core.Helpers;
using NExpression.Core.Extensions;

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

        public object? Evaluate() => Evaluate(null);
        public object? Evaluate(IContext? ReadContext = null)
        {
            var FirstArg = LeftNode.Evaluate(ReadContext);
            var SecondArg = RightNode.Evaluate(ReadContext);
            var Result = Operation?.Execute(FirstArg, SecondArg, null);

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
            LeftNode.Traverse(ref Nodes);
            RightNode.Traverse(ref Nodes);
        }
    }
}
