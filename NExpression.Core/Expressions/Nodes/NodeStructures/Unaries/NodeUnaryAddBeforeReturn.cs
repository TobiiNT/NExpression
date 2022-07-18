using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.NodeDatas;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Helpers;

namespace NExpression.Core.Expressions.Nodes.NodeStructures.Unaries
{
    internal class NodeUnaryAddBeforeReturn : NodeAssignment
    {
        public NodeUnaryAddBeforeReturn(NodeVariable VariableNode, IContext? Context) : base(VariableNode, new NodeNumber(1), OperationHelpers.GetOperation(MathOperation.AssignAddBeforeReturn, Context))
        {

        }
    }
}
