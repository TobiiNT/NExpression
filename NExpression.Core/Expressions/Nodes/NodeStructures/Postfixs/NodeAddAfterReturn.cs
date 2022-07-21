using NExpression.Core.Expressions.Nodes.NodeDatas.Numbers;
using NExpression.Core.Expressions.Operations;

namespace NExpression.Core.Expressions.Nodes.NodeStructures.Postfixs
{
    internal class NodeAddAfterReturn : NodeAssignment
    {
        public NodeAddAfterReturn(NodeVariable VariableNode) : base(VariableNode, new NodeNonFloatingDecimal(1), MathOperation.AssignAddAfterReturn)
        {

        }
    }
}
