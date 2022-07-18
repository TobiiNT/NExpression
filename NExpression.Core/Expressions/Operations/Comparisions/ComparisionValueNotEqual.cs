using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Comparisions
{
    internal class ComparisionValueNotEqual : IOperation
    {
        public Func<object?, object?, object?, object> Execute
        {
            get
            {
                return (FirstArg, SecondArg, ThirdArg) =>
                {
                    return LogicExecute(MathOperation.CompareValueNotEqual, FirstArg, SecondArg);
                };
            }
        }

        public object LogicExecute(MathOperation Operation, object? FirstArg = null, object? SecondArg = null, object? ThirdArg = null)
        {
            if (FirstArg == null && SecondArg == null)
            {
                return false;
            }
            else if (FirstArg == null && SecondArg != null || FirstArg != null && SecondArg == null)
            {
                return true;
            }

            TypeCode TypeCodeA = Type.GetTypeCode(FirstArg?.GetType());
            TypeCode TypeCodeB = Type.GetTypeCode(SecondArg?.GetType());

            if (TypeCodeA == TypeCode.Boolean || TypeCodeB == TypeCode.Boolean)
            {
                if (TypeCodeA == TypeCodeB)
                    return (bool?)FirstArg != (bool?)SecondArg;

                return true;
            }

            switch (TypeCodeA)
            {
                case TypeCode.String: return (string?)FirstArg != Convert.ToString(SecondArg);
                case TypeCode.Boolean: return (bool?)FirstArg != Convert.ToBoolean(SecondArg);
                case TypeCode.Byte: return (byte?)FirstArg != Convert.ToByte(SecondArg);
                case TypeCode.SByte: return (sbyte?)FirstArg != Convert.ToSByte(SecondArg);
                case TypeCode.Int16: return (short?)FirstArg != Convert.ToInt16(SecondArg);
                case TypeCode.UInt16: return (ushort?)FirstArg != Convert.ToUInt16(SecondArg);
                case TypeCode.Int32: return (int?)FirstArg != Convert.ToInt32(SecondArg);
                case TypeCode.UInt32: return (uint?)FirstArg != Convert.ToUInt32(SecondArg);
                case TypeCode.Int64: return (long?)FirstArg != Convert.ToInt64(SecondArg);
                case TypeCode.UInt64: return (ulong?)FirstArg != Convert.ToUInt64(SecondArg);
                case TypeCode.Single: return (float?)FirstArg != Convert.ToSingle(SecondArg);
                case TypeCode.Double: return (double?)FirstArg != Convert.ToDouble(SecondArg);
                case TypeCode.Decimal: return (decimal?)FirstArg != Convert.ToDecimal(SecondArg);
            }
            if (TypeCodeA == TypeCodeB)
            {
                return false;
            }
            return FirstArg != SecondArg;
        }
    }
}
