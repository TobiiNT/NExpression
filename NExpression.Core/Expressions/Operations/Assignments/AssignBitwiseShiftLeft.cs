using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Bitwises;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignBitwiseShiftLeft : IOperation
    {
        private IContext? Context { set; get; }
        public AssignBitwiseShiftLeft(IContext? Context)
        {
            this.Context = Context;
        }

        public Func<object?, object?, object?, object> Execute
        {
            get
            {
                return (FirstArg, SecondArg, ThirdArg) =>
                {
                    return LogicExecute(MathOperation.AssignBitwiseShiftLeft, FirstArg, SecondArg);
                };
            }
        }

        public object LogicExecute(MathOperation Operation, object? Variable = null, object? SecondArg = null, object? ThirdArg = null)
        {
            if (Context == null)
            {
                throw new NullContextException(new ExpressionEvaluationException(Operation, Variable, SecondArg));
            }
            string? VariableName = Variable?.ToString();
            if (VariableName == null)
            {
                throw new NullVariableException(VariableName, new ExpressionEvaluationException(Operation, Variable, SecondArg));
            }
            if (Context is not IGetVariableContext ReadContext)
            {
                throw new InvalidOperationContextException(Context, "READ", new ExpressionEvaluationException(Operation, Variable, SecondArg));
            }
            if (Context is not ISetVariableContext WriteContext)
            {
                throw new InvalidOperationContextException(Context, "WRITE", new ExpressionEvaluationException(Operation, Variable, SecondArg));
            }

            if (ReadContext.ResolveVariable(VariableName, out object? ContextValue))
            {
                object? NewValue = new BitwiseShiftLeft().LogicExecute(Operation, ContextValue, SecondArg);

                WriteContext.AssignVariable(VariableName, NewValue);

                return NewValue;
            }
            throw new NullVariableException(VariableName, new ExpressionEvaluationException(Operation, Variable, SecondArg));
        }
    }
}
