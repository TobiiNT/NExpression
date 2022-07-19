﻿using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeDatas
{
    public class NodeString : INode
    {
        private string String { get; set; }
        public NodeString(string String)
        {
            this.String = String;
        }
        public object? Evaluate(IContext? ReadContext = null)
        {
            return String;
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
        }
        public override string ToString() => this.String;
    }
}
