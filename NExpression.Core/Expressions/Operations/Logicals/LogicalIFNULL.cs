using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Logicals
{
    internal class LogicalIFNULL : IOperation
    {
        public Func<object?, object?, object?, object> Execute
        {
            get
            {
                return (FirstArg, SecondArg, ThirdArg) =>
                {
                    return LogicExecute(MathOperation.LogicalIFNULL, FirstArg, SecondArg);
                };
            }
        }

        public object LogicExecute(MathOperation Operation, object? FirstArg = null, object? SecondArg = null, object? ThirdArg = null)
        {
            if (FirstArg == null)
            {
                if (SecondArg == null)
                {
                    throw new ArgumentNullException("Cannot access null value", new ExpressionEvaluationException(Operation, FirstArg, SecondArg));
                }
                else
                {
                    return SecondArg;
                }
            }
            else return FirstArg;
        }
    }
}
