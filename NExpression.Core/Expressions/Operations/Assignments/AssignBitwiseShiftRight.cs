using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Bitwises;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignBitwiseShiftRight : IOperation
    {
        private IContext? Context { set; get; }
        public AssignBitwiseShiftRight(IContext? Context)
        {
            this.Context = Context;
        }

        public object? Evaluate(params object?[] Params)
        {
            MathOperation Operation = MathOperation.AssignBitwiseShiftRight;
            object? Variable = Params[0];
            object? AssignValue = Params[1];

            if (Context == null)
            {
                throw new NullContextException(new ExpressionEvaluationException(Operation, Variable, AssignValue));
            }
            string? VariableName = Variable?.ToString();
            if (VariableName == null)
            {
                throw new NullVariableException(VariableName, new ExpressionEvaluationException(Operation, Variable, AssignValue));
            }
            if (Context is not IGetVariableContext ReadContext)
            {
                throw new InvalidOperationContextException(Context, "READ", new ExpressionEvaluationException(Operation, Variable, AssignValue));
            }
            if (Context is not ISetVariableContext WriteContext)
            {
                throw new InvalidOperationContextException(Context, "WRITE", new ExpressionEvaluationException(Operation, Variable, AssignValue));
            }

            if (ReadContext.ResolveVariable(VariableName, out object? ContextValue))
            {
                object? NewValue = new BitwiseShiftRight().Evaluate(ContextValue, AssignValue);

                WriteContext.AssignVariable(VariableName, NewValue);

                return NewValue;
            }
            throw new NullVariableException(VariableName, new ExpressionEvaluationException(Operation, Variable, AssignValue));
        }
    }
}
