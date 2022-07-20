using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Abstractions
{
    internal class ContextWrite : IOperation
    {
        private IContext? Context { get; }
        private MathOperation MathOperation { get; }
        public ContextWrite(IContext? Context, MathOperation MathOperation)
        {
            this.Context = Context;
            this.MathOperation = MathOperation;
        }

        public object? Evaluate(params object?[] Params)
        {
            object? Variable = Params[0];
            object? AssignValue = Params[1];
            bool? IsDeclare = (bool?)Params[2];
            Type? DeclareType = (Type?)Params[3];

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

            if (IsDeclare ?? false)
            {
                WriteContext.DeclareVariable(VariableName, DeclareType);
            }
            WriteContext.AssignVariable(VariableName, AssignValue);

            return AssignValue;
        }
    }
}
