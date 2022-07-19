using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Conditions
{
    internal class ConditionTernary : IOperation
    {
        public object? Evaluate(params object?[] Params)
        {
            MathOperation Operation = MathOperation.ConditionTernary;
            object? FirstArg = Params[0];
            object? SecondArg = Params[1];
            object? ThirdArg = Params[2];

            if (FirstArg == null)
            {
                throw new ArgumentNullException("Condition cannot be null", new ExpressionEvaluationException(Operation));
            }

            TypeCode TypeCodeA = Type.GetTypeCode(FirstArg.GetType());
            
            if (TypeCodeA != TypeCode.Boolean)
            {
                throw new ArgumentException($"Invalid condition in three operator condition", new ExpressionEvaluationException(Operation, FirstArg, SecondArg, ThirdArg));
            }

            object? ReturnValue = (bool)FirstArg ? SecondArg : ThirdArg;

            if (ReturnValue == null)
            {
                throw new ArgumentNullException("Cannot access null value", new ExpressionEvaluationException(Operation, FirstArg, SecondArg));
            }
            else
            {
                return ReturnValue;
            }
        }
    }
}
