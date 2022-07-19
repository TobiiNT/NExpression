using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Assignments.Abstractions
{
    internal class AssignWrite : IOperation
    {
        private IContext? Context { get; }
        private MathOperation MathOperation { get; }
        public AssignWrite(IContext? Context, MathOperation MathOperation)
        {
            this.Context = Context;
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
                throw new NullVariableException(VariableName, new ExpressionEvaluationException(MathOperation, Variable, AssignValue));
            }
            if (Context is not ISetVariableContext WriteContext)
            {
                throw new InvalidOperationContextException(Context, "WRITE", new ExpressionEvaluationException(MathOperation, Variable, AssignValue));
            }

            WriteContext.AssignVariable(VariableName, AssignValue);

            return AssignValue;
        }
    }
}
