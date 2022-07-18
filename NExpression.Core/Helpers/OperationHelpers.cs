﻿using NExpression.Core.Contexts.Interfaces;
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
                case MathOperation.ConditionTenary: return new ConditionTenary();
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
    }
}
