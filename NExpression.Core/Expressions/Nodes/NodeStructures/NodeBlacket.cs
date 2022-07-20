using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeBlacket : INode
    {
        public INode InnerNode { private set; get; }

        public NodeBlacket(INode InnerNode)
        {
            this.InnerNode = InnerNode;
        }

        public object? Evaluate(IContext? ReadContext = null)
        {
            return InnerNode.Evaluate(ReadContext);
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
            InnerNode.Traverse(ref Nodes);
        }
    }
}
