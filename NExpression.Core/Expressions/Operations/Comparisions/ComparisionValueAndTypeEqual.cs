﻿using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Comparisions
{
    internal class ComparisionValueAndTypeEqual : IOperation
    {
        public Func<object?, object?, object?, object> Execute
        {
            get
            {
                return (FirstArg, SecondArg, ThirdArg) =>
                {
                    return LogicExecute(MathOperation.CompareValueAndTypeEqual, FirstArg, SecondArg);
                };
            }
        }

        public object LogicExecute(MathOperation Operation, object? FirstArg= null, object? SecondArg = null, object? ThirdArg = null)
        {
            if (FirstArg == null && SecondArg == null)
            {
                return true;
            }
            else if (FirstArg == null || SecondArg == null)
            {
                return false;
            }

            TypeCode TypeCodeA = Type.GetTypeCode(FirstArg.GetType());
            TypeCode TypeCodeB = Type.GetTypeCode(SecondArg.GetType());

            if (TypeCodeA != TypeCodeB)
            {
                return false;
            }

            if (TypeCodeA == TypeCode.Boolean || TypeCodeB == TypeCode.Boolean)
            {
                if (TypeCodeA == TypeCodeB)
                    return (bool?)FirstArg == (bool?)SecondArg;

                return false;
            }

            switch (TypeCodeA)
            {
                case TypeCode.String: return (string)FirstArg == (string)SecondArg;
                case TypeCode.Boolean: return (bool?)FirstArg == (bool?)SecondArg;
                case TypeCode.Byte: return (byte?)FirstArg == (byte?)SecondArg;
                case TypeCode.SByte: return (sbyte?)FirstArg == (sbyte?)SecondArg;
                case TypeCode.Int16: return (short?)FirstArg == (short?)SecondArg;
                case TypeCode.UInt16: return (ushort?)FirstArg == (ushort?)SecondArg;
                case TypeCode.Int32: return (int?)FirstArg == (int?)SecondArg;
                case TypeCode.UInt32: return (uint)FirstArg == (uint)SecondArg;
                case TypeCode.Int64: return (long)FirstArg == (long)SecondArg;
                case TypeCode.UInt64: return (ulong)FirstArg == (ulong)SecondArg;
                case TypeCode.Single: return (float)FirstArg == (float)SecondArg;
                case TypeCode.Double: return (double)FirstArg == (double)SecondArg;
                case TypeCode.Decimal: return (decimal)FirstArg == (decimal)SecondArg;
            }
            if (TypeCodeA != TypeCodeB)
            {
                return false;
            }
            return FirstArg.Equals(SecondArg);
        }
    }
}
