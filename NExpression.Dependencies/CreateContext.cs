using NExpression.Core.Contexts;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Dependencies
{
    public class CreateContext : IOperation
    {
        public object? Evaluate(params object?[] Params)
        {
            string? Name = (string?)Params[0];

            if (Name != null)
            {
                return new DynamicContext(Name);
            }
            return new DynamicContext();
        }
    }
}
