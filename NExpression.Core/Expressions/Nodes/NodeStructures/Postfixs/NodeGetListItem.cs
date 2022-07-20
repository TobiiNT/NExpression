using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpression.Core.Expressions.Nodes.NodeStructures.Postfixs
{
    internal class NodeGetArrayItemByIndex : NodeIndex
    {
        public NodeGetArrayItemByIndex(INode ArrayNode, INode IndexNode, IContext? Context) : base(ArrayNode, IndexNode, OperationHelpers.GetOperation(MathOperation.GetItemByIndex))
        {

        }
    }
}
