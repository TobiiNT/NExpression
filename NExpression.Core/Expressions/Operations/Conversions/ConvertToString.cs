using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Conversions
{
    internal class ConvertToString : IOperation
    {
        public object? Evaluate(params object?[] Params)
        {
            MathOperation Operation = MathOperation.StringValue;
            object? FirstArg = Params[0];

            return FirstArg?.ToString() ?? "";
        }
    }
}
