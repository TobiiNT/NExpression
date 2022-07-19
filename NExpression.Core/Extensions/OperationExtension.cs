using NExpression.Core.Expressions.Operations;

namespace NExpression.Core.Extensions
{
    public static class OperationExtension
    {
        public static string Symbol(this MathOperation Operation)
        {
            switch (Operation)
            {
                case MathOperation.Add: return "+";
                case MathOperation.Subtract: return "-";
                case MathOperation.Negative: return "-";
                case MathOperation.Multiply: return "*";
                case MathOperation.Divide: return "/";
                case MathOperation.Modulus: return "%";
                case MathOperation.Factorial: return "!";
                case MathOperation.CompareGreaterThan: return ">";
                case MathOperation.CompareLessThan: return "<";
                case MathOperation.CompareGreaterThanOrEqual: return ">=";
                case MathOperation.CompareLessThanOrEqual: return "<=";
                case MathOperation.CompareValueEqual: return "==";
                case MathOperation.CompareValueNotEqual: return "!=";
                case MathOperation.CompareValueAndTypeEqual: return "===";
                case MathOperation.CompareValueAndTypeNotEqual: return "!==";
                case MathOperation.BitwiseNOT: return "~";
                case MathOperation.BitwiseAND: return "&";
                case MathOperation.BitwiseXOR: return "^";
                case MathOperation.BitwiseOR: return "|";
                case MathOperation.BitwiseShiftLeft: return "<<";
                case MathOperation.BitwiseShiftRight: return ">>";
                case MathOperation.LogicalAND: return "&&";
                case MathOperation.LogicalOR: return "||";
                case MathOperation.LogicalNOT: return "!";
                case MathOperation.LogicalIFNULL: return "??=";
                case MathOperation.ConditionTernary: return "? :";
                case MathOperation.AssignEqual: return "=";
                case MathOperation.AssignAddAfterReturn: return "++";
                case MathOperation.AssignAddBeforeReturn: return "++";
                case MathOperation.AssignAdd: return "+=";
                case MathOperation.AssignSubtractAfterReturn: return "--";
                case MathOperation.AssignSubtractBeforeReturn: return "--";
                case MathOperation.AssignSubtract: return "-=";
                case MathOperation.AssignMultiply: return "*=";
                case MathOperation.AssignDivide: return "/=";
                case MathOperation.AssignModulus: return "%=";
                case MathOperation.AssignBitwiseAND: return "&=";
                case MathOperation.AssignBitwiseOR: return "|=";
                case MathOperation.AssignBitwiseXOR: return "^=";
                case MathOperation.AssignBitwiseShiftLeft: return "<<=";
                case MathOperation.AssignBitwiseShiftRight: return ">>=";
                case MathOperation.AssignIFNULL: return "??=";
                case MathOperation.StringValue: return "string";
                case MathOperation.CharValue: return "char";
                case MathOperation.FunctionCall: return "function";
                default: return Operation.ToString();
            }
        }
    }
}
