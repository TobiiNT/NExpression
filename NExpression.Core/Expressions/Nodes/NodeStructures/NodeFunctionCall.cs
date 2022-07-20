using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Nodes.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeFunctionCall : INode
    {
        public INode? InnerNode => null;
        public IContext? Context { set; get; }

        public string FunctionName { private set; get; }
        public INode[] Arguments { private set; get; }

        public NodeFunctionCall(IContext? Context, string FunctionName, INode[] Arguments)
        {
            this.Context = Context;
            this.FunctionName = FunctionName;
            this.Arguments = Arguments;
        }

        public object? Evaluate()
        {
            if (Context != null)
            {
                if (Context is IFunctionContext FunctionContext)
                {
                    var ArguementValues = new object?[Arguments.Length];
                    for (int i = 0; i < Arguments.Length; i++)
                    {
                        ArguementValues[i] = Arguments[i].Evaluate();
                    }
                    var Result = FunctionContext.CallFunction(FunctionName, ArguementValues);

                    return Result;
                }
                throw new InvalidOperationContextException(Context, "READ");
            }
            throw new NullReferenceException(FunctionName);
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
            foreach (var Arguement in Arguments)
            {
                Arguement.Traverse(ref Nodes);
            }
        }
    }
}
