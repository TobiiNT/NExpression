using NExpression.Core.Expressions.Operations;
using NExpression.Core.Extensions;

namespace NExpression.Core.Exceptions
{
    public class ExpressionEvaluationException : Exception
    {
        public ExpressionEvaluationException(MathOperation Operation)
          : base($"Operation ({Operation.Symbol()},{Operation})")
        {

        }

        public ExpressionEvaluationException(MathOperation Operation, object? FirstArg)
          : base($"Operation ({Operation.Symbol()},{Operation}) | FirstArg ({FirstArg},{FirstArg?.GetType()})")
        {

        }

        public ExpressionEvaluationException(MathOperation Operation, object? FirstArg, object? SecondArg)
          : base($"Operation ({Operation.Symbol()},{Operation}) | FirstArg ({FirstArg},{FirstArg?.GetType()}) | SecondArg ({SecondArg},{SecondArg?.GetType()})")
        {

        }

        public ExpressionEvaluationException(MathOperation Operation, object? FirstArg, object? SecondArg, object? ThirdArg)
          : base($"Operation ({Operation.Symbol()},{Operation}) | FirstArg ({FirstArg},{FirstArg?.GetType()}) | SecondArg ({SecondArg},{SecondArg?.GetType()}) | ThirdArg ({ThirdArg},{ThirdArg?.GetType()})")
        {

        }
    }
}
