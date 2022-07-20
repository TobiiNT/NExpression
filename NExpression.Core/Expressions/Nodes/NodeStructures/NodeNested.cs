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
        public INode? CurrentNode { private set; get; }
        public INode? InnerNode { private set; get; }
        public IContext? Context { set; get; }

        public NodeNested(INode? CurrentNode)
        {
            this.CurrentNode = CurrentNode;
        }
        public void AssignChildren(INode? ChildrenNode)
        {
            this.InnerNode = ChildrenNode;
        }

        public object? Evaluate()
        {
            if (InnerNode != null)
            {
                if (CurrentNode is not NodeNested)
                {
                   return CurrentNode?.Evaluate();
                }
                else
                {
                    INode? CurrentNode = this;

                    while (CurrentNode is NodeNested NodeNested)
                    {
                        var CurrentContext = CurrentNode?.Evaluate();

                        if (CurrentContext is IContext Context && InnerNode is NodeNested NestedInner)
                        {
                            NestedInner.CurrentNode.Context = Context;

                            CurrentNode = NestedInner.CurrentNode;
                        }
                        else throw new InvalidOperationException("This variable is not a context");
                    }
                }
               
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
