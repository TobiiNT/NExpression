using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Extensions;

namespace NExpression.Core.Exceptions
{
    public class InvalidMathOperatorException : Exception
    {
        public InvalidMathOperatorException(MathOperation Operation, TypeCode TypeCode, Exception? InnerException = null)
            : base($"Operator '{Operation.Symbol()}' can't be applied to operand of type '{TypeCode}'", InnerException)
        {
        }
        public InvalidMathOperatorException(MathOperation Operation, TypeCode TypeCodeA, TypeCode TypeCodeB, Exception? InnerException = null)
            : base($"Operator '{Operation.Symbol()}' can't be applied to operands of types '{TypeCodeA}' and '{TypeCodeB}'", InnerException)
        {

        }

        public InvalidMathOperatorException(MathOperation Operation, INode? NodeA, INode? NodeB, Exception? InnerException = null)
        : base($"Operator '{Operation.Symbol()}' can't be applied to operands of values '{NodeA?.Identity()}' and '{NodeB?.Identity()}'", InnerException)
        {

        }
    }
}
