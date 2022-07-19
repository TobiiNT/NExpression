using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Logicals
{
    internal class LogicalNOT : IOperation
    {
        public object? Evaluate(params object?[] Params)
        {
            MathOperation Operation = MathOperation.LogicalNOT;
            object? FirstArg = Params[0];

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
