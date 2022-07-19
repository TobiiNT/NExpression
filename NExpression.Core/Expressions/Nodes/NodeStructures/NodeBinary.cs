using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeBinary : INode
    {
        private INode LeftNode { set; get; }
        private INode RightNode { set; get; }
        private IOperation? Operation { set; get; }

        public NodeBinary(INode LeftNode, INode RightNode, IOperation Operation)
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
        public string Traverse()
        {
            return $"({LeftNode.Traverse()}) {Operation} ({RightNode.Traverse()})";
        }
    }
}
