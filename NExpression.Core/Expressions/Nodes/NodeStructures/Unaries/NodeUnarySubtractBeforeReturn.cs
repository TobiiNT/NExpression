using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.NodeDatas;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Helpers;

namespace NExpression.Core.Expressions.Nodes.NodeStructures.Unaries
{
    internal class NodeUnarySubtractBeforeReturn : NodeAssignment
    {
        public NodeUnarySubtractBeforeReturn(NodeVariable VariableNode, IContext? Context) : base(VariableNode, new NodeNumber(1), OperationHelpers.GetOperation(MathOperation.AssignSubtractBeforeReturn, Context))
        {

        }
    }
}
