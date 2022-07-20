using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Nodes.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeVariable : INode
    {
        public INode? InnerNode => null;
        public IContext? Context { set; get; }

        public string VariableName { set; get; }
        public NodeVariable(string VariableName)
        {
            this.VariableName = VariableName;
        }
        public void SetContext(IContext? Context) => this.Context = Context;

        public object? Evaluate()
        {
            if (Context != null)
            {
                if (Context is IGetVariableContext VariableContext)
                {
                    if (VariableContext.ResolveVariable(VariableName, out object? ContextValue))
                    {
                        return ContextValue;
                    }
                    else throw new NullReferenceException($"Variable '{VariableName}' is not assigned");
                }
                throw new InvalidOperationContextException(Context, "READ");
            }
            throw new NullContextException();
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
        }
    }
}
