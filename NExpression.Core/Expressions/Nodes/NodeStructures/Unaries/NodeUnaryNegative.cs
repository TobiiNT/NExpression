
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Helpers;

namespace NExpression.Core.Expressions.Nodes.NodeStructures.Unaries
{
    internal class NodeUnaryNegative : NodeUnary
    {
        public NodeUnaryNegative(INode RightNode) : base(RightNode, OperationHelpers.GetOperation(MathOperation.Negative))
        {

        }
    }
}
