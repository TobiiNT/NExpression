using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Conversions
{
    internal class ConvertToString : IOperation
    {
        public Func<object?, object?, object?, object> Execute
        {
            get
            {
                return (FirstArg, SecondArg, ThirdArg) =>
                {
                    return LogicExecute(MathOperation.StringValue, FirstArg, SecondArg);
                };
            }
        }

        public object LogicExecute(MathOperation Operation, object? FirstArg = null, object? SecondArg = null, object? ThirdArg = null)
        {
            return FirstArg?.ToString() ?? "";
        }
    }
}
