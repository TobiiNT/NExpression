using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Logicals
{
    internal class LogicalNOT : IOperation
    {
        public Func<object?, object?, object?, object> Execute
        {
            get
            {
                return (FirstArg, SecondArg, ThirdArg) =>
                {
                    return LogicExecute(MathOperation.LogicalNOT, FirstArg);
                };
            }
        }

        public object LogicExecute(MathOperation Operation, object? FirstArg = null, object? SecondArg = null, object? ThirdArg = null)
        {
            if (FirstArg == null)
            {
                throw new ArgumentNullException("Cannot logical null value", new ExpressionEvaluationException(Operation));
            }

            TypeCode TypeCodeA = Type.GetTypeCode(FirstArg.GetType());

            if (TypeCodeA != TypeCode.Boolean)
            {
                goto ThrowException;
            }

            return !(bool)FirstArg;

        ThrowException:
            throw new InvalidMathOperatorException(Operation, TypeCodeA, new ExpressionEvaluationException(Operation, FirstArg));
        }
    }
}
