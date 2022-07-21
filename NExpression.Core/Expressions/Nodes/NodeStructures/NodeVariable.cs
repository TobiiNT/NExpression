using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations.Abstractions;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeVariable : INode, IContextNode
    {
        public IContext? Context { set; get; }

        public string VariableName { set; get; }
        public NodeVariable(string VariableName)
        {
            this.VariableName = VariableName;
        }
        public NodeVariable(string VariableName, IContext? DefaultContext)
        {
            this.VariableName = VariableName;
            this.Context = DefaultContext;
        }
        public void SetContext(IContext? Context) => this.Context = Context;

        public object? Evaluate()
        {
            return new ContextRead(Context).Evaluate(VariableName);
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
        }
    }
}
