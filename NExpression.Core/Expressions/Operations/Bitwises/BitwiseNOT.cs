﻿using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Bitwises
{
    internal class BitwiseNOT : IOperation
    {
        public object? Evaluate(params object?[] Params)
        {
            MathOperation Operation = MathOperation.BitwiseNOT;
            object? FirstArg = Params[0];

            if (FirstArg == null)
            {
                throw new ArgumentNullException("Cannot calculate null value", new ExpressionEvaluationException(Operation));
            }

            TypeCode TypeCodeA = Type.GetTypeCode(FirstArg.GetType());

            switch (TypeCodeA)
            {
                case TypeCode.Boolean: goto ThrowException;
                case TypeCode.Byte: return ~(byte)FirstArg;
                case TypeCode.SByte: return ~(sbyte)FirstArg;
                case TypeCode.Int16: return ~(short)FirstArg;
                case TypeCode.UInt16: return ~(ushort)FirstArg;
                case TypeCode.Int32: return ~(int?)FirstArg;
                case TypeCode.UInt32: return ~(uint)FirstArg;
                case TypeCode.Int64: return ~(long)FirstArg;
                case TypeCode.UInt64: goto ThrowException;
                case TypeCode.Single: goto ThrowException;
                case TypeCode.Double: goto ThrowException;
                case TypeCode.Decimal: goto ThrowException;
            }

        ThrowException:
            throw new InvalidMathOperatorException(Operation, TypeCodeA, new ExpressionEvaluationException(Operation, FirstArg));
        }
    }
}
