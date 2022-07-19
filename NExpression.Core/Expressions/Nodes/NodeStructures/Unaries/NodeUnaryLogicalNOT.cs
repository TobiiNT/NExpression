using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Helpers;

namespace NExpression.Core.Expressions.Nodes.NodeStructures.Unaries
{
    internal class NodeUnaryLogicalNOT : NodeUnaryTree
    {
        public NodeUnaryLogicalNOT(INode RightNode) : base(RightNode, OperationHelpers.GetOperation(MathOperation.LogicalNOT))
        {

        }
    }
}
