using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Conditions
{
    internal class ConditionTenary : IOperation
    {
        public Func<object?, object?, object?, object> Execute
        {
            get
            {
                return (Condition, Left, Right) =>
                {
                    return LogicExecute(MathOperation.ConditionTenary, Condition, Left, Right);
                };
            }
        }
        public object LogicExecute(MathOperation Operation, object? FirstArg = null, object? SecondArg = null, object? ThirdArg = null)
        {
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
