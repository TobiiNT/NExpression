using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Calculations
{
    internal class CalculationAdd : IOperation
    {
        public object? Evaluate(params object?[] Params)
        {
            MathOperation Operation = MathOperation.Add;
            object? FirstArg = Params[0];
            object? SecondArg = Params[1];

            if (FirstArg == null || SecondArg == null)
            {
                throw new ArgumentNullException("Cannot calculate null value", new ExpressionEvaluationException(Operation, FirstArg, SecondArg));
            }

            TypeCode TypeCodeA = Type.GetTypeCode(FirstArg.GetType());
            TypeCode TypeCodeB = Type.GetTypeCode(SecondArg.GetType());

            if (TypeCodeA == TypeCode.Boolean || TypeCodeB == TypeCode.Boolean)
            {
                goto ThrowException;
            }

            switch (TypeCodeA)
            {
                case TypeCode.Char:
                    return FirstArg.ToString() + SecondArg.ToString();

                case TypeCode.String:
                    return (string)FirstArg + SecondArg.ToString();

                case TypeCode.Byte:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (byte)FirstArg + (byte)SecondArg;
                        case TypeCode.SByte: return (byte)FirstArg + (sbyte)SecondArg;
                        case TypeCode.Int16: return (byte)FirstArg + (short)SecondArg;
                        case TypeCode.UInt16: return (byte)FirstArg + (ushort)SecondArg;
                        case TypeCode.Int32: return (byte)FirstArg + (int)SecondArg;
                        case TypeCode.UInt32: return (byte)FirstArg + (uint)SecondArg;
                        case TypeCode.Int64: return (byte)FirstArg + (long)SecondArg;
                        case TypeCode.UInt64: return (byte)FirstArg + (ulong)SecondArg;
                        case TypeCode.Single: return (byte)FirstArg + (float)SecondArg;
                        case TypeCode.Double: return (byte)FirstArg + (double)SecondArg;
                        case TypeCode.Decimal: return (byte)FirstArg + (decimal)SecondArg;
                    }
                    break;
                case TypeCode.SByte:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (sbyte)FirstArg + (byte)SecondArg;
                        case TypeCode.SByte: return (sbyte)FirstArg + (sbyte)SecondArg;
                        case TypeCode.Int16: return (sbyte)FirstArg + (short)SecondArg;
                        case TypeCode.UInt16: return (sbyte)FirstArg + (ushort)SecondArg;
                        case TypeCode.Int32: return (sbyte)FirstArg + (int)SecondArg;
                        case TypeCode.UInt32: return (sbyte)FirstArg + (uint)SecondArg;
                        case TypeCode.Int64: return (sbyte)FirstArg + (long)SecondArg;
                        case TypeCode.UInt64: goto ThrowException;
                        case TypeCode.Single: return (sbyte)FirstArg + (float)SecondArg;
                        case TypeCode.Double: return (sbyte)FirstArg + (double)SecondArg;
                        case TypeCode.Decimal: return (sbyte)FirstArg + (decimal)SecondArg;
                    }
                    break;

                case TypeCode.Int16:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (short)FirstArg + (byte)SecondArg;
                        case TypeCode.SByte: return (short)FirstArg + (sbyte)SecondArg;
                        case TypeCode.Int16: return (short)FirstArg + (short)SecondArg;
                        case TypeCode.UInt16: return (short)FirstArg + (ushort)SecondArg;
                        case TypeCode.Int32: return (short)FirstArg + (int)SecondArg;
                        case TypeCode.UInt32: return (short)FirstArg + (uint)SecondArg;
                        case TypeCode.Int64: return (short)FirstArg + (long)SecondArg;
                        case TypeCode.UInt64: goto ThrowException;
                        case TypeCode.Single: return (short)FirstArg + (float)SecondArg;
                        case TypeCode.Double: return (short)FirstArg + (double)SecondArg;
                        case TypeCode.Decimal: return (short)FirstArg + (decimal)SecondArg;
                    }
                    break;

                case TypeCode.UInt16:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (ushort)FirstArg + (byte)SecondArg;
                        case TypeCode.SByte: return (ushort)FirstArg + (sbyte)SecondArg;
                        case TypeCode.Int16: return (ushort)FirstArg + (short)SecondArg;
                        case TypeCode.UInt16: return (ushort)FirstArg + (ushort)SecondArg;
                        case TypeCode.Int32: return (ushort)FirstArg + (int)SecondArg;
                        case TypeCode.UInt32: return (ushort)FirstArg + (uint)SecondArg;
                        case TypeCode.Int64: return (ushort)FirstArg + (long)SecondArg;
                        case TypeCode.UInt64: return (ushort)FirstArg + (ulong)SecondArg;
                        case TypeCode.Single: return (ushort)FirstArg + (float)SecondArg;
                        case TypeCode.Double: return (ushort)FirstArg + (double)SecondArg;
                        case TypeCode.Decimal: return (ushort)FirstArg + (decimal)SecondArg;
                    }
                    break;

                case TypeCode.Int32:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (int)FirstArg + (byte)SecondArg;
                        case TypeCode.SByte: return (int)FirstArg + (sbyte)SecondArg;
                        case TypeCode.Int16: return (int)FirstArg + (short)SecondArg;
                        case TypeCode.UInt16: return (int)FirstArg + (ushort)SecondArg;
                        case TypeCode.Int32: return (int)FirstArg + (int)SecondArg;
                        case TypeCode.UInt32: return (int)FirstArg + (uint)SecondArg;
                        case TypeCode.Int64: return (int)FirstArg + (long)SecondArg;
                        case TypeCode.UInt64: goto ThrowException;
                        case TypeCode.Single: return (int)FirstArg + (float)SecondArg;
                        case TypeCode.Double: return (int)FirstArg + (double)SecondArg;
                        case TypeCode.Decimal: return (int)FirstArg + (decimal)SecondArg;
                    }
                    break;

                case TypeCode.UInt32:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (uint)FirstArg + (byte)SecondArg;
                        case TypeCode.SByte: return (uint)FirstArg + (sbyte)SecondArg;
                        case TypeCode.Int16: return (uint)FirstArg + (short)SecondArg;
                        case TypeCode.UInt16: return (uint)FirstArg + (ushort)SecondArg;
                        case TypeCode.Int32: return (uint)FirstArg + (int)SecondArg;
                        case TypeCode.UInt32: return (uint)FirstArg + (uint)SecondArg;
                        case TypeCode.Int64: return (uint)FirstArg + (long)SecondArg;
                        case TypeCode.UInt64: return (uint)FirstArg + (ulong)SecondArg;
                        case TypeCode.Single: return (uint)FirstArg + (float)SecondArg;
                        case TypeCode.Double: return (uint)FirstArg + (double)SecondArg;
                        case TypeCode.Decimal: return (uint)FirstArg + (decimal)SecondArg;
                    }
                    break;

                case TypeCode.Int64:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (long)FirstArg + (byte)SecondArg;
                        case TypeCode.SByte: return (long)FirstArg + (sbyte)SecondArg;
                        case TypeCode.Int16: return (long)FirstArg + (short)SecondArg;
                        case TypeCode.UInt16: return (long)FirstArg + (ushort)SecondArg;
                        case TypeCode.Int32: return (long)FirstArg + (int)SecondArg;
                        case TypeCode.UInt32: return (long)FirstArg + (uint)SecondArg;
                        case TypeCode.Int64: return (long)FirstArg + (long)SecondArg;
                        case TypeCode.UInt64: goto ThrowException;
                        case TypeCode.Single: return (long)FirstArg + (float)SecondArg;
                        case TypeCode.Double: return (long)FirstArg + (double)SecondArg;
                        case TypeCode.Decimal: return (long)FirstArg + (decimal)SecondArg;
                    }
                    break;

                case TypeCode.UInt64:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (ulong)FirstArg + (byte)SecondArg;
                        case TypeCode.SByte: goto ThrowException;
                        case TypeCode.Int16: goto ThrowException;
                        case TypeCode.UInt16: return (ulong)FirstArg + (ushort)SecondArg;
                        case TypeCode.Int32: goto ThrowException;
                        case TypeCode.UInt32: return (ulong)FirstArg + (uint)SecondArg;
                        case TypeCode.Int64: goto ThrowException;
                        case TypeCode.UInt64: return (ulong)FirstArg + (ulong)SecondArg;
                        case TypeCode.Single: return (ulong)FirstArg + (float)SecondArg;
                        case TypeCode.Double: return (ulong)FirstArg + (double)SecondArg;
                        case TypeCode.Decimal: return (ulong)FirstArg + (decimal)SecondArg;
                    }
                    break;

                case TypeCode.Single:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (float)FirstArg + (byte)SecondArg;
                        case TypeCode.SByte: return (float)FirstArg + (sbyte)SecondArg;
                        case TypeCode.Int16: return (float)FirstArg + (short)SecondArg;
                        case TypeCode.UInt16: return (float)FirstArg + (ushort)SecondArg;
                        case TypeCode.Int32: return (float)FirstArg + (int)SecondArg;
                        case TypeCode.UInt32: return (float)FirstArg + (uint)SecondArg;
                        case TypeCode.Int64: return (float)FirstArg + (long)SecondArg;
                        case TypeCode.UInt64: return (float)FirstArg + (ulong)SecondArg;
                        case TypeCode.Single: return (float)FirstArg + (float)SecondArg;
                        case TypeCode.Double: return (float)FirstArg + (double)SecondArg;
                        case TypeCode.Decimal: return Convert.ToDecimal(FirstArg) + (decimal)SecondArg;
                    }
                    break;

                case TypeCode.Double:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (double)FirstArg + (byte)SecondArg;
                        case TypeCode.SByte: return (double)FirstArg + (sbyte)SecondArg;
                        case TypeCode.Int16: return (double)FirstArg + (short)SecondArg;
                        case TypeCode.UInt16: return (double)FirstArg + (ushort)SecondArg;
                        case TypeCode.Int32: return (double)FirstArg + (int)SecondArg;
                        case TypeCode.UInt32: return (double)FirstArg + (uint)SecondArg;
                        case TypeCode.Int64: return (double)FirstArg + (long)SecondArg;
                        case TypeCode.UInt64: return (double)FirstArg + (ulong)SecondArg;
                        case TypeCode.Single: return (double)FirstArg + (float)SecondArg;
                        case TypeCode.Double: return (double)FirstArg + (double)SecondArg;
                        case TypeCode.Decimal: return Convert.ToDecimal(FirstArg) + (decimal)SecondArg;
                    }
                    break;

                case TypeCode.Decimal:
                    switch (TypeCodeB)
                    {
                        case TypeCode.Byte: return (decimal)FirstArg + (byte)SecondArg;
                        case TypeCode.SByte: return (decimal)FirstArg + (sbyte)SecondArg;
                        case TypeCode.Int16: return (decimal)FirstArg + (short)SecondArg;
                        case TypeCode.UInt16: return (decimal)FirstArg + (ushort)SecondArg;
                        case TypeCode.Int32: return (decimal)FirstArg + (int)SecondArg;
                        case TypeCode.UInt32: return (decimal)FirstArg + (uint)SecondArg;
                        case TypeCode.Int64: return (decimal)FirstArg + (long)SecondArg;
                        case TypeCode.UInt64: return (decimal)FirstArg + (ulong)SecondArg;
                        case TypeCode.Single: return (decimal)FirstArg + Convert.ToDecimal(SecondArg);
                        case TypeCode.Double: return (decimal)FirstArg + Convert.ToDecimal(SecondArg);
                        case TypeCode.Decimal: return (decimal)FirstArg + (decimal)SecondArg;
                    }
                    break;
            }

            ThrowException:
            throw new InvalidMathOperatorException(Operation, TypeCodeA, TypeCodeB, new ExpressionEvaluationException(Operation, FirstArg, SecondArg));
        }
    }
}
