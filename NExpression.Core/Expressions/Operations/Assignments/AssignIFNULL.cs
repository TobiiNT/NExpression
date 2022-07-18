using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;
using NExpression.Core.Expressions.Operations.Logicals;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignIFNULL : IOperation
    {
        private IContext? Context { set; get; }
        public AssignIFNULL(IContext? Context)
        {
            this.Context = Context;
        }

        public Func<object?, object?, object?, object> Execute
        {
            get
            {
                return (FirstArg, SecondArg, ThirdArg) =>
                {
                    return LogicExecute(MathOperation.AssignIFNULL, FirstArg, SecondArg);
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
                object? NewValue = new LogicalIFNULL().LogicExecute(Operation, ContextValue, SecondArg);

                WriteContext.AssignVariable(VariableName, NewValue);

                return NewValue;
            }
            throw new NullVariableException(VariableName, new ExpressionEvaluationException(Operation, Variable, SecondArg));
        }
    }
}
