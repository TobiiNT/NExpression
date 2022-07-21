using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Helpers;

namespace NExpression.Core.Expressions.Nodes.NodeStructures.Postfixs
{
    internal class NodeGetArrayItemByIndex : NodeIndex
    {
        public NodeGetArrayItemByIndex(INode ArrayNode, INode IndexNode) : base(ArrayNode, IndexNode, OperationHelpers.GetOperation(MathOperation.GetItemByIndex))
        {

        }
    }
}
