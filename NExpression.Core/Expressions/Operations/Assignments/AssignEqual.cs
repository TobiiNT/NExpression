using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignEqual : IOperation
    {
        private IContext? Context { set; get; }
        public AssignEqual(IContext? Context)
        {
            this.Context = Context;
        }

        public Func<object?, object?, object?, object> Execute
        {
            get
            {
                return (FirstArg, SecondArg, ThirdArg) =>
                {
                    return LogicExecute(MathOperation.AssignEqual, FirstArg, SecondArg);
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
            if (Context is not ISetVariableContext WriteContext)
            {
                throw new InvalidOperationContextException(Context, "WRITE", new ExpressionEvaluationException(Operation, Variable, SecondArg));
            }
            
            WriteContext.AssignVariable(VariableName, SecondArg);
            return SecondArg;
        }
    }
}
