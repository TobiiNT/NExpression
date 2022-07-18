using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Calculations
{
    internal class CalculationFactorial : IOperation
    {
        public Func<object?, object?, object?, object> Execute
        {
            get
            {
                return (FirstArg, SecondArg, ThirdArg) =>
                {
                    return LogicExecute(MathOperation.Factorial, FirstArg);
                };
            }
        }

        public object LogicExecute(MathOperation Operation, object? FirstArg = null, object? SecondArg = null, object? ThirdArg = null)
        {
            if (FirstArg == null)
            {
                throw new ArgumentNullException("Cannot calculate null value", new ExpressionEvaluationException(Operation));
            }
            
            TypeCode TypeCodeA = Type.GetTypeCode(FirstArg.GetType());

            if (Convert.ToDouble(FirstArg) < 0)
            {
                throw new InvalidMathOperatorException(Operation, TypeCodeA, new ExpressionEvaluationException(Operation, FirstArg));
            }

            switch (TypeCodeA)
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                    {
                        long Value = 1;
                        for (int i = 1; i <= (int)FirstArg; i++)
                        {
                            Value = Value * i;
                        }
                        return Value;
                    }

                case TypeCode.Int64:
                case TypeCode.UInt64:
                    {
                        long Value = 1;
                        for (long i = 1; i <= (long)FirstArg; i++)
                        {
                            Value = Value * i;
                        }
                        return Value;
                    }
            }

            throw new InvalidMathOperatorException(Operation, TypeCodeA, new ExpressionEvaluationException(Operation, FirstArg));
        }
    }
}
