using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Contexts
{
    public class CreateContext : IOperation
    {
        public object? Evaluate(params object?[] Params)
        {
            string? Name = Params.Length >= 1 ? (string?)Params[0] : "";

            if (Name != null)
            {
                return new DynamicContext(Name);
            }
            return new DynamicContext();
        }
    }
}
