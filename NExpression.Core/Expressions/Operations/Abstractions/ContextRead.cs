using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Abstractions
{
    internal class ContextRead : IOperation
    {
        private IContext? Context { get; }
        private MathOperation MathOperation { get; }
        public ContextRead(IContext? Context)
        {
            this.Context = Context;
        }

        public object? Evaluate(params object?[] Params)
        {
            object? Variable = Params[0];

            if (Context == null)
            {
                throw new NullContextException(new ExpressionEvaluationException(MathOperation, Variable));
            }
            string? VariableName = Variable?.ToString();
            if (VariableName == null)
            {
                throw new NullVariableException(Context, VariableName, new ExpressionEvaluationException(MathOperation, Variable));
            }

            if (Context is not IGetVariableContext ReadContext)
            {
                throw new InvalidOperationContextException(Context, "READ", new ExpressionEvaluationException(MathOperation, Variable));
            }
            if (ReadContext.ResolveVariable(VariableName, out object? ContextValue))
            {
                return ContextValue;
            }
            throw new NullVariableException(Context, VariableName, new ExpressionEvaluationException(MathOperation, Variable));
        }
    }
}
