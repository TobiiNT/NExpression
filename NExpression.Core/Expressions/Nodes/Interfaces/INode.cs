﻿using NExpression.Core.Contexts.Interfaces;

namespace NExpression.Core.Expressions.Nodes.Interfaces
{
    public interface INode
    {
        public object? Evaluate();
        public object? Evaluate(IContext? ReadContext = null);
        public T? Evaluate<T>();
        public T? Evaluate<T>(IContext? ReadContext = null);

        public void Traverse(ref Stack<INode> Nodes);
    }
}
