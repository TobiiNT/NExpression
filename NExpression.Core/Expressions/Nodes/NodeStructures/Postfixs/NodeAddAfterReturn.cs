using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.NodeDatas;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Helpers;

namespace NExpression.Core.Expressions.Nodes.NodeStructures.Postfixs
{
    internal class NodeAddAfterReturn : NodeAssignment
    {
        public NodeAddAfterReturn(NodeVariable VariableNode, IContext? Context) : base(VariableNode, new NodeNumber(1), OperationHelpers.GetOperation(MathOperation.AssignAddAfterReturn, Context))
        {

        }
    }
}
