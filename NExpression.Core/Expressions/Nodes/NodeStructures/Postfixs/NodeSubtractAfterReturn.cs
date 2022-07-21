using NExpression.Core.Expressions.Nodes.NodeDatas.Numbers;
using NExpression.Core.Expressions.Operations;

namespace NExpression.Core.Expressions.Nodes.NodeStructures.Postfixs
{
    internal class NodeSubtractAfterReturn : NodeAssignment
    {
        public NodeSubtractAfterReturn(NodeVariable VariableNode) : base(VariableNode, new NodeNonFloatingDecimal(1), MathOperation.AssignSubtractAfterReturn)
        {
         
        }
    }
}
