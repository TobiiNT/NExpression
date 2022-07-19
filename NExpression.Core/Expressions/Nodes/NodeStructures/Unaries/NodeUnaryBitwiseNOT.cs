using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Helpers;

namespace NExpression.Core.Expressions.Nodes.NodeStructures.Unaries
{
    internal class NodeUnaryBitwiseNOT : NodeUnaryTree
    {
        public NodeUnaryBitwiseNOT(INode RightNode) : base(RightNode, OperationHelpers.GetOperation(MathOperation.BitwiseNOT))
        {

        }
    }
}
