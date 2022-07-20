using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeNested : INode
    {
        public INode? ParentNode { private set; get; }
        public INode? InnerNode { private set; get; }
        public IContext? Context { set; get; }

        public NodeNested(INode? ParentNode, INode? InnerNode)
        {
            this.ParentNode = ParentNode;
            this.InnerNode = InnerNode;
        }

        public object? Evaluate()
        {
            if (InnerNode != null)
            {
                var CurrentContext = (IContext?)ParentNode?.Evaluate();
                InnerNode.Context = CurrentContext;

                var Value = InnerNode?.Evaluate();

                return Value;
            }
            return null;
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
            InnerNode?.Traverse(ref Nodes);
        }
    }
}
