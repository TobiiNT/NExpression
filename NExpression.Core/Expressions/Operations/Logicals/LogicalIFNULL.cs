using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Logicals
{
    internal class LogicalIFNULL : IOperation
    {
        public object? Evaluate(params object?[] Params)
        {
            MathOperation Operation = MathOperation.LogicalIFNULL;
            object? FirstArg = Params[0];
            object? SecondArg = Params[1];

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
