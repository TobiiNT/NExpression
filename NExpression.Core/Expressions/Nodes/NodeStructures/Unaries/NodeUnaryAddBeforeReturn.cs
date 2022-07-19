using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.NodeDatas.Numbers;
using NExpression.Core.Expressions.Operations;

namespace NExpression.Core.Expressions.Nodes.NodeStructures.Unaries
{
    internal class NodeUnaryAddBeforeReturn : NodeAssignment
    {
        public NodeUnaryAddBeforeReturn(NodeVariable VariableNode, IContext? Context) : base(VariableNode, new NodeNonFloatingDecimal(1), MathOperation.AssignAddBeforeReturn)
        {
            this.AssignContext(Context);
        }
    }
}
