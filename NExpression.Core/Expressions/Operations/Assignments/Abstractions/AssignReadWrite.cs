using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Assignments.Abstractions
{
    internal class AssignReadWrite : IOperation
    {
        private IContext? Context { get; }
        private IOperation? Operation { get; }
        private MathOperation MathOperation { get; }
        public AssignReadWrite(IContext? Context, IOperation? Operation, MathOperation MathOperation)
        {
            this.Context = Context;
            this.Operation = Operation;
            this.MathOperation = MathOperation;
        }

        public object? Evaluate(params object?[] Params)
        {
            object? Variable = Params[0];
            object? AssignValue = Params[1];

            if (Context == null)
            {
                throw new NullContextException(new ExpressionEvaluationException(MathOperation, Variable, AssignValue));
            }
            string? VariableName = Variable?.ToString();
            if (VariableName == null)
            {
                throw new NullVariableException(Context, VariableName, new ExpressionEvaluationException(MathOperation, Variable, AssignValue));
            }
            if (Context is not ISetVariableContext WriteContext)
            {
                throw new InvalidOperationContextException(Context, "WRITE", new ExpressionEvaluationException(MathOperation, Variable, AssignValue));
            }

            if (Context is not IGetVariableContext ReadContext)
            {
                throw new InvalidOperationContextException(Context, "READ", new ExpressionEvaluationException(MathOperation, Variable, AssignValue));
            }
            if (ReadContext.ResolveVariable(VariableName, out object? ContextValue))
            {
                object? NewValue = Operation?.Evaluate(ContextValue, AssignValue);

                WriteContext.AssignVariable(VariableName, NewValue);

                return NewValue;
            }
            throw new NullVariableException(Context, VariableName, new ExpressionEvaluationException(MathOperation, Variable, AssignValue));
        }
    }
}
