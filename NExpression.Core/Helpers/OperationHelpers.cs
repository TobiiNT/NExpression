using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Expressions.Operations.Assignments;
using NExpression.Core.Expressions.Operations.Bitwises;
using NExpression.Core.Expressions.Operations.Calculations;
using NExpression.Core.Expressions.Operations.Comparisions;
using NExpression.Core.Expressions.Operations.Conditions;
using NExpression.Core.Expressions.Operations.Conversions;
using NExpression.Core.Expressions.Operations.Interfaces;
using NExpression.Core.Expressions.Operations.Logicals;
using NExpression.Core.Tokens;

namespace NExpression.Core.Helpers
{
    public static class OperationHelpers
    {
        public static MathOperation GetOperationByToken(Token Token)
        {
            switch (Token)
            {
                case Token.SingleCross: return MathOperation.Add;
                case Token.SingleDash: return MathOperation.Subtract;
                case Token.SingleAsterisk: return MathOperation.Multiply;
                case Token.SingleSlash: return MathOperation.Divide;
                case Token.SinglePercent: return MathOperation.Modulus;

                case Token.DoupleEqual: return MathOperation.CompareValueEqual;
                case Token.TripleEqual: return MathOperation.CompareValueAndTypeEqual;
                case Token.SingleExclamationAndSingleEqual: return MathOperation.CompareValueNotEqual;
                case Token.SingleExclamationAndDoubleEqual: return MathOperation.CompareValueAndTypeNotEqual;
                case Token.SingleGreaterThan: return MathOperation.CompareGreaterThan;
                case Token.SingleGreaterThanAndEqual: return MathOperation.CompareGreaterThanOrEqual;
                case Token.SingleLessThan: return MathOperation.CompareLessThan;
                case Token.SingleLessThanAndEqual: return MathOperation.CompareLessThanOrEqual;

                case Token.SingleTilde: return MathOperation.BitwiseNOT;
                case Token.SingleAmpersand: return MathOperation.BitwiseAND;
                case Token.SingleCaret: return MathOperation.BitwiseXOR;
                case Token.SinglePipe: return MathOperation.BitwiseOR;
                case Token.DoubleLessThan: return MathOperation.BitwiseShiftLeft;
                case Token.DoubleGreaterThan: return MathOperation.BitwiseShiftRight;

                case Token.DoubleAmpersand: return MathOperation.LogicalAND;
                case Token.DoublePipe: return MathOperation.LogicalOR;
                case Token.DoubleQuestion: return MathOperation.LogicalIFNULL;

                case Token.SingleEqual: return MathOperation.AssignEqual;
                case Token.SingleCrossAndEqual: return MathOperation.AssignAdd;
                case Token.SingleDashAndEqual: return MathOperation.AssignSubtract;
                case Token.SingleAsteriskAndEqual: return MathOperation.AssignMultiply;
                case Token.SingleSlashAndEqual: return MathOperation.AssignDivide;
                case Token.SinglePercentAndEqual: return MathOperation.AssignModulus;
                case Token.SingleAmpersandAndEqual: return MathOperation.AssignBitwiseAND;
                case Token.SinglePipeAndEqual: return MathOperation.AssignBitwiseOR;
                case Token.SingleCaretAndEqual: return MathOperation.AssignBitwiseXOR;
                case Token.DoubleLessThanAndEqual: return MathOperation.AssignBitwiseShiftLeft;
                case Token.DoubleGreaterThanAndEqual: return MathOperation.AssignBitwiseShiftRight;
                case Token.DoubleQuestionAndEqual: return MathOperation.AssignIFNULL;

                default: return MathOperation.NoOperation;
            }
        }

