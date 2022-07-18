using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodePostfix : INode
    {
        public INode LeftNode { set; get; }
        public IOperation? Operation { set; get; }

        public NodePostfix(INode LeftNode, IOperation? Operation)
        {
            this.LeftNode = LeftNode;
            this.Operation = Operation;
        }

        public object? Evaluate() => Evaluate(null);
        public object? Evaluate(IContext? ReadContext = null)
        {
            var LeftValue = LeftNode.Evaluate(ReadContext);
            var Result = Operation?.Execute(LeftValue, null, null);

            return Result;
        }
        public T? Evaluate<T>() => Evaluate<T>(null);
        public T? Evaluate<T>(IContext? ReadContext = null)
        {
            return (T?)Convert.ChangeType(Evaluate(), typeof(T?));
        }
    }
}
