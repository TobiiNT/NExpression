using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations.Interfaces;
using NExpression.Core.Helpers;
using NExpression.Core.Extensions;

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

        public object? Evaluate(IContext? ReadContext = null)
        {
            var LeftValue = LeftNode.Evaluate(ReadContext);
            var Result = Operation?.Execute(LeftValue, null, null);

            return Result;
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
            LeftNode.Traverse(ref Nodes);
        }
    }
}
