using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Logicals
{
    internal class LogicalOR : IOperation
    {
        public Func<object?, object?, object?, object> Execute
        {
            get
            {
                return (FirstArg, SecondArg, ThirdArg) =>
                {
                    return LogicExecute(MathOperation.LogicalOR, FirstArg, SecondArg);
                };
            }
        }

        public object LogicExecute(MathOperation Operation, object? FirstArg = null, object? SecondArg = null, object? ThirdArg = null)
        {
            if (FirstArg == null || SecondArg == null)
            {
                throw new ArgumentNullException("Cannot logical null value", new ExpressionEvaluationException(Operation, FirstArg, SecondArg));
            }

            TypeCode TypeCodeA = Type.GetTypeCode(FirstArg.GetType());
            TypeCode TypeCodeB = Type.GetTypeCode(SecondArg.GetType());

            if (TypeCodeA != TypeCode.Boolean || TypeCodeB != TypeCode.Boolean)
            {
                goto ThrowException;
            }

            return (bool)FirstArg || (bool)SecondArg;

        ThrowException:
            throw new InvalidMathOperatorException(Operation, TypeCodeA, TypeCodeB, new ExpressionEvaluationException(Operation, FirstArg, SecondArg));
        }
    }
}