        public static IOperation? GetOperation(MathOperation Operation, IContext? WriteContext = null)
        {
            switch (Operation)
            {
                case MathOperation.Add: return new CalculationAdd();
                case MathOperation.Subtract: return new CalculationSubtract();
                case MathOperation.Negative: return new CalculationNegative();
                case MathOperation.Multiply: return new CalculationMultiply();
                case MathOperation.Divide: return new CalculationDivide();
                case MathOperation.Modulus: return new CalculationModulus();
                case MathOperation.Factorial: return new CalculationFactorial();
                case MathOperation.CompareGreaterThan: return new ComparisionGreaterThan();
                case MathOperation.CompareGreaterThanOrEqual: return new ComparisionGreaterThanOrEqual();
                case MathOperation.CompareLessThan: return new ComparisionLessThan();
                case MathOperation.CompareLessThanOrEqual: return new ComparisionLessThanOrEqual();
                case MathOperation.CompareValueEqual: return new ComparisionValueEqual();
                case MathOperation.CompareValueNotEqual: return new ComparisionValueNotEqual();
                case MathOperation.CompareValueAndTypeEqual: return new ComparisionValueAndTypeEqual();
                case MathOperation.CompareValueAndTypeNotEqual: return new ComparisionValueAndTypeNotEqual();
                case MathOperation.BitwiseNOT: return new BitwiseNOT();
                case MathOperation.BitwiseAND: return new BitwiseAND();
                case MathOperation.BitwiseXOR: return new BitwiseXOR();
                case MathOperation.BitwiseOR: return new BitwiseOR();
                case MathOperation.BitwiseShiftLeft: return new BitwiseShiftLeft();
                case MathOperation.BitwiseShiftRight: return new BitwiseShiftRight();
                case MathOperation.LogicalAND: return new LogicalAND();
                case MathOperation.LogicalOR: return new LogicalOR();
                case MathOperation.LogicalNOT: return new LogicalNOT();
                case MathOperation.LogicalIFNULL: return new LogicalIFNULL();
                case MathOperation.CharValue: return new ConvertToString();
                case MathOperation.StringValue: return new ConvertToString();
                case MathOperation.ConditionTernary: return new ConditionTernary();
                case MathOperation.AssignEqual: return new AssignEqual(WriteContext);
                case MathOperation.AssignAddBeforeReturn: return new AssignAddBeforeReturn(WriteContext);
                case MathOperation.AssignAddAfterReturn: return new AssignAddAfterReturn(WriteContext);
                case MathOperation.AssignAdd: return new AssignAdd(WriteContext);
                case MathOperation.AssignSubtractBeforeReturn: return new AssignSubtractBeforeReturn(WriteContext);
                case MathOperation.AssignSubtractAfterReturn: return new AssignSubtractAfterReturn(WriteContext);
                case MathOperation.AssignSubtract: return new AssignSubtract(WriteContext);
                case MathOperation.AssignMultiply: return new AssignMultiply(WriteContext);
                case MathOperation.AssignDivide: return new AssignDivide(WriteContext);
                case MathOperation.AssignModulus: return new AssignModulus(WriteContext);
                case MathOperation.AssignBitwiseAND: return new AssignBitwiseAND(WriteContext);
                case MathOperation.AssignBitwiseOR: return new AssignBitwiseOR(WriteContext);
                case MathOperation.AssignBitwiseXOR: return new AssignBitwiseXOR(WriteContext);
                case MathOperation.AssignBitwiseShiftLeft: return new AssignBitwiseShiftLeft(WriteContext);
                case MathOperation.AssignBitwiseShiftRight: return new AssignBitwiseShiftRight(WriteContext);
                case MathOperation.AssignIFNULL: return new AssignIFNULL(WriteContext);
                default: return default;
            }
        }

        public static MathOperation? GetMathOperation(IOperation? Operation)
        {
            switch (Operation)
            {
                case CalculationAdd: return MathOperation.Add;
                case CalculationSubtract: return MathOperation.Subtract;
                case CalculationNegative: return MathOperation.Negative;
                case CalculationMultiply: return MathOperation.Multiply;
                case CalculationDivide: return MathOperation.Divide;
                case CalculationModulus: return MathOperation.Modulus;
                case CalculationFactorial: return MathOperation.Factorial;
                case ComparisionGreaterThan: return MathOperation.CompareGreaterThan;
                case ComparisionGreaterThanOrEqual: return MathOperation.CompareGreaterThanOrEqual;
                case ComparisionLessThan: return MathOperation.CompareLessThan;
                case ComparisionLessThanOrEqual: return MathOperation.CompareLessThanOrEqual;
                case ComparisionValueEqual: return MathOperation.CompareValueEqual;
                case ComparisionValueNotEqual: return MathOperation.CompareValueNotEqual;
                case ComparisionValueAndTypeEqual: return MathOperation.CompareValueAndTypeEqual;
                case ComparisionValueAndTypeNotEqual: return MathOperation.CompareValueAndTypeNotEqual;
                case BitwiseNOT: return MathOperation.BitwiseNOT;
                case BitwiseAND: return MathOperation.BitwiseAND;
                case BitwiseXOR: return MathOperation.BitwiseXOR;
                case BitwiseOR: return MathOperation.BitwiseOR;
                case BitwiseShiftLeft: return MathOperation.BitwiseShiftLeft;
                case BitwiseShiftRight: return MathOperation.BitwiseShiftRight;
                case LogicalAND: return MathOperation.LogicalAND;
                case LogicalOR: return MathOperation.LogicalOR;
                case LogicalNOT: return MathOperation.LogicalNOT;
                case LogicalIFNULL: return MathOperation.LogicalIFNULL;
                case ConvertToString: return MathOperation.StringValue;
                case ConditionTernary: return MathOperation.ConditionTernary;
                case AssignEqual: return MathOperation.AssignEqual;
                case AssignAddBeforeReturn: return MathOperation.AssignAddBeforeReturn;
                case AssignAddAfterReturn: return MathOperation.AssignAddAfterReturn;
                case AssignAdd: return MathOperation.AssignAdd;
                case AssignSubtractBeforeReturn: return MathOperation.AssignSubtractBeforeReturn;
                case AssignSubtractAfterReturn: return MathOperation.AssignSubtractAfterReturn;
                case AssignSubtract: return MathOperation.AssignSubtract;
                case AssignMultiply: return MathOperation.AssignMultiply;
                case AssignDivide: return MathOperation.AssignDivide;
                case AssignModulus: return MathOperation.AssignModulus;
                case AssignBitwiseAND: return MathOperation.AssignBitwiseAND;
                case AssignBitwiseOR: return MathOperation.AssignBitwiseOR;
                case AssignBitwiseXOR: return MathOperation.AssignBitwiseXOR;
                case AssignBitwiseShiftLeft: return MathOperation.AssignBitwiseShiftLeft;
                case AssignBitwiseShiftRight: return MathOperation.AssignBitwiseShiftRight;
                case AssignIFNULL: return MathOperation.AssignIFNULL;
                default: return default;
            }
        }
    }
}
