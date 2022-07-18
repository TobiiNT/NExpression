using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Calculations
{
    internal class CalculationNegative : IOperation
    {
        public Func<object?, object?, object?, object> Execute
        {
            get
            {
                return (FirstArg, SecondArg, ThirdArg) =>
                {
                    return LogicExecute(MathOperation.Negative, FirstArg);
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

            switch (TypeCodeA)
            {
                case TypeCode.Boolean: goto ThrowException;
                case TypeCode.Byte: return -(byte)FirstArg;
                case TypeCode.SByte: return -(sbyte)FirstArg;
                case TypeCode.Int16: return -(short)FirstArg;
                case TypeCode.UInt16: return -(ushort)FirstArg;
                case TypeCode.Int32: return -(int)FirstArg;
                case TypeCode.UInt32: return -(uint)FirstArg;
                case TypeCode.Int64: return -(long)FirstArg;
                case TypeCode.UInt64: goto ThrowException;
                case TypeCode.Single: return -(float)FirstArg;
                case TypeCode.Double: return -(double)FirstArg;
                case TypeCode.Decimal: return -(decimal)FirstArg;
            }

        ThrowException:
            throw new InvalidMathOperatorException(Operation, TypeCodeA, new ExpressionEvaluationException(Operation, FirstArg));
        }
    }
}
