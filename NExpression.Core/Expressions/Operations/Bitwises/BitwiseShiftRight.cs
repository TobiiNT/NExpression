using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Bitwises
{
    internal class BitwiseShiftRight : IOperation
    {
        public Func<object?, object?, object?, object> Execute
        {
            get
            {
                return (FirstArg, SecondArg, ThirdArg) =>
                {
                    return LogicExecute(MathOperation.BitwiseShiftRight, FirstArg, SecondArg);
                };
            }
        }

        public object LogicExecute(MathOperation Operation, object? FirstArg = null, object? SecondArg = null, object? ThirdArg = null)
        {
            if (FirstArg == null || SecondArg == null)
            {
                throw new ArgumentNullException("Cannot calculate null value", new ExpressionEvaluationException(Operation, FirstArg, SecondArg));
            }

            TypeCode TypeCodeA = Type.GetTypeCode(FirstArg.GetType());
            TypeCode TypeCodeB = Type.GetTypeCode(SecondArg.GetType());

            if (TypeCodeA == TypeCode.Boolean || TypeCodeB == TypeCode.Boolean ||
                TypeCodeA == TypeCode.String || TypeCodeB == TypeCode.String)
            {
                goto ThrowException;
            }

            if (Convert.ToDouble(SecondArg) < 0)
            {
                throw new InvalidMathOperatorException(Operation, TypeCodeA, TypeCodeB, new ExpressionEvaluationException(Operation, FirstArg, SecondArg));
            }

            switch (TypeCodeA)
            {
                case TypeCode.Byte:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (byte)FirstArg >> (byte)SecondArg;
                        case TypeCode.SByte: return (byte)FirstArg >> (sbyte)SecondArg;
                        case TypeCode.Int16: return (byte)FirstArg >> (short)SecondArg;
                        case TypeCode.UInt16: return (byte)FirstArg >> (ushort)SecondArg;
                        case TypeCode.Int32: return (byte)FirstArg >> (int)SecondArg;
                        case TypeCode.UInt32: goto ThrowException; ;
                        case TypeCode.Int64: goto ThrowException;
                        case TypeCode.UInt64: goto ThrowException;
                        case TypeCode.Single: goto ThrowException;
                        case TypeCode.Double: goto ThrowException;
                        case TypeCode.Decimal: goto ThrowException;
                    }
                    break;
                case TypeCode.SByte:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (sbyte)FirstArg >> (byte)SecondArg;
                        case TypeCode.SByte: return (sbyte)FirstArg >> (sbyte)SecondArg;
                        case TypeCode.Int16: return (sbyte)FirstArg >> (short)SecondArg;
                        case TypeCode.UInt16: return (sbyte)FirstArg >> (ushort)SecondArg;
                        case TypeCode.Int32: return (sbyte)FirstArg >> (int)SecondArg;
                        case TypeCode.UInt32: goto ThrowException;
                        case TypeCode.Int64: goto ThrowException;
                        case TypeCode.UInt64: goto ThrowException;
                        case TypeCode.Single: goto ThrowException;
                        case TypeCode.Double: goto ThrowException;
                        case TypeCode.Decimal: goto ThrowException;
                    }
                    break;

                case TypeCode.Int16:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (short)FirstArg >> (byte)SecondArg;
                        case TypeCode.SByte: return (short)FirstArg >> (sbyte)SecondArg;
                        case TypeCode.Int16: return (short)FirstArg >> (short)SecondArg;
                        case TypeCode.UInt16: return (short)FirstArg >> (ushort)SecondArg;
                        case TypeCode.Int32: return (short)FirstArg >> (int)SecondArg;
                        case TypeCode.UInt32: goto ThrowException;
                        case TypeCode.Int64: goto ThrowException;
                        case TypeCode.UInt64: goto ThrowException;
                        case TypeCode.Single: goto ThrowException;
                        case TypeCode.Double: goto ThrowException;
                        case TypeCode.Decimal: goto ThrowException;
                    }
                    break;

                case TypeCode.UInt16:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (ushort)FirstArg >> (byte)SecondArg;
                        case TypeCode.SByte: return (ushort)FirstArg >> (sbyte)SecondArg;
                        case TypeCode.Int16: return (ushort)FirstArg >> (short)SecondArg;
                        case TypeCode.UInt16: return (ushort)FirstArg >> (ushort)SecondArg;
                        case TypeCode.Int32: return (ushort)FirstArg >> (int)SecondArg;
                        case TypeCode.UInt32: goto ThrowException;
                        case TypeCode.Int64: goto ThrowException;
                        case TypeCode.UInt64: goto ThrowException;
                        case TypeCode.Single: goto ThrowException;
                        case TypeCode.Double: goto ThrowException;
                        case TypeCode.Decimal: goto ThrowException;
                    }
                    break;

                case TypeCode.Int32:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (int)FirstArg >> (byte)SecondArg;
                        case TypeCode.SByte: return (int)FirstArg >> (sbyte)SecondArg;
                        case TypeCode.Int16: return (int)FirstArg >> (short)SecondArg;
                        case TypeCode.UInt16: return (int)FirstArg >> (ushort)SecondArg;
                        case TypeCode.Int32: return (int)FirstArg >> (int)SecondArg;
                        case TypeCode.UInt32: goto ThrowException;
                        case TypeCode.Int64: goto ThrowException;
                        case TypeCode.UInt64: goto ThrowException;
                        case TypeCode.Single: goto ThrowException;
                        case TypeCode.Double: goto ThrowException;
                        case TypeCode.Decimal: goto ThrowException;
                    }
                    break;

                case TypeCode.UInt32:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (uint)FirstArg >> (byte)SecondArg;
                        case TypeCode.SByte: return (uint)FirstArg >> (sbyte)SecondArg;
                        case TypeCode.Int16: return (uint)FirstArg >> (short)SecondArg;
                        case TypeCode.UInt16: return (uint)FirstArg >> (ushort)SecondArg;
                        case TypeCode.Int32: return (uint)FirstArg >> (int)SecondArg;
                        case TypeCode.UInt32: goto ThrowException;
                        case TypeCode.Int64: goto ThrowException;
                        case TypeCode.UInt64: goto ThrowException;
                        case TypeCode.Single: goto ThrowException;
                        case TypeCode.Double: goto ThrowException;
                        case TypeCode.Decimal: goto ThrowException;
                    }
                    break;

                case TypeCode.Int64:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (long)FirstArg >> (byte)SecondArg;
                        case TypeCode.SByte: return (long)FirstArg >> (sbyte)SecondArg;
                        case TypeCode.Int16: return (long)FirstArg >> (short)SecondArg;
                        case TypeCode.UInt16: return (long)FirstArg >> (ushort)SecondArg;
                        case TypeCode.Int32: return (long)FirstArg >> (int)SecondArg;
                        case TypeCode.UInt32: goto ThrowException;
                        case TypeCode.Int64: goto ThrowException;
                        case TypeCode.UInt64: goto ThrowException;
                        case TypeCode.Single: goto ThrowException;
                        case TypeCode.Double: goto ThrowException;
                        case TypeCode.Decimal: goto ThrowException;
                    }
                    break;

                case TypeCode.UInt64:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (ulong)FirstArg >> (byte)SecondArg;
                        case TypeCode.SByte: goto ThrowException;
                        case TypeCode.Int16: goto ThrowException;
                        case TypeCode.UInt16: return (ulong)FirstArg >> (ushort)SecondArg;
                        case TypeCode.Int32: goto ThrowException;
                        case TypeCode.UInt32: goto ThrowException;
                        case TypeCode.Int64: goto ThrowException;
                        case TypeCode.UInt64: goto ThrowException;
                        case TypeCode.Single: goto ThrowException;
                        case TypeCode.Double: goto ThrowException;
                        case TypeCode.Decimal: goto ThrowException;
                    }
                    break;

                case TypeCode.Single: goto ThrowException;
                case TypeCode.Double: goto ThrowException;
                case TypeCode.Decimal: goto ThrowException;
            }

        ThrowException:
            throw new InvalidMathOperatorException(Operation, TypeCodeA, TypeCodeB, new ExpressionEvaluationException(Operation, FirstArg, SecondArg));
        }
    }
}
