using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Helpers;

namespace NExpression.Core.Expressions.Nodes.NodeStructures.Postfixs
{
    internal class NodeFactorial : NodePostfix
    {
        public NodeFactorial(INode Node) : base(Node, OperationHelpers.GetOperation(MathOperation.Factorial, null))
        {

        }
    }
}
