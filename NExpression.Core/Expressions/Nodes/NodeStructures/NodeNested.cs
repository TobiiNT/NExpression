using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeNested : INode, INestedNode
    {
        public INode? CurrentNode { private set; get; }
        public INode? ChildrenNode { set; get; }

        public NodeNested(INode? CurrentNode)
        {
            this.CurrentNode = CurrentNode;
        }
        public void AssignChildren(INode? ChildrenNode)
        {
            this.ChildrenNode = ChildrenNode;
        }

        public object? Evaluate()
        {
            INode? FinalNode = EvaluateNestedToVariable(this);

            return FinalNode?.Evaluate();
        }

        public INode? GetFinalNode()
        {
            INode? FinalNode = EvaluateNestedToVariable(this);

            return FinalNode;
        }

        private INode? EvaluateNestedToVariable(NodeNested _NodeNested)
        {
            var _ChildrenContext = _NodeNested.CurrentNode?.Evaluate();

            if (_ChildrenContext != null)
            {
                if (_NodeNested.ChildrenNode != null)
                {
                    if (_ChildrenContext is IContext ChildrenContext)
                    {
                        if (_NodeNested.ChildrenNode is NodeVariable Variable)
                        {
                            Variable.SetContext(ChildrenContext);

                            return Variable;
                        }
                        else if (_NodeNested.ChildrenNode is NodeFunctionCall Function)
                        {
                            Function.SetContext(ChildrenContext);

                            return Function;
                        }
                        else if (_NodeNested.ChildrenNode is NodeNested Nested)
                        {
                            if (Nested.CurrentNode is IContextNode ContextNode)
                            {
                                ContextNode.SetContext(ChildrenContext);
                            }
                            return EvaluateNestedToVariable(Nested);
                        }

                    }
                    else
                    {
                        if (_NodeNested.ChildrenNode is NodeFunctionCall Function)
                        {
                            //Function.SetContext(_NodeNested.CurrentNode.con);
                            Function.SetCaller(_NodeNested.CurrentNode);

                            return Function;
                        }
                    }
                }
            }
            return null;
        }

        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
            ChildrenNode?.Traverse(ref Nodes);
        }
    }
}
