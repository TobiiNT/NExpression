using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Nodes.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeFunctionCall : INode
    {
        public string FunctionName { private set; get; }
        public INode[] Arguments { private set; get; }

        public NodeFunctionCall(string FunctionName, INode[] Arguments)
        {
            this.FunctionName = FunctionName;
            this.Arguments = Arguments;
        }

        public object? Evaluate() => Evaluate(null);
        public object? Evaluate(IContext? ReadContext = null)
        {
            if (ReadContext != null)
            {
                if (ReadContext is IFunctionContext FunctionContext)
                {
                    var ArguementValues = new object?[Arguments.Length];
                    for (int i = 0; i < Arguments.Length; i++)
                    {
                        ArguementValues[i] = Arguments[i].Evaluate(ReadContext);
                    }
                    var Result = FunctionContext.CallFunction(FunctionName, ArguementValues);

                    return Result;
                }
                throw new InvalidOperationContextException(ReadContext, "READ");
            }
            throw new NullReferenceException(FunctionName);
        }
        public T? Evaluate<T>() => Evaluate<T>(null);
        public T? Evaluate<T>(IContext? ReadContext = null)
        {
            return (T?)Convert.ChangeType(Evaluate(), typeof(T?));
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
