﻿using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.NodeDatas;
using NExpression.Core.Expressions.Nodes.NodeDatas.Numbers;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Helpers;

namespace NExpression.Core.Expressions.Nodes.NodeStructures.Unaries
{
    internal class NodeUnarySubtractBeforeReturn : NodeAssignment
    {
        public NodeUnarySubtractBeforeReturn(NodeVariable VariableNode, IContext? Context) : base(VariableNode, new NodeNonFloatingDecimal(1), MathOperation.AssignSubtractBeforeReturn)
        {
            this.AssignContext(Context);
        }
    }
}
