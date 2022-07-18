using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Maths
{
    public class MathAbs : IOperation
    {
        public Func<object?, object?, object?, object> Execute
        {
            get
            {
                return (FirstArg, SecondArg, ThirdArg) =>
                {
                    return LogicExecute(MathOperation.FunctionCall, FirstArg);
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
                case TypeCode.Byte: return (byte?)FirstArg;
                case TypeCode.SByte: return Math.Abs((sbyte)FirstArg);
                case TypeCode.Int16: return Math.Abs((short)FirstArg);
                case TypeCode.UInt16: return (ushort?)FirstArg;
                case TypeCode.Int32: return Math.Abs((int)FirstArg);
                case TypeCode.UInt32: return (uint)FirstArg;
                case TypeCode.Int64: return Math.Abs((long)FirstArg);
                case TypeCode.UInt64: return (ulong)FirstArg;
                case TypeCode.Single: return Math.Abs((float)FirstArg);
                case TypeCode.Double: return Math.Abs((double)FirstArg);
                case TypeCode.Decimal: return Math.Abs((decimal)FirstArg);
            }

        ThrowException:
            throw new InvalidMathOperatorException(Operation, TypeCodeA, new ExpressionEvaluationException(Operation, FirstArg));
        }
    }
}
